using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public class tdecheadBusiness : BaseBusiness<tdechead>, ItdecheadBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public IDbAccessor _db;
        public temailorderBusiness _temailorder;
        public IOperator _operator;
        public tdecheadBusiness(IDbAccessor db, temailorderBusiness temailorder, IOperator @operator, IConnectionMultiplexer redis)
            : base(db)
        {
            _temailorder = temailorder;
            _db = db;
            _operator = @operator;
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tdechead>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tdechead>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tdechead, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition} == (@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tdechead> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tdechead data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tdechead data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        [Transactional]
        public async Task AddDecInfoAsync(tdecinfo tdecinfo, bool isExist)
        {
            temailorder temailorder = tdecinfo.temailorder;
            tdechead tdechead = tdecinfo.tdechead;
            tdeccoppromise tdeccoppromise = tdecinfo.tdeccoppromise;
            List<tdeclist> tdeclists = tdecinfo.tdeclists;
            List<tdeccontainer> tdeccontainers = tdecinfo.tdeccontainers;
            List<tdeclicensedocus> tdeclicensedocuses = tdecinfo.tdeclicensedocuses;
            List<tdecotherpack> tdecotherpacks = tdecinfo.tdecotherpacks;
            List<tedocrealation> tedocrealations = tdecinfo.tedocrealations;
            List<tdecuser> tdecusers = tdecinfo.tdecusers;
            List<tdeccoplimit> tdeccoplimits = tdecinfo.tdeccoplimits;
            List<tdecrequestcert> tdecrequestcerts = tdecinfo.tdecrequestcerts;
            List<tdecgoodslimit> tdecgoodslimits = tdecinfo.tdecgoodslimits;
            List<tdecgoodslimitvin> tdecgoodslimitvins = tdecinfo.tdecgoodslimitvins;
            tdecfreetxt tdecfreetxt = tdecinfo.tdecfreetxt;
            tdecsign tdecsign = tdecinfo.tdecsign;
            List<tinboxattachment> tinboxattachments = tdecinfo.tinboxattachments;
            if (isExist)
            {
                await _db.UpdateAsync<temailorder>(temailorder);
            }
            else
            {
                tbasecustomer tbasecustomer = _db.GetIQueryable<tbasecustomer>().Where(x => x.CustomerName == tdechead.TradeName).FirstOrDefault();
                tbasecustomercontacts tbasecustomercontacts = new tbasecustomercontacts();
                if (tbasecustomer != null)
                {
                    tbasecustomercontacts = _db.GetIQueryable<tbasecustomercontacts>().Where(x => x.CId == tbasecustomer.Id).FirstOrDefault();
                }
                tinboxconfig tinboxconfig = _db.GetIQueryable<tinboxconfig>().Where(x => x.UserId == _operator.UserId).FirstOrDefault();
                tinboxcontent tinboxcontent = new tinboxcontent();
                tinboxcontent.Id = IdHelper.GetId();
                tinboxcontent.SenderName = tbasecustomercontacts?.Name;
                tinboxcontent.SenderEmailAddress = tbasecustomercontacts?.Email;
                tinboxcontent.SendTime = DateTime.Now;
                tinboxcontent.Subject = temailorder.Subject;
                tinboxcontent.Recipient = tinboxconfig?.EmailAddress;
                tinboxcontent.OperationStatus = "已生成";
                tinboxcontent.HasAttachment = "否";
                await _db.InsertAsync<tinboxcontent>(tinboxcontent);
                temailorder.CustomerId = tbasecustomer?.Id;
                temailorder.CustomerShortName = tbasecustomer?.CustomerShortName;
                temailorder.ContactId = tbasecustomercontacts?.Id;
                temailorder.ContactName = tbasecustomercontacts?.Name;
                temailorder.InboxId = tinboxcontent.Id;
                await _db.InsertAsync<temailorder>(temailorder);
            }
            await _db.InsertAsync<tdechead>(tdechead);
            await _db.InsertAsync<tdeclist>(tdeclists);
            await _db.InsertAsync<tdeccontainer>(tdeccontainers);
            await _db.InsertAsync<tdeclicensedocus>(tdeclicensedocuses);
            await _db.InsertAsync<tdecotherpack>(tdecotherpacks);
            await _db.InsertAsync<tedocrealation>(tedocrealations);
            await _db.InsertAsync<tdecuser>(tdecusers);
            await _db.InsertAsync<tdeccoplimit>(tdeccoplimits);
            await _db.InsertAsync<tdecrequestcert>(tdecrequestcerts);
            await _db.InsertAsync<tdecgoodslimit>(tdecgoodslimits);
            await _db.InsertAsync<tdecgoodslimitvin>(tdecgoodslimitvins);
            await _db.InsertAsync<tdecfreetxt>(tdecfreetxt);
            await _db.InsertAsync<tdecsign>(tdecsign);
            if (tdeccoppromise != null && !string.IsNullOrEmpty(tdeccoppromise.DeclaratioMaterialCode))
            { await _db.InsertAsync<tdeccoppromise>(tdeccoppromise); }
            string inboxId = temailorder.InboxId;
            if (!inboxId.IsNullOrEmpty())
            {
                await _db.DeleteAsync<tinboxattachment>(t => t.InboxId == inboxId);
                foreach (var tinboxattachment in tinboxattachments)
                {
                    tinboxattachment.InboxId = inboxId;
                }
                await _db.InsertAsync<tinboxattachment>(tinboxattachments);
            }
        }

        [Transactional]
        public async Task UpdateDecInfoAsync(tdecinfo tdecinfo, bool isExist)
        {
            temailorder temailorder = tdecinfo.temailorder;
            tdechead tdechead = tdecinfo.tdechead;

            await _db.DeleteAsync<tdechead>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdeclist>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdeccontainer>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdeclicensedocus>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecotherpack>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tedocrealation>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecuser>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdeccoplimit>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecrequestcert>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecgoodslimit>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecgoodslimitvin>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecfreetxt>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdecsign>(t => t.OrderNo == tdechead.OrderNo);
            await _db.DeleteAsync<tdeccoppromise>(t => t.OrderNo == tdechead.OrderNo);
            string inboxId = temailorder.InboxId;
            List<tdeclist> tdeclists = tdecinfo.tdeclists;
            List<tdeccontainer> tdeccontainers = tdecinfo.tdeccontainers;
            List<tdeclicensedocus> tdeclicensedocuses = tdecinfo.tdeclicensedocuses;
            List<tdecotherpack> tdecotherpacks = tdecinfo.tdecotherpacks;
            List<tedocrealation> tedocrealations = tdecinfo.tedocrealations;
            List<tdecuser> tdecusers = tdecinfo.tdecusers;
            List<tdeccoplimit> tdeccoplimits = tdecinfo.tdeccoplimits;
            List<tdecrequestcert> tdecrequestcerts = tdecinfo.tdecrequestcerts;
            List<tdecgoodslimit> tdecgoodslimits = tdecinfo.tdecgoodslimits;
            List<tdecgoodslimitvin> tdecgoodslimitvins = tdecinfo.tdecgoodslimitvins;
            tdecfreetxt tdecfreetxt = tdecinfo.tdecfreetxt;
            tdecsign tdecsign = tdecinfo.tdecsign;
            tdeccoppromise tdeccoppromise = tdecinfo.tdeccoppromise;
            List<tinboxattachment> tinboxattachments = tdecinfo.tinboxattachments;
            if (isExist)
            {
                await _db.UpdateAsync<temailorder>(temailorder);
            }
            else
            {
                tbasecustomer tbasecustomer = _db.GetIQueryable<tbasecustomer>().Where(x => x.CustomerName == tdechead.TradeName).FirstOrDefault();
                tbasecustomercontacts tbasecustomercontacts = new tbasecustomercontacts();
                if (tbasecustomer != null)
                {
                    tbasecustomercontacts = _db.GetIQueryable<tbasecustomercontacts>().Where(x => x.CId == tbasecustomer.Id).FirstOrDefault();
                }
                tinboxconfig tinboxconfig = _db.GetIQueryable<tinboxconfig>().Where(x => x.UserId == _operator.UserId).FirstOrDefault();
                tinboxcontent tinboxcontent = new tinboxcontent();
                tinboxcontent.Id = IdHelper.GetId();
                tinboxcontent.SenderName = tbasecustomercontacts?.Name;
                tinboxcontent.SenderEmailAddress = tbasecustomercontacts?.Email;
                tinboxcontent.SendTime = DateTime.Now;
                tinboxcontent.Subject = temailorder.Subject;
                tinboxcontent.Recipient = tinboxconfig?.EmailAddress;
                tinboxcontent.OperationStatus = "已生成";
                tinboxcontent.HasAttachment = "否";
                await _db.InsertAsync<tinboxcontent>(tinboxcontent);
                temailorder.CustomerId = tbasecustomer.Id;
                temailorder.CustomerShortName = tbasecustomer.CustomerShortName;
                temailorder.ContactId = tbasecustomercontacts?.Id;
                temailorder.ContactName = tbasecustomercontacts?.Name;
                temailorder.InboxId = tinboxcontent.Id;
                await _db.InsertAsync<temailorder>(temailorder);
            }
            await _db.InsertAsync<tdechead>(tdechead);
            await _db.InsertAsync<tdeclist>(tdeclists);
            await _db.InsertAsync<tdeccontainer>(tdeccontainers);
            await _db.InsertAsync<tdeclicensedocus>(tdeclicensedocuses);
            await _db.InsertAsync<tdecotherpack>(tdecotherpacks);
            await _db.InsertAsync<tedocrealation>(tedocrealations);
            await _db.InsertAsync<tdecuser>(tdecusers);
            await _db.InsertAsync<tdeccoplimit>(tdeccoplimits);
            await _db.InsertAsync<tdecrequestcert>(tdecrequestcerts);
            await _db.InsertAsync<tdecgoodslimit>(tdecgoodslimits);
            await _db.InsertAsync<tdecgoodslimitvin>(tdecgoodslimitvins);
            await _db.InsertAsync<tdecfreetxt>(tdecfreetxt);
            await _db.InsertAsync<tdecsign>(tdecsign);
            if (tdeccoppromise != null && !string.IsNullOrEmpty(tdeccoppromise.DeclaratioMaterialCode))
            { await _db.InsertAsync<tdeccoppromise>(tdeccoppromise); }
            if (!inboxId.IsNullOrEmpty())
            {
                await _db.DeleteAsync<tinboxattachment>(t => t.InboxId == inboxId);
                foreach (var tinboxattachment in tinboxattachments)
                {
                    tinboxattachment.InboxId = inboxId;
                }
                await _db.InsertAsync<tinboxattachment>(tinboxattachments);
            }
        }

        protected void InitEntity(object obj)//初始化实体对象的
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

        [Transactional]//事务上下文中执行的
        public async Task SaveDecInfoAsync(tdecinfo tdecinfo)
        {
            temailorder temailorder = tdecinfo.temailorder;
            tdechead tdechead = tdecinfo.tdechead;
            List<tdeclist> tdeclists = tdecinfo.tdeclists;
            List<tdeccontainer> tdeccontainers = tdecinfo.tdeccontainers;
            List<tdeclicensedocus> tdeclicensedocuses = tdecinfo.tdeclicensedocuses;
            List<tdecotherpack> tdecotherpacks = tdecinfo.tdecotherpacks;
            List<tedocrealation> tedocrealations = tdecinfo.tedocrealations;
            List<tdecuser> tdecusers = tdecinfo.tdecusers;
            List<tdeccoplimit> tdeccoplimits = tdecinfo.tdeccoplimits;
            List<tdecrequestcert> tdecrequestcerts = tdecinfo.tdecrequestcerts;
            List<tdecgoodslimit> tdecgoodslimits = tdecinfo.tdecgoodslimits;
            List<tdecgoodslimitvin> tdecgoodslimitvins = tdecinfo.tdecgoodslimitvins;
            tdecfreetxt tdecfreetxt = tdecinfo.tdecfreetxt;
            tdeccoppromise tdeccoppromise = tdecinfo.tdeccoppromise;
            tdecsign tdecsign = tdecinfo.tdecsign;
            List<tinboxattachment> tinboxattachments = tdecinfo.tinboxattachments;

            bool isExist = true;

            temailorder emailorder = _db.GetIQueryable<temailorder>().Where(t => t.OrderNo == temailorder.OrderNo).FirstOrDefault();//从数据库中获取一个名为 temailorder 的实体对象
            if (emailorder == null)
            {
                InitEntity(temailorder);
                isExist = false;
            }

            InitEntity(tdechead);
            InitEntity(tdeccoppromise);
            foreach (var tdeccontainer in tdeccontainers)
            {
                InitEntity(tdeccontainer);
            }
            foreach (var tdeclicensedocus in tdeclicensedocuses)
            {
                InitEntity(tdeclicensedocus);
            }
            foreach (var tdecotherpack in tdecotherpacks)
            {
                InitEntity(tdecotherpack);
            }
            foreach (var tedocrealation in tedocrealations)
            {
                InitEntity(tedocrealation);
            }
            foreach (var tinboxattachment in tinboxattachments)
            {
                InitEntity(tinboxattachment);
            }
            foreach (var tdecuser in tdecusers)
            {
                InitEntity(tdecuser);
            }
            foreach (var tdeccoplimit in tdeccoplimits)
            {
                InitEntity(tdeccoplimit);
            }
            foreach (var tdecrequestcert in tdecrequestcerts)
            {
                InitEntity(tdecrequestcert);
            }
            foreach (var tdeclist in tdeclists)
            {
                var limits = tdecgoodslimits.Where(x => x.GoodsId == tdeclist.Id).ToList();
                InitEntity(tdeclist);
                List<tdecgoodslimitvin> newtdecgoodslimitvins = new List<tdecgoodslimitvin>();
                foreach (var tdecgoodslimit in limits)
                {
                    tdecgoodslimit.GoodsId = tdeclist.Id;
                    List < tdecgoodslimitvin > vins = tdecgoodslimitvins.Where(x => x.GoodsLimitId == tdecgoodslimit.Id).ToList();
                    InitEntity(tdecgoodslimit);

                    vins.ForEach(x =>
                    {
                        InitEntity(x);
                        x.GoodsLimitId = tdecgoodslimit.Id;
                    });
                    newtdecgoodslimitvins.AddRange(vins);
                }
                tdecinfo.tdecgoodslimitvins = newtdecgoodslimitvins;
            }
            InitEntity(tdecfreetxt);
            InitEntity(tdecsign);

            bool isTdechead = _db.GetIQueryable<tdechead>().Where(t => t.OrderNo == tdechead.OrderNo).Any();
            if (isTdechead)
            {
                string orderNo = tdechead.OrderNo;
                await _db.DeleteSqlAsync<tdechead>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdeclist>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdeccontainer>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdeclicensedocus>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdecotherpack>(t => t.OrderNo == orderNo);
                if (temailorder.EntrustedStatus != "2" && temailorder.EntrustedStatus != "0" && !string.IsNullOrEmpty(temailorder.EntrustedStatus))
                {
                    await _db.DeleteSqlAsync<tedocrealation>(t => t.OrderNo == orderNo && t.EdocCode != "10000001");
                }
                else
                {
                    await _db.DeleteSqlAsync<tedocrealation>(t => t.OrderNo == orderNo);
                }
                await _db.DeleteSqlAsync<tdecuser>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdeccoplimit>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdecrequestcert>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdecgoodslimit>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdecgoodslimitvin>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdecfreetxt>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdecsign>(t => t.OrderNo == orderNo);
                await _db.DeleteSqlAsync<tdeccoppromise>(t => t.OrderNo == orderNo);
            }
            if (tdechead != null)
            {
                temailorder.CusDecStatus = tdechead.CusDecStatus;
                temailorder.CusDecStatusName = tdechead.CusDecStatusName;
            }
            if (isExist)
            {
                if (temailorder.EntrustedStatus != "2" && temailorder.EntrustedStatus != "0" && !string.IsNullOrEmpty(temailorder.EntrustedStatus))
                {
                    temailorder.EntrustedStatus = emailorder.EntrustedStatus;
                    temailorder.EntrustedReason = emailorder.EntrustedReason;
                }
                emailorder.CusDecStatus = temailorder.CusDecStatus;
                emailorder.CusDecStatusName = temailorder.CusDecStatusName;
                emailorder.EntrustedReason = temailorder.EntrustedReason;
                emailorder.EntrustedStatus = temailorder.EntrustedStatus;
                emailorder.CheckResult = temailorder.CheckResult;
                emailorder.Feedback = temailorder.Feedback;
                temailorder = emailorder;
                await _db.UpdateAsync<temailorder>(emailorder);
            }
            else
            {
                tbasecustomer tbasecustomer = _db.GetIQueryable<tbasecustomer>().Where(x => x.CustomerName == tdechead.TradeName).FirstOrDefault();
                tbasecustomercontacts tbasecustomercontacts = new tbasecustomercontacts();
                if (tbasecustomer != null)
                {
                    tbasecustomercontacts = _db.GetIQueryable<tbasecustomercontacts>().Where(x => x.CId == tbasecustomer.Id).FirstOrDefault();
                }
                tinboxconfig tinboxconfig = _db.GetIQueryable<tinboxconfig>().Where(x => x.UserId == _operator.UserId).FirstOrDefault();
                tinboxcontent tinboxcontent = new tinboxcontent();
                tinboxcontent.Id = IdHelper.GetId();
                tinboxcontent.SenderName = tbasecustomercontacts?.Name;
                tinboxcontent.SenderEmailAddress = tbasecustomercontacts?.Email;
                tinboxcontent.SendTime = DateTime.Now;
                tinboxcontent.Subject = temailorder.Subject;
                tinboxcontent.Recipient = tinboxconfig?.EmailAddress;
                tinboxcontent.OperationStatus = "已生成";
                tinboxcontent.HasAttachment = "否";
                await _db.InsertAsync<tinboxcontent>(tinboxcontent);
                temailorder.CustomerId = tbasecustomer?.Id;
                temailorder.CustomerShortName = tbasecustomer?.CustomerShortName;
                temailorder.ContactId = tbasecustomercontacts?.Id;
                temailorder.ContactName = tbasecustomercontacts?.Name;
                temailorder.InboxId = tinboxcontent.Id;
                await _db.InsertAsync<temailorder>(temailorder);
            }
            await _db.InsertAsync<tdechead>(tdechead);
            await _db.InsertAsync<tdeclist>(tdeclists);
            await _db.InsertAsync<tdeccontainer>(tdeccontainers);
            await _db.InsertAsync<tdeclicensedocus>(tdeclicensedocuses);
            await _db.InsertAsync<tdecotherpack>(tdecotherpacks);
            await _db.InsertAsync<tedocrealation>(tedocrealations);
            await _db.InsertAsync<tdecuser>(tdecusers);
            await _db.InsertAsync<tdeccoplimit>(tdeccoplimits);
            await _db.InsertAsync<tdecrequestcert>(tdecrequestcerts);
            await _db.InsertAsync<tdecgoodslimit>(tdecgoodslimits);
            await _db.InsertAsync<tdecgoodslimitvin>(tdecgoodslimitvins);
            await _db.InsertAsync<tdecfreetxt>(tdecfreetxt);
            await _db.InsertAsync<tdecsign>(tdecsign);
            if (tdeccoppromise != null && !string.IsNullOrEmpty(tdeccoppromise.DeclaratioMaterialCode))
            { await _db.InsertAsync<tdeccoppromise>(tdeccoppromise); }
            string inboxId = temailorder.InboxId;
            if (!inboxId.IsNullOrEmpty())
            {
                await _db.DeleteAsync<tinboxattachment>(t => t.InboxId == inboxId);
                foreach (var tinboxattachment in tinboxattachments)
                {
                    tinboxattachment.InboxId = inboxId;
                }
                await _db.InsertAsync<tinboxattachment>(tinboxattachments);
            }
        }
        #endregion

        #region 私有成员

        #endregion
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);
        /// <summary>
        /// 查询接口获取数据 更改插入head
        /// </summary>
        /// <param name="orderlist"></param>
        /// <returns></returns>
        [Transactional]
        public async Task<string> SWBGDataSelect(List<tdechead> orderlist)
        {
            // 等待信号量以确保并发控制
            await semaphore.WaitAsync();
            try
            {
                // 用于存储需要更新和插入的记录
                List<tdechead> updateheadlist = new List<tdechead>();
                List<tdechead> insertheadlist = new List<tdechead>();
                List<temailorder> insertemaillist = new List<temailorder>();

                // 遍历每一个传入的订单记录
                foreach (tdechead selecthead in orderlist)
                {
                    // 获取查询的 IQueryable 对象
                    var q = GetIQueryable();
                    var where = LinqHelper.True<tdechead>();

                    // 构建筛选条件
                    where = where.And(DynamicExpressionParser.ParseLambda<tdechead, bool>(ParsingConfig.Default, false, $@"{"SeqNo"} == (@0)", selecthead.SeqNo));

                    // 如果订单号不为空，则需要额外处理
                    if (!string.IsNullOrEmpty(selecthead.OrderNo))
                    {
                        // 查询相关的邮件记录
                        var query = from a in _db.GetIQueryable<tdechead>()
                                    join b in _db.GetIQueryable<temailorder>() on a.OrderNo equals b.OrderNo into ab
                                    from b in ab.DefaultIfEmpty()
                                    select new EmailOrderDto
                                    {
                                        OrderNo = a.OrderNo,
                                        Subject = b.Subject,
                                        SeqNo = a.SeqNo
                                    };

                        // 查找对应的邮件记录
                        EmailOrderDto email = query.Where(x => x.SeqNo == selecthead.SeqNo && x.Subject == "单一窗口自动生成").FirstOrDefault();
                        if (email != null)
                        {
                            // 删除已存在的邮件记录
                            await _temailorder.DeleteDocAsync(new List<string>() { email.OrderNo }, "3");
                        }
                        // 追加订单号的筛选条件
                        where = where.And(DynamicExpressionParser.ParseLambda<tdechead, bool>(ParsingConfig.Default, false, $@"{"OrderNo"} == (@0)", selecthead.OrderNo));
                    }

                    // 查询数据库中符合条件的记录
                    List<tdechead> heads = await q.Where(where).ToListAsync();
                    if (heads != null && heads.Any())
                    {
                        // 更新已有记录的字段
                        heads.ForEach(x =>
                        {
                            x.BillNo = selecthead.BillNo ?? x.BillNo;
                            x.CusDecStatus = selecthead.CusDecStatus ?? x.CusDecStatus;
                            x.CusDecStatusName = selecthead.CusDecStatusName ?? x.CusDecStatusName;
                            x.EncryptString = selecthead.EncryptString ?? x.EncryptString;

                            // 检查相关的邮件记录是否存在
                            var alemail = _db.GetIQueryable<temailorder>().FirstOrDefault(t => t.OrderNo == x.OrderNo);
                            if (alemail == null)
                            {
                                // 如果邮件记录不存在，则添加新邮件记录
                                temailorder email = new temailorder
                                {
                                    Id = IdHelper.GetId(),
                                    OrderNo = x.OrderNo,
                                    OperatorId = _operator.UserId,
                                    CreateTime = DateTime.Now,
                                    CreatorId = _operator.UserId,
                                    OperatorName = _operator.Property.RealName,
                                    SendTime = DateTime.Now,
                                    InboxId = IdHelper.GetId(),
                                    IsEntryClerk = "1",
                                    IsReviewer = "1",
                                    IsVerifier = "1",
                                    Subject = "单一窗口自动生成",
                                    CusDecStatus = selecthead.CusDecStatus,
                                    CusDecStatusName = selecthead.CusDecStatusName
                                };
                                insertemaillist.Add(email);
                            }
                        });
                        updateheadlist.AddRange(heads);
                    }
                    else if (selecthead.OrderNo.IsNullOrEmpty())
                    {
                        // 如果订单号为空，则生成新的订单号并添加到插入列表中
                        selecthead.OrderNo = _temailorder.GetOrderNo().Result;
                        insertheadlist.Add(selecthead);

                        temailorder email = new temailorder
                        {
                            Id = IdHelper.GetId(),
                            OrderNo = selecthead.OrderNo,
                            OperatorId = _operator.UserId,
                            CreateTime = DateTime.Now,
                            OperatorName = _operator.Property.RealName,
                            CreatorId = _operator.UserId,
                            InboxId = IdHelper.GetId(),
                            SendTime = DateTime.Now,
                            IsEntryClerk = "1",
                            IsReviewer = "1",
                            IsVerifier = "1",
                            Subject = "单一窗口自动生成",
                            CusDecStatus = selecthead.CusDecStatus,
                            CusDecStatusName = selecthead.CusDecStatusName
                        };
                        insertemaillist.Add(email);
                    }
                    else
                    {
                        // 订单号已存在，但未在数据库中找到记录，则直接插入
                        insertheadlist.Add(selecthead);
                    }
                }

                try
                {
                    // 执行数据库更新操作
                    if (updateheadlist.Count > 0)
                        await UpdateAsync(updateheadlist);
                    if (insertheadlist.Count > 0)
                        await InsertAsync(insertheadlist);
                    if (insertemaillist.Count > 0)
                        await _db.InsertAsync<temailorder>(insertemaillist);
                }
                catch (Exception ex)
                {
                    // 捕获并抛出异常
                    throw ex;
                }

                // 返回修改和插入的记录数量
                return "修改条数：" + updateheadlist.Count + "、插入条数：" + insertheadlist.Count;
            }
            finally
            {
                // 释放信号量
                semaphore.Release();
            }
        }

        public async Task<List<DeclarationListDto>> GetDataListWhereAsync(List<ConditionDTO> searchs)
        {
            try
            {
                var q = GetIQueryable();
                var where = LinqHelper.True<DeclarationListDto>();


                foreach (ConditionDTO search in searchs)
                {
                    //筛选
                    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                    {
                        string expression = $@"{search.Condition} == (@0)";
                        if (search.Condition.Equals("StartTime"))
                        {
                            expression = $@"{"UpdateTime"}>=@0";
                        }
                        if (search.Condition.Equals("EndTime"))
                        {
                            expression = $@"{"UpdateTime"}<@0";
                        }
                        if (search.Condition.Equals("CreateTime"))
                        {
                            expression = $@"{"CreateTime"}>@0";
                            search.Keyword = DateTime.Now.Date.AddDays(-(Convert.ToInt32(search.Keyword))).ToString();
                        }
                        var newWhere = DynamicExpressionParser.ParseLambda<DeclarationListDto, bool>(
                            ParsingConfig.Default, false, expression, search.Keyword);
                        where = where.And(newWhere);

                    }
                }
                var query2 = from item in
                                 (
                                 from h in _db.GetIQueryable<tdechead>()
                                 join l in _db.GetIQueryable<tdeclist>() on h.OrderNo equals l.OrderNo into hl
                                 from g in hl.DefaultIfEmpty()
                                 join e in _db.GetIQueryable<temailorder>() on h.OrderNo equals e.OrderNo into he
                                 from g2 in he.DefaultIfEmpty()
                                 select new
                                 {
                                     h.TrafName,
                                     h.EncryptString,
                                     h.Id,
                                     h.CusVoyageNo,
                                     h.SeqNo,
                                     h.BillNo,
                                     h.OrderNo,
                                     h.OwnerCode,
                                     h.IEFlag,
                                     h.OwnerName,
                                     h.EntryId,
                                     h.CreateTime,
                                     h.CreatorId,
                                     h.ManualNo,
                                     h.CusDecStatusName,
                                     h.CusDecStatus,
                                     h.TradeName,
                                     g2.CustomerShortName,
                                     g2.CustomerId,
                                     h.DDate,
                                     g2.InboxId,
                                     g2.Subject,
                                     g2.OperatorId,
                                     g2.Remark
                                 }
                             )
                             group item by item.OrderNo into gGroup
                             select new DeclarationListDto
                             {
                                 OrderNo = gGroup.Key,
                                 Id = gGroup.Max(o => o.Id),
                                 SeqNo = gGroup.Max(o => o.SeqNo),
                                 CreatorId = gGroup.Max(o => o.CreatorId),
                                 CreateTime = gGroup.Max(o => o.CreateTime),
                                 EntryId = gGroup.Max(o => o.EntryId),
                                 BillNo = gGroup.Max(o => o.BillNo),
                                 ManualNo = gGroup.Max(o => o.ManualNo),
                                 OwnerCode = gGroup.Max(o => o.OwnerCode),
                                 OwnerName = gGroup.Max(o => o.OwnerName),
                                 TradeName = gGroup.Max(o => o.TradeName),
                                 CustomerShortName = gGroup.Max(o => o.CustomerShortName),
                                 CustomerId = gGroup.Max(o => o.CustomerId),
                                 IEFlag = gGroup.Max(o => o.IEFlag),
                                 DDate = gGroup.Max(o => o.DDate),
                                 Remark = gGroup.Max(o => o.Remark),
                                 CusDecStatusName = gGroup.Max(o => o.CusDecStatusName),
                                 CusDecStatus = gGroup.Max(o => o.CusDecStatus),
                                 GoodsCount = gGroup.Count(),
                                 InboxId = gGroup.Max(o => o.InboxId),
                                 EncryptString = gGroup.Max(o => o.EncryptString),
                                 CusVoyageNo = gGroup.Max(o => o.CusVoyageNo),
                                 TrafName = gGroup.Max(o => o.TrafName),
                             };
                return await query2.Where(where).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<QuickEntryDto>> GetQuickEntryAsync(List<ConditionDTO> searchs)
        {
            try
            {
                var q = GetIQueryable();
                var where = LinqHelper.True<QuickEntryDto>();


                foreach (ConditionDTO search in searchs)
                {
                    //筛选
                    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                    {
                        string expression = $@"{search.Condition}.Contains(@0)";
                        if (search.Condition.Equals("StartTime"))
                        {
                            expression = $@"{"UpdateTime"}>=@0";
                        }
                        if (search.Condition.Equals("EndTime"))
                        {
                            expression = $@"{"UpdateTime"}<@0";
                        }
                        if (search.Condition.Equals("CreateTime"))
                        {
                            expression = $@"{"CreateTime"}>@0";
                            search.Keyword = DateTime.Now.Date.AddDays(-(Convert.ToInt32(search.Keyword))).ToString();
                        }
                        if (search.Condition.Equals("TradeCode"))
                        {
                            expression = $@"{"TradeCode"}=@0";
                        }
                        if (search.Condition.Equals("SeqNo"))
                        {
                            expression = $@"{"SeqNo"}=@0";
                        }
                        if (search.Condition.Equals("BillNo"))
                        {
                            expression = $@"{"BillNo"}=@0";
                        }
                        var newWhere = DynamicExpressionParser.ParseLambda<QuickEntryDto, bool>(
                            ParsingConfig.Default, false, expression, search.Keyword);
                        where = where.And(newWhere);

                    }
                }
                var query = from l in _db.GetIQueryable<tdeclist>()
                            join e in _db.GetIQueryable<temailorder>() on l.OrderNo equals e.OrderNo into el
                            from e in el.DefaultIfEmpty()
                            join h in _db.GetIQueryable<tdechead>() on l.OrderNo equals h.OrderNo into hl
                            from g in hl.DefaultIfEmpty()
                            select new QuickEntryDto
                            {
                                IEFlag = g.IEFlag,
                                OverseasConsignorEname = g.OverseasConsignorEname,
                                OverseasConsigneeEname = g.OverseasConsigneeEname,
                                TradeCode = g.TradeCode,
                                TradeName = g.TradeName,
                                EntryId = g.EntryId,
                                ManualNo = g.ManualNo,
                                DDate = g.DDate,
                                OwnerCode = g.OwnerCode,
                                OwnerName = g.OwnerName,
                                SeqNo = g.SeqNo,
                                BillNo = g.BillNo,
                                ClassMark = l.ClassMark,
                                CodeTS = l.CodeTS,
                                ContrItem = l.ContrItem,
                                DeclPrice = l.DeclPrice,
                                DeclTotal = l.DeclTotal,
                                DutyMode = l.DutyMode,
                                ExgNo = l.ExgNo,
                                ExgVersion = l.ExgVersion,
                                Factor = l.Factor,
                                FirstUnit = l.FirstUnit,
                                FirstQty = l.FirstQty,
                                GUnit = l.GUnit,
                                GModel = l.GModel,
                                GName = l.GName,
                                GNo = l.GNo,
                                GQty = l.GQty,
                                OriginCountry = l.OriginCountry,
                                SecondUnit = l.SecondUnit,
                                SecondQty = l.SecondQty,
                                TradeCurr = l.TradeCurr,
                                UseTo = l.UseTo,
                                WorkUsd = l.WorkUsd,
                                DestinationCountry = l.DestinationCountry,
                                CiqCode = l.CiqCode,
                                DeclGoodsEname = l.DeclGoodsEname,
                                OrigPlaceCode = l.OrigPlaceCode,
                                Purpose = l.Purpose,
                                ProdValidDt = l.ProdValidDt,
                                ProdQgp = l.ProdQgp,
                                GoodsAttr = l.GoodsAttr,
                                Stuff = l.Stuff,
                                Uncode = l.Uncode,
                                DangName = l.DangName,
                                DangPackType = l.DangPackType,
                                DangPackSpec = l.DangPackSpec,
                                EngManEntCnm = l.EngManEntCnm,
                                NoDangFlag = l.NoDangFlag,
                                DestCode = l.DestCode,
                                GoodsSpec = l.GoodsSpec,
                                GoodsModel = l.GoodsModel,
                                GoodsBrand = l.GoodsBrand,
                                ProduceDate = l.ProduceDate,
                                ProdBatchNo = l.ProdBatchNo,
                                DistrictCode = l.DistrictCode,
                                CiqName = l.CiqName,
                                MnufctrRegno = l.MnufctrRegno,
                                MnufctrRegName = l.MnufctrRegName,
                                RcepOrigPlaceCode = l.RcepOrigPlaceCode,
                                Id = l.Id,
                                HId = g.Id,
                                TradeMode = g.TradeMode,
                                OrderNo = g.OrderNo,
                                FeeRate = g.FeeRate,
                                InsurRate = g.InsurRate,
                                OtherRate = g.OtherRate,
                                FeeMark = g.FeeMark,
                                InsurMark = g.InsurMark,
                                OtherMark = g.OtherMark,
                                FeeCurr = g.FeeCurr,
                                InsurCurr = g.InsurCurr,
                                OtherCurr = g.OtherCurr,
                                CustomerShortName = e.CustomerShortName
                            };
                var list = await query.Where(where).OrderByDescending(a => a.DDate).ToListAsync();

                var orderNos = list.Select(a => a.OrderNo).ToList();

                var tdecgoodslimits = _db.GetIQueryable<tdecgoodslimit>().Where(x => orderNos.Contains(x.OrderNo)).ToList();
                var tdecgoodslimitvins = _db.GetIQueryable<tdecgoodslimitvin>().Where(x => orderNos.Contains(x.OrderNo)).ToList();

                foreach (var item in list)
                {
                    item.Tdecgoodslimits = tdecgoodslimits.Where(x => x.OrderNo == item.OrderNo && x.GoodsNo == item.GNo).ToList();
                    item.Tdecgoodslimitvins = tdecgoodslimitvins.Where(x => x.OrderNo == item.OrderNo && item.Tdecgoodslimits.Select(x => x.Id).Contains(x.GoodsLimitId)).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询接口获取细表数据
        /// </summary>
        /// <param name="orderlist"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        [Transactional]
        public async Task<string> LoadingDels(List<DecHeadVo> orderlist, string userid)
        {
            try
            {
                DateTime dt = DateTime.Now;
                //获取细表给各个表赋值
                foreach (DecHeadVo del in orderlist)
                {
                    if (del.cusDecStatus == "1" && !del.isManualBind.HasValue)
                    {
                        continue;
                    }
                    //主表
                    tdechead head = _db.GetIQueryable<tdechead>().FirstOrDefault(x => x.OrderNo == del.orderNo);
                    /// <summary>
                    /// 申报单位代码
                    /// </summary>
                    head.AgentCode = del.agentCode;

                    /// <summary>
                    /// 申报单位名称
                    /// </summary>
                    head.AgentName = del.agentName;
                    ///航次号
                    head.CusVoyageNo = del.cusVoyageNo;

                    /// <summary>
                    /// 提单号
                    /// </summary>
                    head.BillNo = del.billNo ?? head.BillNo;

                    /// <summary>
                    /// 合同号
                    /// </summary>
                    head.ContrNo = del.contrNo;

                    /// <summary>
                    /// 录入单位代码
                    /// </summary>
                    head.CopCode = del.inputEtpsCode;

                    /// <summary>
                    /// 录入单位名称
                    /// </summary>
                    head.CopName = del.inputEtpsName;

                    /// <summary>
                    /// 主管海关（申报地海关）
                    /// </summary>
                    head.CustomMaster = del.customMaster;

                    /// <summary>
                    /// 征免性质
                    /// </summary>
                    head.CutMode = del.cutMode;



                    /// <summary>
                    /// 报关/转关关系标志
                    /// </summary>
                    head.DeclTrnRel = del.dclTrnRelFlag;

                    /// <summary>
                    /// 经停港/指运港
                    /// </summary>
                    head.DistinatePort = del.distinatePort;

                    if (del.cusDecStatus != "1" || !del.isManualBind.HasValue)
                    {
                        /// <summary>
                        /// 报关标志
                        /// </summary>
                        head.EdiId = del.ediId;
                    }

                    /// <summary>
                    /// 海关编号
                    /// </summary>
                    head.EntryId = del.entryId;

                    /// <summary>
                    /// 报关单类型
                    /// </summary>
                    head.EntryType = del.entryType;

                    /// <summary>
                    /// 运费币制
                    /// </summary>
                    head.FeeCurr = del.feeCurr;

                    /// <summary>
                    /// 运费标记
                    /// </summary>
                    head.FeeMark = del.feeMark;

                    /// <summary>
                    /// 运费／率
                    /// </summary>
                    head.FeeRate = del.feeRate != null ? Convert.ToDecimal(del.feeRate) : null;

                    /// <summary>
                    /// 毛重
                    /// </summary>
                    head.GrossWet = del.grossWt != null ? Convert.ToDecimal(del.grossWt) : null;

                    /// <summary>
                    /// 进出口日期
                    /// </summary>
                    head.IEDate = del.iEDate;

                    /// <summary>
                    /// 进出口标志
                    /// </summary>
                    head.IEFlag = del.cusIEFlag;

                    /// <summary>
                    /// 进出境关别
                    /// </summary>
                    head.IEPort = del.iEPort;

                    /// <summary>
                        /// 录入员名称
                    /// </summary>
                    head.InputerName = del.inputErName;

                    /// <summary>
                    /// 保险费币制
                    /// </summary>
                    head.InsurCurr = del.insurCurr;

                    /// <summary>
                    /// 保险费标记
                    /// </summary>
                    head.InsurMark = del.insurMark;

                    /// <summary>
                    /// 保险费／率
                    /// </summary>
                    head.InsurRate = del.insurRate != null ? Convert.ToDecimal(del.insurRate) : null;

                    /// <summary>
                    /// 许可证编号
                    /// </summary>
                    head.LicenseNo = del.licenseNo;

                    /// <summary>
                    /// 备案号
                    /// </summary>
                    head.ManualNo = del.manualNo;

                    /// <summary>
                    /// 净重
                    /// </summary>
                    head.NetWt = del.netWt != null ? Convert.ToDecimal(del.netWt) : null;

                    /// <summary>
                    /// 备注
                    /// </summary>
                    head.NoteS = del.noteS;

                    /// <summary>
                    /// 杂费币制
                    /// </summary>
                    head.OtherCurr = del.otherCurr;

                    /// <summary>
                    /// 杂费标志
                    /// </summary>
                    head.OtherMark = del.otherMark;

                    /// <summary>
                    /// 杂费／率
                    /// </summary>
                    head.OtherRate = del.otherRate != null ? Convert.ToDecimal(del.otherRate) : null;

                    /// <summary>
                    /// 消费使用/生产销售单位代码
                    /// </summary>
                    head.OwnerCode = del.ownerCode;

                    /// <summary>
                    /// 消费使用/生产销售单位名称
                    /// </summary>
                    head.OwnerName = del.ownerName;

                    /// <summary>
                    /// 件数
                    /// </summary>
                    head.PackNo = del.packNo != null ? Convert.ToInt32(del.packNo) : null;

                    /// <summary>
                    /// 申报人标识
                    /// </summary>
                    //head.PartenerID = del.

                    /// <summary>
                    /// 打印日期
                    /// </summary>
                    //head.PDate = del.pa

                    /// <summary>
                    /// 预录入编号
                    /// </summary>
                    head.PreEntryId = del.preEntryId;

                    /// <summary>
                    /// 风险评估参数
                    /// </summary>
                    //head.Risk = del.

                    /// <summary>
                    /// 数据中心统一编号
                    /// </summary>
                    head.SeqNo = del.cusCiqNo;

                    /// <summary>
                    /// 关联单据号
                    /// </summary>
                    //head.TgdNo = del.

                    /// <summary>
                    /// 启运国/运抵国
                    /// </summary>
                    head.TradeCountry = del.cusTradeCountry;

                    /// <summary>
                    /// 监管方式
                    /// </summary>
                    head.TradeMode = del.tradeModeCode;

                    /// <summary>
                    /// 境内收发货人编号
                    /// </summary>
                    head.TradeCode = del.cusIEFlag == "E" ? del.cnsnTradeCode : del.rcvgdTradeCode;

                    /// <summary>
                    /// 运输方式代码
                    /// </summary>
                    head.TrafMode = del.cusTrafMode;

                    /// <summary>
                    /// 运输工具代码及名称
                    /// </summary>
                    head.TrafName = del.trafName;

                    /// <summary>
                    /// 境内收发货人名称
                    /// </summary>
                    head.TradeName = del.cusIEFlag == "E" ? del.consignorCname : del.consigneeCname;

                    /// <summary>
                    /// 成交方式
                    /// </summary>
                    head.TransMode = del.transMode;

                    /// <summary>
                    /// 单据类型
                    /// </summary>
                    bool isSDWZH = false; bool isZZBS = false; bool isSYZZ = false; bool isZBZJ = false; bool isDBYF = false;


                    // 检查自报自缴是否存在
                    if (del.cusRemark.Length >= 1 && del.cusRemark[0] == '1')
                    {
                        isZBZJ = true;
                    }

                    // 检查水运中转是否存在
                    if (del.cusRemark.Length >= 4 && del.cusRemark[3] == '1')
                    {
                        isSYZZ = true;
                    }

                    // 检查担保验放是否存在
                    if (del.cusRemark.Length >= 6 && del.cusRemark[5] == '1')
                    {
                        isDBYF = true;
                    }

                    if (isZBZJ && isSDWZH)
                    {
                        head.Type = "ZW0000";
                    }
                    else if (isSDWZH)
                    {
                        head.Type = "SW0000";
                    }
                    else if (isZZBS)
                    {
                        head.Type = "ZB0000";
                    }
                    else if (isSYZZ)
                    {
                        head.Type = "SZ0000";
                    }
                    else if (isZBZJ)
                    {
                        head.Type = "Z00000";
                    }
                    else
                    {
                        head.Type = null;
                    }
                    if (isDBYF)
                    {
                        head.ChkSurety = "1";
                    }
                    else
                    {
                        head.ChkSurety = null;
                    }

                    /// <summary>
                    /// 录入员IC卡号
                    /// </summary>
                    head.TypistNo = del.typistNo;

                    /// <summary>
                    /// 包装种类
                    /// </summary>
                    head.WrapType = del.wrapType;

                    /// <summary>
                    /// 备案清单类型
                    /// </summary>
                    //head.BillType = del.

                    /// <summary>
                    /// 录入单位统一编码
                    /// </summary>
                    head.CopCodeScc = del.agentCode;

                    /// <summary>
                    /// 收发货人统一编码
                    /// </summary>
                    head.TradeCoScc = del.cusIEFlag == "E" ? del.cnsnTradeScc : del.rcvgdTradeScc;

                    /// <summary>
                    /// 申报代码统一编码
                    /// </summary>
                    head.AgentCodeScc = del.agentScc;

                    /// <summary>
                    /// 消费使用/生产销售单位单位统一编码
                    /// </summary>
                    head.OwnerCodeScc = del.ownerScc;

                    /// <summary>
                    /// 价格说明
                    /// </summary>
                    head.PromiseItmes = del.promiseItems;

                    /// <summary>
                    /// 贸易国别
                    /// </summary>
                    head.TradeAreaCode = del.cusTradeNationCode;

                    /// <summary>
                    /// 查验分流
                    /// </summary>
                    //head.CheckFlow = del.

                    /// <summary>
                    /// 税收征管标记
                    /// </summary>
                    //head.TaxAaminMark = del.

                    /// <summary>
                    /// 标记唛码
                    /// </summary>
                    head.MarkNo = del.markNo;

                    /// <summary>
                    /// 启运港代码
                    /// </summary>
                    head.DespPortCode = del.despPortCode;

                    /// <summary>
                    /// 入境口岸代码
                    /// </summary>
                    head.EntyPortCode = del.ciqEntyPortCode;

                    /// <summary>
                    /// 存放地点
                    /// </summary>
                    head.GoodsPlace = del.goodsPlace;

                    /// <summary>
                    /// B/L号
                    /// </summary>
                    //head.BLNo = del.

                    /// <summary>
                    /// 口岸检验检疫机关
                    /// </summary>
                    head.InspOrgCode = del.inspOrgCode;

                    /// <summary>
                    /// 特种业务标识
                    /// </summary>
                    if (del.specPassFlag.Length > 1)
                    {
                        // Concatenate the first character with the rest of the string, starting after the second character
                        string specPassFlag = del.specPassFlag.Substring(0, 1) + del.specPassFlag.Substring(2);

                        head.SpecDeclFlag = del.specDeclFlag + specPassFlag;
                    }

                    /// <summary>
                    /// 目的地检验检疫机关
                    /// </summary>
                    head.PurpOrgCode = del.purpOrgCode;

                    /// <summary>
                    /// 启运日期
                    /// </summary>
                    head.DespDate = del.despDate;

                    /// <summary>
                    /// 卸毕日期
                    /// </summary>
                    //head.CmplDschrgDt = del.

                    /// <summary>
                    /// 关联理由
                    /// </summary>
                    head.CorrelationReasonFlag = del.correlationReasonFlagName;

                    /// <summary>
                    /// 领证机关
                    /// </summary>
                    head.VsaOrgCode = del.vsaOrgCode;

                    /// <summary>
                    /// 原集装箱标识
                    /// </summary>
                    head.OrigBoxFlag = del.origBoxFlag;

                    if (del.cusDecStatus != "1" || !del.isManualBind.HasValue)
                    {
                        /// <summary>
                        /// 申报人员姓名
                        /// </summary>
                        head.DeclareName = del.inputErName;
                    }

                    /// <summary>
                    /// 无其他包装
                    /// </summary>
                    //head.NoOtherPack = del.

                    /// <summary>
                    /// 检验检疫受理机关
                    /// </summary>
                    head.OrgCode = del.orgCode;

                    /// <summary>
                    /// 境外发货人代码
                    /// </summary>
                    head.OverseasConsignorCode = del.consignorCode;

                    /// <summary>
                    /// 境外发货人代码
                    /// </summary>
                    head.OverseasConsigneeCode = del.consigneeCode;

                    /// <summary>
                    /// 境外收发货人名称
                    /// </summary>
                    head.OverseasConsignorCname = del.consignorCname;

                    /// <summary>
                    /// 境外发货人名称（外文）
                    /// </summary>
                    head.OverseasConsignorEname = del.consignorEname;

                    /// <summary>
                    /// 境外收发货人地址
                    /// </summary>
                    head.OverseasConsignorAddr = del.consignorAddr;

                    /// <summary>
                    /// 境外收货人编码
                    /// </summary>
                    //head.OverseasConsigneeCode = del.

                    /// <summary>
                    /// 境外收货人名称(外文)
                    /// </summary>
                    head.OverseasConsigneeEname = del.consigneeEname;

                    /// <summary>
                    /// 境内收发货人名称（外文）
                    /// </summary>
                    head.DomesticConsigneeEname = del.cusIEFlag == "E" ? null : del.consigneeEname;

                    /// <summary>
                    /// 关联号码
                    /// </summary>
                    head.CorrelationNo = del.correlationDeclNo;

                    /// <summary>
                    /// EDI申报备注
                    /// </summary>
                    //head.EdiRemark = del.

                    /// <summary>
                    /// EDI申报备注2
                    /// </summary>
                    head.EdiRemark2 = del.ediRemark2;

                    /// <summary>
                    /// 境内收发货人检验检疫编码
                    /// </summary>
                    head.TradeCiqCode = del.cusIEFlag == "E" ? del.consignorCode : del.consigneeCode;

                    /// <summary>
                    /// 消费使用/生产销售单位检验检疫编码
                    /// </summary>
                    head.OwnerCiqCode = del.ownerCiqCode;

                    /// <summary>
                    /// 申报单位检验检疫编码
                    /// </summary>
                    head.DeclCiqCode = del.declRegNo;


                    //新增状态字段 9 放行
                    head.CusDecStatus = del.cusDecStatus;
                    head.CusDecStatusName = del.cusDecStatusName;
                    //head.EncryptString = del.e
                    /// <summary>
                    /// 申报日期
                    /// </summary>
                    head.DDate = del.dDate;
                    /// <summary>
                    /// 业务事项
                    /// </summary>
                    head.CusRemark = del.cusRemark;


                    tdecfreetxt decfreetxt = new tdecfreetxt();
                    decfreetxt.BonNo = del.bonNo;
                    decfreetxt.CusFie = del.customsField;
                    decfreetxt.RelId = del.relativeId;
                    //decfreetxt.DecBpNo= del.dec ;
                    //decfreetxt.DecNo = del. ;
                    decfreetxt.RelManNo = del.relmanNo;
                    decfreetxt.VoyNo = del.cusVoyageNo;
                    decfreetxt.CreateTime = DateTime.Now;
                    decfreetxt.CreatorId = userid;
                    decfreetxt.Id = IdHelper.GetId();
                    decfreetxt.OrderNo = del.orderNo;


                    tdecsign decsign = new tdecsign();
                    decsign.OperType = "G";
                    decsign.CopCode = head.AgentCode;
                    decsign.ClientSeqNo = head.OrderNo;
                    decsign.CreateTime = DateTime.Now;
                    decsign.CreatorId = userid;
                    decsign.Id = IdHelper.GetId();
                    decsign.OrderNo = del.orderNo;

                    //许可证信息表
                    List<tdecgoodslimit> decgoodslimits = new List<tdecgoodslimit>();
                    //许可证VIN信息
                    List<tdecgoodslimitvin> decgoodslimitvins = new List<tdecgoodslimitvin>();

                    //商品表
                    List<MergeListVo> mergeLists = JsonConvert.DeserializeObject<List<MergeListVo>>(del.decMergeListVo.ToString());
                    List<tdeclist> declists = new List<tdeclist>();
                    mergeLists.ForEach(x =>
                    {
                        tdeclist declist = new tdeclist();
                        /// <summary>
                        /// 归类标志
                        /// </summary>
                        //declist.ClassMark = x.

                        /// <summary>
                        /// 商品编号
                        /// </summary>
                        declist.CodeTS = x.codeTs;

                        /// <summary>
                        /// 备案序号
                        /// </summary>
                        declist.ContrItem = x.contrItem;

                        /// <summary>
                        /// 申报单价
                        /// </summary>
                        declist.DeclPrice = x.declPrice != null ? Convert.ToDecimal(x.declPrice) : null;

                        /// <summary>
                        /// 申报总价
                        /// </summary>
                        declist.DeclTotal = x.declTotal != null ? Convert.ToDecimal(x.declTotal) : null;

                        /// <summary>
                        /// 征免方式
                        /// </summary>
                        declist.DutyMode = x.dutyMode;

                        /// <summary>
                        /// 货号
                        /// </summary>
                        declist.ExgNo = x.exgNo;

                        /// <summary>
                        /// 版本号
                        /// </summary>
                        declist.ExgVersion = x.exgVersion;

                        /// <summary>
                        /// 申报计量单位与法定单位比例因子
                        /// </summary>
                        declist.Factor = x.factor;

                        /// <summary>
                        /// 第一计量单位（法定单位）
                        /// </summary>
                        declist.FirstUnit = x.unit1;

                        /// <summary>
                        /// 第一法定数量
                        /// </summary>
                        declist.FirstQty = x.qty1 != null ? Convert.ToDecimal(x.qty1) : null;

                        /// <summary>
                        /// 成交计量单位
                        /// </summary>
                        declist.GUnit = x.gUnit;

                        /// <summary>
                        /// 商品规格、型号
                        /// </summary>
                        declist.GModel = x.gModel;

                        /// <summary>
                        /// 商品名称
                        /// </summary>
                        declist.GName = x.gName;

                        /// <summary>
                        /// 商品序号
                        /// </summary>
                        declist.GNo = x.gNo;

                        /// <summary>
                        /// 成交数量
                        /// </summary>
                        declist.GQty = x.gQty != null ? Convert.ToDecimal(x.gQty) : null;

                        /// <summary>
                        /// 原产国
                        /// </summary>
                        declist.OriginCountry = x.ciqOriginCountry;

                        /// <summary>
                        /// 第二计量单位
                        /// </summary>
                        declist.SecondUnit = x.unit2;

                        /// <summary>
                        /// 第二法定数量
                        /// </summary>
                        declist.SecondQty = x.qty2 != null ? Convert.ToDecimal(x.qty2) : null;

                        /// <summary>
                        /// 成交币制
                        /// </summary>
                        declist.TradeCurr = x.tradeCurr;

                        /// <summary>
                        /// 用途/生产厂家
                        /// </summary>
                        declist.UseTo = x.useTo;

                        /// <summary>
                        /// 工缴费
                        /// </summary>
                        declist.WorkUsd = x.workUsd;

                        /// <summary>
                        /// 最终目的国（地区）
                        /// </summary>
                        declist.DestinationCountry = x.destinationCountry;

                        /// <summary>
                        /// 检验检疫编码
                        /// </summary>
                        declist.CiqCode = x.ciqCode;

                        /// <summary>
                        /// 商品英文名称
                        /// </summary>
                        declist.DeclGoodsEname = x.declGoodsEname;

                        /// <summary>
                        /// 原产地区代码
                        /// </summary>
                        declist.OrigPlaceCode = x.ciqOriginCountry;

                        /// <summary>
                        /// 用途代码
                        /// </summary>
                        declist.Purpose = x.purpose;

                        /// <summary>
                        /// 产品有效期
                        /// </summary>
                        declist.ProdValidDt = x.prodValidDt;

                        /// <summary>
                        /// 产品保质期
                        /// </summary>
                        declist.ProdQgp = x.prodQgp;

                        /// <summary>
                        /// 货物属性代码
                        /// </summary>
                        declist.GoodsAttr = x.goodsAttr;

                        /// <summary>
                        /// 成份/原料/组份
                        /// </summary>
                        declist.Stuff = x.stuff;

                        /// <summary>
                        /// UN编码
                        /// </summary>
                        declist.Uncode = x.uncode;

                        /// <summary>
                        /// 危险货物名称
                        /// </summary>
                        declist.DangName = x.dangName;

                        /// <summary>
                        /// 危包类别
                        /// </summary>
                        declist.DangPackType = x.dangPackType ?? x.packType;

                        /// <summary>
                        /// 危包规格
                        /// </summary>
                        declist.DangPackSpec = x.dangPackSpec ?? x.packSpec;

                        /// <summary>
                        /// 境外生产企业名称
                        /// </summary>
                        declist.EngManEntCnm = x.engManEntCnm;

                        /// <summary>
                        /// 非危险化学品
                        /// </summary>
                        declist.NoDangFlag = x.noDangFlag;

                        /// <summary>
                        /// 目的地代码
                        /// </summary>
                        declist.DestCode = x.ciqDestCode;

                        /// <summary>
                        /// 检验检疫货物规格
                        /// </summary>
                        declist.GoodsSpec = x.goodsSpec;

                        /// <summary>
                        /// 货物型号
                        /// </summary>
                        declist.GoodsModel = x.goodsModel;

                        /// <summary>
                        /// 货物品牌
                        /// </summary>
                        declist.GoodsBrand = x.goodsBrand;

                        /// <summary>
                        /// 生产日期
                        /// </summary>
                        declist.ProduceDate = x.produceDate;

                        /// <summary>
                        /// 生产批号
                        /// </summary>
                        declist.ProdBatchNo = x.prodBatchNo;

                        /// <summary>
                        /// 境内目的地/境内货源地
                        /// </summary>
                        declist.DistrictCode = x.districtCode;

                        /// <summary>
                        /// 检验检疫名称
                        /// </summary>
                        declist.CiqName = x.ciqName;

                        /// <summary>
                        /// 生产单位注册号
                        /// </summary>
                        declist.MnufctrRegno = x.mnufctrRegno;

                        /// <summary>
                        /// 生产单位名称
                        /// </summary>
                        declist.MnufctrRegName = x.mnufctrRegName;

                        if (!string.IsNullOrEmpty(x.preDecCiqXiangHui))
                        {
                            DecCiqXiangHui decCiqXiang = JsonConvert.DeserializeObject<DecCiqXiangHui>(x.preDecCiqXiangHui.ToString());
                            ///原产地证明编号
                            declist.CertOriCode = decCiqXiang.certOriCode;
                            ///优惠贸易协定代码
                            declist.PreTradeAgreeCode = decCiqXiang.preTradeAgreeCode;
                            ///原产地证明商品项号
                            declist.CertOriModItem = decCiqXiang.certOriModItemNum;
                            ///原产地证明类型 原产地声明(D) 原产地证书(C)
                            declist.OriCertType = decCiqXiang.oriCertType;
                        }

                        /// <summary>
                        /// 优惠贸易协定项下原产地
                        /// </summary>
                        declist.RcepOrigPlaceCode = x.rcepOrigPlaceCode;

                        declist.Id = IdHelper.GetId();

                        declist.CreateTime = DateTime.Now;

                        declist.CreatorId = userid;
                        declist.OrderNo = del.orderNo;


                        if (!string.IsNullOrEmpty(x.preDecCiqGoodsLimit))
                        {
                            List<DecCiqGoodsLimit> decCiqGoodsLimits = JsonConvert.DeserializeObject<List<DecCiqGoodsLimit>>(x.preDecCiqGoodsLimit.ToString());
                            foreach (var item in decCiqGoodsLimits)
                            {
                                tdecgoodslimit decgoodslimit = new tdecgoodslimit();
                                decgoodslimit.GoodsId = declist.Id;
                                decgoodslimit.GoodsNo = x.gNo;
                                decgoodslimit.LicTypeCode = item.licTypeCode;
                                decgoodslimit.LicenceNo = item.licenceNo;
                                decgoodslimit.LicWrtofDetailNo = item.licWrtofDetailNo;
                                decgoodslimit.LicWrtofQty = item.licWrtofQty;
                                decgoodslimit.LicWrtofQtyUnit = item.licWrtofUnit;
                                decgoodslimit.Id = IdHelper.GetId();
                                decgoodslimit.CreateTime = DateTime.Now;
                                decgoodslimit.CreatorId = userid;
                                decgoodslimit.OrderNo = del.orderNo;
                                if (!string.IsNullOrEmpty(item.preDecCiqGoodsLimitVinVo))
                                {
                                    List<DecCiqGoodsLimitVin> decCiqGoodsLimitVins = JsonConvert.DeserializeObject<List<DecCiqGoodsLimitVin>>(item.preDecCiqGoodsLimitVinVo.ToString());
                                    foreach (var itemVin in decCiqGoodsLimitVins)
                                    {
                                        tdecgoodslimitvin decgoodslimitvin = new tdecgoodslimitvin();
                                        decgoodslimitvin.GoodsLimitId = decgoodslimit.Id;
                                        decgoodslimitvin.LicenceNo = itemVin.licenceNo;
                                        decgoodslimitvin.LicTypeCode = decgoodslimit.LicTypeCode;
                                        decgoodslimitvin.VinNo = itemVin.vinNo;
                                        if (!string.IsNullOrEmpty(itemVin.billLadDate))
                                        {
                                            decgoodslimitvin.BillLadDate = DateTime.Parse(itemVin.billLadDate);
                                        }
                                        decgoodslimitvin.QualityQgp = itemVin.qualityQgp;
                                        decgoodslimitvin.MotorNo = itemVin.motorNo;
                                        decgoodslimitvin.VinCode = itemVin.vinCode;
                                        decgoodslimitvin.ChassisNo = itemVin.chassisNo;
                                        if (!string.IsNullOrEmpty(itemVin.invoiceNum))
                                        {
                                            decgoodslimitvin.InvoiceNum = decimal.Parse(itemVin.invoiceNum);
                                        }
                                        decgoodslimitvin.ProdCnnm = itemVin.motorNo;
                                        decgoodslimitvin.ProdEnnm = itemVin.motorNo;
                                        decgoodslimitvin.ModelEn = itemVin.motorNo;
                                        decgoodslimitvin.PricePerUnit = itemVin.motorNo;
                                        decgoodslimitvin.InvoiceNo = itemVin.motorNo;
                                        decgoodslimitvin.Id = IdHelper.GetId();
                                        decgoodslimitvin.CreateTime = DateTime.Now;
                                        decgoodslimitvin.CreatorId = userid;
                                        decgoodslimitvin.OrderNo = del.orderNo;
                                        decgoodslimitvins.Add(decgoodslimitvin);
                                    }
                                }
                                decgoodslimits.Add(decgoodslimit);
                            }
                        }

                        declists.Add(declist);
                    });

                    //集装箱
                    List<DecContainerVo> containerdeclist = JsonConvert.DeserializeObject<List<DecContainerVo>>(del.preDecContainerVo.ToString());
                    List<tdeccontainer> deccontainers = new List<tdeccontainer>();
                    containerdeclist.ForEach(x =>
                    {
                        tdeccontainer deccontainer = new tdeccontainer();
                        /// <summary>
                        /// 集装箱号
                        /// </summary>
                        deccontainer.ContainerId = x.containerNo;
                        /// <summary>
                        /// 集装箱规格
                        /// </summary>
                        deccontainer.ContainerMd = x.cntnrModeCode;
                        /// <summary>
                        /// 商品项号用半角逗号分隔，如"1,3"
                        /// </summary>
                        deccontainer.GoodsNo = x.goodsNo;
                        /// <summary>
                        /// 拼箱标识，0-否1-是
                        /// </summary>
                        deccontainer.LclFlag = x.lclFlag;
                        ///// <summary>
                        ///// 箱货重量
                        ///// </summary>
                        //deccontainer.GoodsContaWt = x.containerWt;
                        /// <summary>
                        /// 自重
                        /// </summary>
                        deccontainer.ContainerWt = x.containerWt != null ? Convert.ToDecimal(x.containerWt) : null;
                        deccontainer.CreateTime = DateTime.Now;
                        deccontainer.CreatorId = userid;
                        deccontainer.Id = IdHelper.GetId();
                        deccontainer.OrderNo = del.orderNo;
                        deccontainers.Add(deccontainer);
                    });

                    //随附单证
                    List<tdeclicensedocus> declicensedocuss = new List<tdeclicensedocus>();
                    List<CusLicenseListVo> cusLicenseListVos = JsonConvert.DeserializeObject<List<CusLicenseListVo>>(del.cusLicenseListVo.ToString());
                    cusLicenseListVos.ForEach(x =>
                    {
                        tdeclicensedocus declicensedocus = new tdeclicensedocus();
                        declicensedocus.CertCode = x.acmpFormNo;
                        declicensedocus.DocuCode = x.acmpFormCode;
                        declicensedocus.CreateTime = DateTime.Now;
                        declicensedocus.CreatorId = userid;
                        declicensedocus.Id = IdHelper.GetId();
                        declicensedocus.OrderNo = del.orderNo;
                        declicensedocuss.Add(declicensedocus);
                    });

                    //随附单证
                    List<tedocrealation> edocrealations = new List<tedocrealation>();
                    List<DecDocVo> decDocVos = JsonConvert.DeserializeObject<List<DecDocVo>>(del.preDecDocVo.ToString());
                    decDocVos.ForEach(x =>
                    {
                        tedocrealation edocrealation = new tedocrealation();
                        /// <summary>
                        /// 文件名、随附单据编号（文件名命名规则是：申报口岸+随附单据类别代码+IM+18位流水号+.pdf）
                        /// </summary>

                        edocrealation.EdocID = x.attEdocNo;

                        /// <summary>
                        /// 随附单证类别
                        /// </summary>
                        edocrealation.EdocCode = x.attTypeCode;

                        /// <summary>
                        /// 随附单据格式类型
                        /// </summary>
                        edocrealation.EdocFomatType = x.attFmtTypeCode;

                        /// <summary>
                        /// 操作说明（重传原因）
                        /// </summary>
                        edocrealation.OpNote = x.uploadOpTypeCode;

                        /// <summary>
                        /// 随附单据文件企业名
                        /// </summary>
                        //edocrealation.EdocCopId = x.

                        /// <summary>
                        /// 所属单位海关编号
                        /// </summary>
                        //edocrealation.EdocOwnerCode = x.

                        /// <summary>
                        /// 签名单位代码
                        /// </summary>
                        edocrealation.SignUnit = x.signWkunitCode;

                        /// <summary>
                        /// 签名时间
                        /// </summary>
                        edocrealation.SignTime = x.signDate;

                        /// <summary>
                        /// 所属单位名称
                        /// </summary>
                        //edocrealation.EdocOwnerName = x.

                        /// <summary>
                        /// 随附单据文件大小
                        /// </summary>
                        //edocrealation.EdocSize = x.

                        /// <summary>
                        /// 商品项号关系
                        /// </summary>
                        edocrealation.GNoStr = x.gNoStr;

                        edocrealation.CreateTime = DateTime.Now;
                        edocrealation.CreatorId = userid;
                        edocrealation.Id = IdHelper.GetId();
                        edocrealation.OrderNo = del.orderNo;
                        edocrealations.Add(edocrealation);
                    });

                    //其他包装
                    List<tdecotherpack> decotherpacks = new List<tdecotherpack>();
                    List<DevOtherPacksVo> otherpark = JsonConvert.DeserializeObject<List<DevOtherPacksVo>>(del.decOtherPacksVo.ToString());
                    otherpark.ForEach(x =>
                    {
                        tdecotherpack decotherpack = new tdecotherpack();
                        /// <summary>
                        /// 包装件数
                        /// </summary>
                        decotherpack.PackQty = x.packQty != null ? Convert.ToDecimal(x.packQty) : null;
                        /// <summary>
                        /// 包装材料种类
                        /// </summary>
                        decotherpack.PackType = x.packType;
                        decotherpack.CreateTime = DateTime.Now;
                        decotherpack.CreatorId = userid;
                        decotherpack.OrderNo = del.orderNo;
                        decotherpack.Id = IdHelper.GetId();
                        decotherpacks.Add(decotherpack);
                    });

                    //申请单证信息表
                    List<tdecrequestcert> decrequestcerts = new List<tdecrequestcert>();
                    List<DecRequCertList> preDecRequCertLists = JsonConvert.DeserializeObject<List<DecRequCertList>>(del.preDecRequCertList.ToString());
                    preDecRequCertLists.ForEach(x =>
                    {
                        tdecrequestcert decrequestcert = new tdecrequestcert();
                        decrequestcert.AppCertCode = x.appCertCode;
                        decrequestcert.ApplOri = x.applOri;
                        decrequestcert.ApplCopyQuan = x.applCopyQuan;
                        decrequestcert.CreateTime = DateTime.Now;
                        decrequestcert.CreatorId = userid;
                        decrequestcert.OrderNo = del.orderNo;
                        decrequestcert.Id = IdHelper.GetId();
                        decrequestcerts.Add(decrequestcert);
                    });

                    //使用人信息表
                    List<tdecuser> decusers = new List<tdecuser>();
                    List<DecUserList> preDecUserLists = JsonConvert.DeserializeObject<List<DecUserList>>(del.preDecUserList.ToString());
                    preDecUserLists.ForEach(x =>
                    {
                        tdecuser decuser = new tdecuser();
                        decuser.UseOrgPersonCode = x.useOrgPersonCode;
                        decuser.UseOrgPersonTel = x.useOrgPersonTel;
                        decuser.CreateTime = DateTime.Now;
                        decuser.CreatorId = userid;
                        decuser.OrderNo = del.orderNo;
                        decuser.Id = IdHelper.GetId();
                        decusers.Add(decuser);
                    });

                    //企业承诺信息
                    tdeccoppromise deccoppromise = null;
                    //企业资质信息表
                    List<tdeccoplimit> deccoplimits = new List<tdeccoplimit>();
                    List<DecEntQualifListVo> preDecEntQualifListVos = JsonConvert.DeserializeObject<List<DecEntQualifListVo>>(del.preDecEntQualifListVo.ToString());
                    preDecEntQualifListVos.ForEach(x =>
                    {
                        if (x.entQualifTypeCode == "101040")
                        {
                            deccoppromise = new tdeccoppromise();
                            deccoppromise.DeclaratioMaterialCode = x.entQualifTypeCode;
                            deccoppromise.CreateTime = DateTime.Now;
                            deccoppromise.CreatorId = userid;
                            deccoppromise.OrderNo = del.orderNo;
                            deccoppromise.Id = IdHelper.GetId();
                        }
                        else
                        {
                            tdeccoplimit deccoplimit = new tdeccoplimit();
                            deccoplimit.EntQualifNo = x.entQualifNo;
                            deccoplimit.EntQualifTypeCode = x.entQualifTypeCode;
                            deccoplimit.CreateTime = DateTime.Now;
                            deccoplimit.CreatorId = userid;
                            deccoplimit.OrderNo = del.orderNo;
                            deccoplimit.Id = IdHelper.GetId();
                            deccoplimits.Add(deccoplimit);
                        }
                    });

                    await _db.DeleteAsync<tdeclist>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdeccontainer>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdeclicensedocus>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecotherpack>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tedocrealation>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecfreetxt>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecsign>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecrequestcert>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecuser>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdeccoplimit>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdeccoppromise>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecgoodslimit>(t => t.OrderNo == del.orderNo);
                    await _db.DeleteAsync<tdecgoodslimitvin>(t => t.OrderNo == del.orderNo);

                    if (head != null)
                    {
                        await _db.UpdateAsync(head);
                        //await _db.InsertAsync<tdechead>(tdechead);
                        if (declists.Count > 0)
                            await _db.InsertAsync(declists);
                        if (containerdeclist.Count > 0)
                            await _db.InsertAsync(deccontainers);
                        if (declicensedocuss.Count > 0)
                            await _db.InsertAsync(declicensedocuss);
                        if (otherpark.Count > 0)
                            await _db.InsertAsync(decotherpacks);
                        if (decrequestcerts.Count > 0)
                            await _db.InsertAsync(decrequestcerts);
                        if (decusers.Count > 0)
                            await _db.InsertAsync(decusers);
                        if (deccoplimits.Count > 0)
                            await _db.InsertAsync(deccoplimits);
                        if (decgoodslimits.Count > 0)
                            await _db.InsertAsync(decgoodslimits);
                        if (decgoodslimitvins.Count > 0)
                            await _db.InsertAsync(decgoodslimitvins);
                        if (edocrealations.Count > 0)
                            await _db.InsertAsync(edocrealations);
                        await _db.InsertAsync(decfreetxt);
                        await _db.InsertAsync(decsign);
                        if (deccoppromise != null)
                        {
                            await _db.InsertAsync(deccoppromise);
                        }
                    }




                }
                return "修改条数：" + orderlist.Count;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<string> SaveRemark(List<ConditionDTO> orderlist)
        {
            try
            {
                List<temailorder> updateheadlist = new List<temailorder>();
                foreach (ConditionDTO del in orderlist)
                {
                    //邮件表
                    temailorder main = _db.GetIQueryable<temailorder>().Where(x => x.OrderNo == del.Condition).ToList().FirstOrDefault();
                    if (main != null)
                    {
                        string mainremark = main.Remark == null ? "" : main.Remark;
                        string delremark = del.Keyword == null ? "" : del.Keyword;
                        if (!mainremark.Equals(delremark))
                        {
                            main.Remark = del.Keyword;
                            updateheadlist.Add(main);
                        }
                    }
                }
                if (updateheadlist.Count > 0)
                    await _db.UpdateAsync<temailorder>(updateheadlist);
                return "修改条数：" + updateheadlist.Count;
            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<tdecinfo> GetDecInfo(string orderNo)
        {
            tdecinfo tdecinfo = new tdecinfo();
            temailorder temailorder = _db.GetIQueryable<temailorder>().Where(t => t.OrderNo == orderNo).FirstOrDefault();
            if (!temailorder.IsNullOrEmpty())
            {
                tinboxcontent tinboxcontent = await _db.GetIQueryable<tinboxcontent>().Where(t => t.Id == temailorder.InboxId).FirstOrDefaultAsync();
                tdecinfo.tinboxcontent = tinboxcontent;
            }
            tdecinfo.temailorder = temailorder;
            tdechead tdechead = _db.GetIQueryable<tdechead>().Where(t => t.OrderNo == orderNo).FirstOrDefault();
            if (!tdechead.IsNullOrEmpty())
            {
                List<tdeclist> tdeclists = await _db.GetIQueryable<tdeclist>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdeccontainer> tdeccontainers = await _db.GetIQueryable<tdeccontainer>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdeclicensedocus> tdeclicensedocuses = await _db.GetIQueryable<tdeclicensedocus>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdecotherpack> tdecotherpacks = await _db.GetIQueryable<tdecotherpack>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tedocrealation> tedocrealations = await _db.GetIQueryable<tedocrealation>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdecuser> tdecusers = await _db.GetIQueryable<tdecuser>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdeccoplimit> tdeccoplimits = await _db.GetIQueryable<tdeccoplimit>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdecrequestcert> tdecrequestcerts = await _db.GetIQueryable<tdecrequestcert>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdecgoodslimit> tdecgoodslimits = await _db.GetIQueryable<tdecgoodslimit>().Where(t => t.OrderNo == orderNo).ToListAsync();
                List<tdecgoodslimitvin> tdecgoodslimitvins = await _db.GetIQueryable<tdecgoodslimitvin>().Where(t => t.OrderNo == orderNo).ToListAsync();
                tdecfreetxt tdecfreetxt = await _db.GetIQueryable<tdecfreetxt>().Where(t => t.OrderNo == orderNo).FirstOrDefaultAsync();
                tdecsign tdecsign = await _db.GetIQueryable<tdecsign>().Where(t => t.OrderNo == orderNo).FirstOrDefaultAsync();
                tdeccoppromise tdeccoppromise = await _db.GetIQueryable<tdeccoppromise>().Where(t => t.OrderNo == orderNo).FirstOrDefaultAsync();
                tdecinfo.tdechead = tdechead;
                tdecinfo.tdeclists = tdeclists;
                tdecinfo.tdeccontainers = tdeccontainers;
                tdecinfo.tdeclicensedocuses = tdeclicensedocuses;
                tdecinfo.tdecotherpacks = tdecotherpacks;
                tdecinfo.tedocrealations = tedocrealations;
                tdecinfo.tdecusers = tdecusers;
                tdecinfo.tdeccoplimits = tdeccoplimits;
                tdecinfo.tdecrequestcerts = tdecrequestcerts;
                tdecinfo.tdecgoodslimits = tdecgoodslimits;
                tdecinfo.tdecgoodslimitvins = tdecgoodslimitvins;
                tdecinfo.tdecfreetxt = tdecfreetxt;
                tdecinfo.tdecsign = tdecsign;
                tdecinfo.tdeccoppromise = tdeccoppromise;
            }
            else
            {
                if (temailorder != null)
                {
                    return tdecinfo;
                }
                throw new BusException("未查到该订单号！");
            }
            return tdecinfo;
            //}
            //else
            //{
            //    throw new BusException("未查到该订单号！");
            //}
        }


        public async Task<tdechead> GetDecHead(string orderNo)
        {
            tdechead tdechead = await _db.GetIQueryable<tdechead>().Where(t => t.OrderNo == orderNo).FirstOrDefaultAsync();
            if (!tdechead.IsNullOrEmpty())
            {
                return tdechead;
            }
            else
            {
                throw new BusException("未查到该订单号！");
            }
        }

        public async Task<List<UnitDto>> GetUnit()
        {
            //string cacheKey = "DataList-tdechead-GetUnit";

            //string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            //if (!string.IsNullOrEmpty(cachedDataJson))
            //{
            //    var cachedData = JsonConvert.DeserializeObject<List<UnitDto>>(cachedDataJson);
            //    if (cachedData != null)
            //    {
            //        return cachedData;
            //    }
            //}
            var data = await _db.GetIQueryable<tdechead>().Select(a => new UnitDto { cusCode = a.TradeCode, codeName = a.TradeName }).Distinct().ToListAsync();
            //string dataJson = JsonConvert.SerializeObject(data);
            //await _redis.StringSetAsync(cacheKey, dataJson);
            return data;

        }

        public async Task<string> GetIEFlag(string orderNo)
        {
            try
            {
                if (orderNo.IsNullOrEmpty())
                {
                    throw new BusException("订单号不能为空！");
                }
                tdechead tdechead = await Db.GetIQueryable<tdechead>().Where(t => t.OrderNo == orderNo).FirstOrDefaultAsync();
                return tdechead?.IEFlag;
            }
            catch (Exception ex)
            {
                throw new BusException(ex.Message);
            }
        }

        public async Task<List<tdechead>> GetDataListOrderAsync(List<string> input)
        {
            var q = GetIQueryable();
            return await q.Where(x => input.Contains(x.OrderNo)).ToListAsync();
        }
    }
}