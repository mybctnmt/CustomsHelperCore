using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Coldairarrow.Business.Inbox
{
    public class tinboxcontentBusiness : BaseBusiness<tinboxcontent>, ItinboxcontentBusiness, ITransientDependency
    {
        public IOperator _operator { get; set; }
        public IDbAccessor _db { get; set; }
        public tinboxcontentBusiness(IDbAccessor db, IOperator @operator)
            : base(db)
        {
            _db = db;
            _operator = @operator;
        }

        #region 外部接口

        public async Task<PageResult<tinboxcontent>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tinboxcontent>();
            var search = input.Search;


            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tinboxcontent, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition} = @0", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tinboxcontent> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> AddDataAsync(tinboxcontent data)
        {
            await InsertAsync(data);
            return data.Id;
        }

        public async Task<string> UpdateDataAsync(tinboxcontent data)
        {
            await UpdateAsync(data);
            return data.Id;
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<tinboxcontent> GetOneData(string email)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tinboxcontent>();
            where = where.And(p => p.Recipient == email);
            where = where.And(p => !string.IsNullOrEmpty(p.EmailId));
            return await q.Where(where).OrderByDescending(p => p.SendTime).FirstOrDefaultAsync();
        }
        public async Task<tinboxcontent> GetOneDataEmailId(string emailId, DateTime sendTime)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tinboxcontent>();

            where = where.And(p => p.EmailId == emailId);
            return await q.Where(where).OrderByDescending(p => p.SendTime).FirstOrDefaultAsync();
        }
        [Transactional]
        public async Task AddInboxInfoAsync(List<tinboxinfo> data)
        {
            foreach (var item in data)
            {
                List<tbasecustomercontacts> contacts = await Db.GetIQueryable<tbasecustomercontacts>().Where(x => x.Email == item.tinboxcontent.SenderEmailAddress && x.Name == item.tinboxcontent.SenderName).ToListAsync();
                tbasecustomer customer = new tbasecustomer();
                if (contacts.Count > 0)
                {
                    customer = await Db.GetIQueryable<tbasecustomer>().Where(x => x.Id == contacts[0].CId).FirstOrDefaultAsync();
                }
                if (item.IsSeperate == "1")
                {
                    string dec = item.Description ?? "";
                    string[] sArray = Regex.Split(dec, "\r\n|\r|\n", RegexOptions.IgnoreCase);

                    bool found = false; // 用来标记是否找到【提运单号】

                    for (int i = 0; i < sArray.Length; i++)
                    {
                        string pattern = @"【提运单号】(.*?)$";

                        // 检查当前行是否包含【提运单号】
                        Match match = Regex.Match(sArray[i], pattern, RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            if (!string.IsNullOrEmpty(item.BillNo))
                            {
                                string replacedItem = Regex.Replace(sArray[i], pattern, $"【提运单号】{item.BillNo}", RegexOptions.IgnoreCase);
                                sArray[i] = replacedItem;
                                found = true;
                            }
                        }
                    }
                    dec = string.Join("\r\n", sArray);
                    // 确保dec以换行符结束
                    if (!string.IsNullOrEmpty(dec) && !dec.EndsWith(Environment.NewLine))
                    {
                        dec += Environment.NewLine;
                    }
                    // 如果没有找到【提运单号】，则在字符串末尾添加
                    if (!found)
                    {
                        if (!string.IsNullOrEmpty(item.BillNo))
                        {
                            dec += $"【提运单号】{item.BillNo}";
                        }
                    }
                    item.Description = dec;
                }

                temailorder temailorder = new temailorder
                {
                    Id = IdHelper.GetId(),
                    ContactId = contacts.Count > 0 ? contacts[0].Id : null,
                    ContactName = contacts.Count > 0 ? contacts[0].Name : null,
                    OperatorId = _operator.Property.Id,
                    OperatorName = _operator.Property.RealName,
                    InboxId = item.tinboxcontent.Id,
                    OrderNo = "HTL" + DateTime.Now.ToString("yyyyMMddHHmmssffffff"),
                    Subject = item.tinboxcontent.Subject,
                    SendTime = item.tinboxcontent.SendTime,
                    RevisionNo = "0",
                    CustomerId = customer?.Id,
                    CustomerShortName = customer?.CustomerShortName,
                    IsEntryClerk = "0",
                    IsReviewer = "0",
                    IsVerifier = "0",
                    IsConfirmOrder = "0",
                    CreateTime = DateTime.Now,
                    CreatorId = _operator.UserId,
                    IsUrgent = item.IsUrgent,
                    IsManual = 1,
                    Description = item.Description
                };

                await Db.InsertAsync<temailorder>(temailorder);
                await Db.InsertAsync<tinboxcontent>(item.tinboxcontent);
                await Db.InsertAsync<tinboxattachment>(item.tinboxattachments);
            }

        }
        #endregion

        #region 私有成员

        #endregion
    }
}