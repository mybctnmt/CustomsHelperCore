using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Entity.Basic;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public class tbasecustomerBusiness : BaseBusiness<tbasecustomer>, ItbasecustomerBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public IOperator _operator;
        public tbasecustomerBusiness(IDbAccessor db, IOperator @operator, IConnectionMultiplexer redis)
            : base(db)
        {
            _operator = @operator;
            _redis = redis.GetDatabase();
        }

        protected void InitEntity(object obj)
        {
            if (obj.ContainsProperty("Id"))
                obj.SetPropertyValue("Id", IdHelper.GetId());
            if (obj.ContainsProperty("CreateTime"))
                obj.SetPropertyValue("CreateTime", DateTime.Now);
            if (obj.ContainsProperty("CreatorId"))
                obj.SetPropertyValue("CreatorId", _operator?.UserId);
            if (obj.ContainsProperty("CreatorRealName"))
                obj.SetPropertyValue("CreatorRealName", _operator?.Property?.RealName);
        }
        #region 外部接口

        public async Task<PageResult<tbasecustomer>> GetDataListAsync(PageInput<List<ConditionDTO>> input)
        {
            //string cacheKey = "DataList-tbasecustomer";

            //string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            //if (!string.IsNullOrEmpty(cachedDataJson))
            //{
            //    var cachedData = JsonConvert.DeserializeObject<PageResult<tbasecustomer>>(cachedDataJson);
            //    if (cachedData != null)
            //    {
            //        return cachedData;
            //    }
            //}
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasecustomer>();

            foreach (ConditionDTO search in input.Search)
            {
                //筛选
                if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                {
                    var newWhere = DynamicExpressionParser.ParseLambda<tbasecustomer, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                    where = where.And(newWhere);
                }
            }
            var data = await q.Where(where).GetPageResultAsync(input);
            //string dataJson = JsonConvert.SerializeObject(data);
            //await _redis.StringSetAsync(cacheKey, dataJson);

            return data;
        }

        public async Task<tbasecustomer> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> AddDataAsync(tbasecustomer data)
        {
            await InsertAsync(data);
            return data.Id;
        }

        public async Task<string> UpdateDataAsync(tbasecustomer data)
        {
            await UpdateAsync(data);
            return data.Id;
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<string> Check(string Id, string Type)
        {
            tbasecustomer data = await GetEntityAsync(Id);
            data.IsCheck = Type;
            await UpdateAsync(data);
            return data.Id;
        }

        public async Task DeleteData(string id)
        {
            await DeleteAsync(id);
        }

        public async Task<bool> CheckRepeat(tbasecustomer data)
        {
            bool result = await Db.GetIQueryable<tbasecustomer>().Where(t => (t.CustomerName == data.CustomerName || t.CustomerShortName == data.CustomerShortName) && t.Id != data.Id).AnyAsync();
            return result;   
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // 正则表达式，用来检查邮箱的格式是否正确
                string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

                // 使用Regex.IsMatch静态方法检查邮箱格式
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        [Transactional]
        public async Task Import(DataTable dataTable)
        {
            try
            {
                List<tbasecustomer> tbasecustomers = Db.GetIQueryable<tbasecustomer>().ToList();
                List<tbasecustomercontacts> tbasecustomercontacts = Db.GetIQueryable<tbasecustomercontacts>().ToList();
                List<tbasecustomerfee> tbasecustomerfees = Db.GetIQueryable<tbasecustomerfee>().ToList();
                List<tbasecustomerrelation> tbasecustomerrelations = Db.GetIQueryable<tbasecustomerrelation>().ToList();
                List<tbasefee> tbasefees = Db.GetIQueryable<tbasefee>().ToList();
                List<Base_User> users = Db.GetIQueryable<Base_User>().ToList();

                List<tbasecustomer> insertCustomers = new List<tbasecustomer>();

                tbasecustomer insertCustomer = new tbasecustomer();

                List<tbasecustomercontacts> insertContacts = new List<tbasecustomercontacts>();
                List<tbasecustomercontacts> updateContacts = new List<tbasecustomercontacts>();

                List<tbasecustomerfee> insertFees = new List<tbasecustomerfee>();
                List<tbasecustomerfee> updateFees = new List<tbasecustomerfee>();

                List<tbasecustomerrelation> insertRelations = new List<tbasecustomerrelation>();
                List<tbasecustomerrelation> updateRelations = new List<tbasecustomerrelation>();

                foreach (DataRow item in dataTable.Rows)
                {
                    string customerShortName = item["客户名称"].ToString();
                    string name = item["操作联系人"].ToString();
                    string contactStr = item["QQ/邮箱/微信"].ToString();
                    string email = "test@test.com";
                    if (IsValidEmail(contactStr))
                    {
                        email = contactStr;
                    }
                    //string qq = item["QQ"].ToString();
                    //string wechat = item["微信"].ToString();
                    //string email = item["邮箱"].ToString();
                    //string mobilePhone = item["电话"].ToString();
                    //string officePhone = item["座机"].ToString();
                    //string outFee = item["出口费率"].ToString();
                    //string inFee = item["进口费率"].ToString();
                    //string relationName = item["客户负责人"].ToString();
                    tbasecustomer tbasecustomer = tbasecustomers.Where(t => t.CustomerShortName == customerShortName).FirstOrDefault();
                    if (tbasecustomer != null)
                    {
                        List<tbasecustomercontacts> contacts = tbasecustomercontacts.Where(t => t.CId == tbasecustomer.Id).ToList();
                        tbasecustomercontacts contact = contacts.Where(x => x.Name == name).FirstOrDefault();
                        if (contact != null)
                        {
                            contact.Name = name;
                            //contact.QQ = qq;
                            //contact.Wechat = wechat;
                            if (string.IsNullOrEmpty(contact.Email))
                            {
                                contact.Email = email;
                            }
                            //contact.MobilePhone = mobilePhone;
                            //contact.OfficePhone = officePhone;
                            contact.CId = tbasecustomer.Id;
                            updateContacts.Add(contact);
                        }
                        else
                        {
                            tbasecustomercontacts insertContact = new tbasecustomercontacts()
                            {
                                Name = name,
                                //QQ = qq,
                                //Wechat = wechat,
                                Email = email,
                                //MobilePhone = mobilePhone,
                                //OfficePhone = officePhone,
                                CId = tbasecustomer.Id
                            };
                            InitEntity(insertContact);
                            insertContacts.Add(insertContact);
                        }
                        //List<tbasecustomerfee> fees = tbasecustomerfees.Where(t => t.CId == tbasecustomer.Id).ToList();

                        //List<string> outs = outFee.Split("|").ToList();
                        //foreach (var fee in outs)
                        //{
                        //    if (!fee.IsNullOrEmpty())
                        //    {
                        //        string feeName = fee.Split("=").ToList()[0];
                        //        string feeRate = fee.Split("=").ToList()[1];
                        //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
                        //        tbasecustomerfee tbasecustomerfee = fees.Where(x => x.EoI == "出口" && x.FeeID == feeId).FirstOrDefault();
                        //        if (tbasecustomerfee != null)
                        //        {
                        //            tbasecustomerfee.EoI = "出口";
                        //            tbasecustomerfee.FeeID = feeId;
                        //            tbasecustomerfee.FeeRate = feeRate;
                        //            tbasecustomerfee.FeeType = "应收";
                        //            tbasecustomerfee.CId = tbasecustomer.Id;
                        //            updateFees.Add(tbasecustomerfee);
                        //        }
                        //        else
                        //        {
                        //            tbasecustomerfee insertFee = new tbasecustomerfee()
                        //            {
                        //                EoI = "出口",
                        //                FeeID = feeId,
                        //                FeeRate = feeRate,
                        //                FeeType = "应收",
                        //                CId = tbasecustomer.Id
                        //            };
                        //            InitEntity(insertFee);
                        //            insertFees.Add(insertFee);
                        //        }
                        //    }
                        //}
                        //List<string> ins = inFee.Split("|").ToList();
                        //foreach (var fee in ins)
                        //{
                        //    if (!fee.IsNullOrEmpty())
                        //    {
                        //        string feeName = fee.Split("=").ToList()[0];
                        //        string feeRate = fee.Split("=").ToList()[1];
                        //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
                        //        tbasecustomerfee tbasecustomerfee = fees.Where(x => x.EoI == "进口" && x.FeeID == feeId).FirstOrDefault();
                        //        if (tbasecustomerfee != null)
                        //        {
                        //            tbasecustomerfee.EoI = "进口";
                        //            tbasecustomerfee.FeeID = feeId;
                        //            tbasecustomerfee.FeeRate = feeRate;
                        //            tbasecustomerfee.FeeType = "应收";
                        //            tbasecustomerfee.CId = tbasecustomer.Id;
                        //            updateFees.Add(tbasecustomerfee);
                        //        }
                        //        else
                        //        {
                        //            tbasecustomerfee insertFee = new tbasecustomerfee()
                        //            {
                        //                EoI = "进口",
                        //                FeeID = feeId,
                        //                FeeRate = feeRate,
                        //                FeeType = "应收",
                        //                CId = tbasecustomer.Id
                        //            };
                        //            InitEntity(insertFee);
                        //            insertFees.Add(insertFee);
                        //        }
                        //    }
                        //}
                        //Base_User user = users.Where(t => t.RealName.Contains(relationName)).FirstOrDefault();

                        //List<tbasecustomerrelation> relations = tbasecustomerrelations.Where(t => t.CId == tbasecustomer.Id).ToList();
                        //tbasecustomerrelation relation = relations.Where(x => x.UId == user.Id).FirstOrDefault();
                        //if (relation != null)
                        //{
                        //    relation.UId = user.Id;
                        //    relation.DId = user.DepartmentId;
                        //    relation.CId = tbasecustomer.Id;
                        //    updateRelations.Add(relation);
                        //}
                        //else
                        //{
                        //    tbasecustomerrelation insertRelation = new tbasecustomerrelation()
                        //    {
                        //        UId = user.Id,
                        //        DId = user.DepartmentId,
                        //        CId = tbasecustomer.Id,
                        //    };
                        //    InitEntity(insertRelation);
                        //    insertRelations.Add(insertRelation);
                        //}
                    }
                    else
                    {
                        if (!insertCustomers.Where(x => x.CustomerShortName == customerShortName).Any())
                        {
                            insertCustomer.CustomerShortName = customerShortName;
                            InitEntity(insertCustomer);
                            insertCustomers.Add(insertCustomer);
                        }
                        tbasecustomercontacts insertContact = new tbasecustomercontacts()
                        {
                            Name = name,
                            //QQ = qq,
                            //Wechat = wechat,
                            Email = email,
                            //MobilePhone = mobilePhone,
                            //OfficePhone = officePhone,
                            CId = insertCustomer.Id
                        };
                        InitEntity(insertContact);
                        insertContacts.Add(insertContact);

                        //List<string> outs = outFee.Split("|").ToList();
                        //foreach (var fee in outs)
                        //{
                        //    if (!fee.IsNullOrEmpty())
                        //    {
                        //        string feeName = fee.Split("=").ToList()[0];
                        //        string feeRate = fee.Split("=").ToList()[1];
                        //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
                        //        tbasecustomerfee insertFee = new tbasecustomerfee()
                        //        {
                        //            EoI = "出口",
                        //            FeeID = feeId,
                        //            FeeRate = feeRate,
                        //            FeeType = "应收",
                        //            CId = insertCustomer.Id
                        //        };
                        //        InitEntity(insertFee);
                        //        insertFees.Add(insertFee);
                        //    }
                        //}
                        //List<string> ins = inFee.Split("|").ToList();
                        //foreach (var fee in ins)
                        //{

                        //    if (!fee.IsNullOrEmpty())
                        //    {
                        //        string feeName = fee.Split("=").ToList()[0];
                        //        string feeRate = fee.Split("=").ToList()[1];
                        //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
                        //        tbasecustomerfee insertFee = new tbasecustomerfee()
                        //        {
                        //            EoI = "进口",
                        //            FeeID = feeId,
                        //            FeeRate = feeRate,
                        //            FeeType = "应收",
                        //            CId = insertCustomer.Id
                        //        };
                        //        InitEntity(insertFee);
                        //        insertFees.Add(insertFee);
                        //    }

                        //}
                        //Base_User user = users.Where(t => t.RealName.Contains(relationName)).FirstOrDefault();
                        //tbasecustomerrelation insertRelation = new tbasecustomerrelation()
                        //{
                        //    UId = user.Id,
                        //    DId = user.DepartmentId,
                        //    CId = insertCustomer.Id,
                        //};
                        //InitEntity(insertRelation);
                        //insertRelations.Add(insertRelation);
                    }
                }
                await Db.InsertAsync(insertCustomers);
                await Db.InsertAsync(insertContacts);
                await Db.InsertAsync(insertFees);
                await Db.InsertAsync(insertRelations);
                await Db.UpdateAsync(updateContacts);
                await Db.UpdateAsync(updateFees);
                await Db.UpdateAsync(updateRelations);
            }
            catch (Exception ex)
            {
                LogHelper.LogInformation(ex.Message);
            }
            
        }
        //public async Task Import(DataTable dataTable)
        //{
        //    try
        //    {
        //        List<tbasecustomer> tbasecustomers = Db.GetIQueryable<tbasecustomer>().ToList();
        //        List<tbasecustomercontacts> tbasecustomercontacts = Db.GetIQueryable<tbasecustomercontacts>().ToList();
        //        List<tbasecustomerfee> tbasecustomerfees = Db.GetIQueryable<tbasecustomerfee>().ToList();
        //        List<tbasecustomerrelation> tbasecustomerrelations = Db.GetIQueryable<tbasecustomerrelation>().ToList();
        //        List<tbasefee> tbasefees = Db.GetIQueryable<tbasefee>().ToList();
        //        List<Base_User> users = Db.GetIQueryable<Base_User>().ToList();

        //        List<tbasecustomer> insertCustomers = new List<tbasecustomer>();

        //        tbasecustomer insertCustomer = new tbasecustomer();

        //        List<tbasecustomercontacts> insertContacts = new List<tbasecustomercontacts>();
        //        List<tbasecustomercontacts> updateContacts = new List<tbasecustomercontacts>();

        //        List<tbasecustomerfee> insertFees = new List<tbasecustomerfee>();
        //        List<tbasecustomerfee> updateFees = new List<tbasecustomerfee>();

        //        List<tbasecustomerrelation> insertRelations = new List<tbasecustomerrelation>();
        //        List<tbasecustomerrelation> updateRelations = new List<tbasecustomerrelation>();

        //        foreach (DataRow item in dataTable.Rows)
        //        {
        //            string customerShortName = item["客户名称"].ToString();
        //            string name = item["操作联系人"].ToString();
        //            //string qq = item["QQ"].ToString();
        //            //string wechat = item["微信"].ToString();
        //            //string email = item["邮箱"].ToString();
        //            //string mobilePhone = item["电话"].ToString();
        //            //string officePhone = item["座机"].ToString();
        //            //string outFee = item["出口费率"].ToString();
        //            //string inFee = item["进口费率"].ToString();
        //            //string relationName = item["客户负责人"].ToString();
        //            tbasecustomer tbasecustomer = tbasecustomers.Where(t => t.CustomerShortName == customerShortName).FirstOrDefault();
        //            if (tbasecustomer != null)
        //            {
        //                List<tbasecustomercontacts> contacts = tbasecustomercontacts.Where(t => t.CId == tbasecustomer.Id).ToList();
        //                tbasecustomercontacts contact = contacts.Where(x => x.Name == name).FirstOrDefault();
        //                if (contact != null)
        //                {
        //                    contact.Name = name;
        //                    //contact.QQ = qq;
        //                    //contact.Wechat = wechat;
        //                    //contact.Email = email;
        //                    //contact.MobilePhone = mobilePhone;
        //                    //contact.OfficePhone = officePhone;
        //                    contact.CId = tbasecustomer.Id;
        //                    updateContacts.Add(contact);
        //                }
        //                else
        //                {
        //                    tbasecustomercontacts insertContact = new tbasecustomercontacts()
        //                    {
        //                        Name = name,
        //                        //QQ = qq,
        //                        //Wechat = wechat,
        //                        //Email = email,
        //                        //MobilePhone = mobilePhone,
        //                        //OfficePhone = officePhone,
        //                        CId = tbasecustomer.Id
        //                    };
        //                    InitEntity(insertContact);
        //                    insertContacts.Add(insertContact);
        //                }
        //                //List<tbasecustomerfee> fees = tbasecustomerfees.Where(t => t.CId == tbasecustomer.Id).ToList();

        //                //List<string> outs = outFee.Split("|").ToList();
        //                //foreach (var fee in outs)
        //                //{
        //                //    if (!fee.IsNullOrEmpty())
        //                //    {
        //                //        string feeName = fee.Split("=").ToList()[0];
        //                //        string feeRate = fee.Split("=").ToList()[1];
        //                //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
        //                //        tbasecustomerfee tbasecustomerfee = fees.Where(x => x.EoI == "出口" && x.FeeID == feeId).FirstOrDefault();
        //                //        if (tbasecustomerfee != null)
        //                //        {
        //                //            tbasecustomerfee.EoI = "出口";
        //                //            tbasecustomerfee.FeeID = feeId;
        //                //            tbasecustomerfee.FeeRate = feeRate;
        //                //            tbasecustomerfee.FeeType = "应收";
        //                //            tbasecustomerfee.CId = tbasecustomer.Id;
        //                //            updateFees.Add(tbasecustomerfee);
        //                //        }
        //                //        else
        //                //        {
        //                //            tbasecustomerfee insertFee = new tbasecustomerfee()
        //                //            {
        //                //                EoI = "出口",
        //                //                FeeID = feeId,
        //                //                FeeRate = feeRate,
        //                //                FeeType = "应收",
        //                //                CId = tbasecustomer.Id
        //                //            };
        //                //            InitEntity(insertFee);
        //                //            insertFees.Add(insertFee);
        //                //        }
        //                //    }
        //                //}
        //                //List<string> ins = inFee.Split("|").ToList();
        //                //foreach (var fee in ins)
        //                //{
        //                //    if (!fee.IsNullOrEmpty())
        //                //    {
        //                //        string feeName = fee.Split("=").ToList()[0];
        //                //        string feeRate = fee.Split("=").ToList()[1];
        //                //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
        //                //        tbasecustomerfee tbasecustomerfee = fees.Where(x => x.EoI == "进口" && x.FeeID == feeId).FirstOrDefault();
        //                //        if (tbasecustomerfee != null)
        //                //        {
        //                //            tbasecustomerfee.EoI = "进口";
        //                //            tbasecustomerfee.FeeID = feeId;
        //                //            tbasecustomerfee.FeeRate = feeRate;
        //                //            tbasecustomerfee.FeeType = "应收";
        //                //            tbasecustomerfee.CId = tbasecustomer.Id;
        //                //            updateFees.Add(tbasecustomerfee);
        //                //        }
        //                //        else
        //                //        {
        //                //            tbasecustomerfee insertFee = new tbasecustomerfee()
        //                //            {
        //                //                EoI = "进口",
        //                //                FeeID = feeId,
        //                //                FeeRate = feeRate,
        //                //                FeeType = "应收",
        //                //                CId = tbasecustomer.Id
        //                //            };
        //                //            InitEntity(insertFee);
        //                //            insertFees.Add(insertFee);
        //                //        }
        //                //    }
        //                //}
        //                //Base_User user = users.Where(t => t.RealName.Contains(relationName)).FirstOrDefault();

        //                //List<tbasecustomerrelation> relations = tbasecustomerrelations.Where(t => t.CId == tbasecustomer.Id).ToList();
        //                //tbasecustomerrelation relation = relations.Where(x => x.UId == user.Id).FirstOrDefault();
        //                //if (relation != null)
        //                //{
        //                //    relation.UId = user.Id;
        //                //    relation.DId = user.DepartmentId;
        //                //    relation.CId = tbasecustomer.Id;
        //                //    updateRelations.Add(relation);
        //                //}
        //                //else
        //                //{
        //                //    tbasecustomerrelation insertRelation = new tbasecustomerrelation()
        //                //    {
        //                //        UId = user.Id,
        //                //        DId = user.DepartmentId,
        //                //        CId = tbasecustomer.Id,
        //                //    };
        //                //    InitEntity(insertRelation);
        //                //    insertRelations.Add(insertRelation);
        //                //}
        //            }
        //            else
        //            {
        //                if (insertCustomer.CustomerShortName != customerShortName)
        //                {
        //                    insertCustomer.CustomerShortName = customerShortName;
        //                    InitEntity(insertCustomer);
        //                    insertCustomers.Add(insertCustomer);
        //                }
        //                tbasecustomercontacts insertContact = new tbasecustomercontacts()
        //                {
        //                    Name = name,
        //                    //QQ = qq,
        //                    //Wechat = wechat,
        //                    //Email = email,
        //                    //MobilePhone = mobilePhone,
        //                    //OfficePhone = officePhone,
        //                    CId = insertCustomer.Id
        //                };
        //                InitEntity(insertContact);
        //                insertContacts.Add(insertContact);

        //                //List<string> outs = outFee.Split("|").ToList();
        //                //foreach (var fee in outs)
        //                //{
        //                //    if (!fee.IsNullOrEmpty())
        //                //    {
        //                //        string feeName = fee.Split("=").ToList()[0];
        //                //        string feeRate = fee.Split("=").ToList()[1];
        //                //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
        //                //        tbasecustomerfee insertFee = new tbasecustomerfee()
        //                //        {
        //                //            EoI = "出口",
        //                //            FeeID = feeId,
        //                //            FeeRate = feeRate,
        //                //            FeeType = "应收",
        //                //            CId = insertCustomer.Id
        //                //        };
        //                //        InitEntity(insertFee);
        //                //        insertFees.Add(insertFee);
        //                //    }
        //                //}
        //                //List<string> ins = inFee.Split("|").ToList();
        //                //foreach (var fee in ins)
        //                //{

        //                //    if (!fee.IsNullOrEmpty())
        //                //    {
        //                //        string feeName = fee.Split("=").ToList()[0];
        //                //        string feeRate = fee.Split("=").ToList()[1];
        //                //        string feeId = tbasefees.Where(t => t.FeeNameCn.Contains(feeName)).FirstOrDefault().Id;
        //                //        tbasecustomerfee insertFee = new tbasecustomerfee()
        //                //        {
        //                //            EoI = "进口",
        //                //            FeeID = feeId,
        //                //            FeeRate = feeRate,
        //                //            FeeType = "应收",
        //                //            CId = insertCustomer.Id
        //                //        };
        //                //        InitEntity(insertFee);
        //                //        insertFees.Add(insertFee);
        //                //    }

        //                //}
        //                //Base_User user = users.Where(t => t.RealName.Contains(relationName)).FirstOrDefault();
        //                //tbasecustomerrelation insertRelation = new tbasecustomerrelation()
        //                //{
        //                //    UId = user.Id,
        //                //    DId = user.DepartmentId,
        //                //    CId = insertCustomer.Id,
        //                //};
        //                //InitEntity(insertRelation);
        //                //insertRelations.Add(insertRelation);
        //            }
        //        }
        //        await Db.InsertAsync(insertCustomers);
        //        await Db.InsertAsync(insertContacts);
        //        await Db.InsertAsync(insertFees);
        //        await Db.InsertAsync(insertRelations);
        //        await Db.UpdateAsync(updateContacts);
        //        await Db.UpdateAsync(updateFees);
        //        await Db.UpdateAsync(updateRelations);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.LogInformation(ex.Message);
        //    }
            
        //}
        #endregion

        #region 私有成员

        #endregion
    }
}