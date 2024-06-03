using Castle.Core.Internal;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Enum;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Entity.Nems;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public class temailorderBusiness : BaseBusiness<temailorder>, ItemailorderBusiness, ITransientDependency
    {
        public IDbAccessor _db;
        public IOperator @operator { get; }
        public List<Base_User> base_users = new List<Base_User>();
        public temailorderBusiness(IDbAccessor db, IOperator _operator)
            : base(db)
        {
            _db = db;
            @operator = _operator;
        }

        #region 外部接口

        public async Task<PageResultOrder<EmailOrderDto>> GetDataListAsync(PageInput<List<ConditionDTO>> input)
        {
            try
            {
                var wherea = LinqHelper.True<temailorder>();
                var whereb = LinqHelper.True<tdechead>();

                OrderType orderType = OrderType.数据总览;

                DateTime createTime = DateTime.Now.AddDays(-60);
                string startDecTime = null;
                string endDecTime = null;
                var ordertype= input.Search.Where(x => x.Condition.Equals("OrderType")).FirstOrDefault();
                orderType = (OrderType)Enum.Parse(typeof(OrderType), ordertype.Keyword);
                foreach (ConditionDTO search in input.Search)
                {
                    //筛选
                    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                    {
                        string expression = $@"{search.Condition}.Contains(@0)";
                        if (search.Condition.Equals("StartTime"))
                        {
                            expression = $@"{"ConfirmTime"}>=@0";
                        }
                        if (search.Condition.Equals("EndTime"))
                        {
                            expression = $@"{"ConfirmTime"}<@0";
                        }
                        if (search.Condition.Equals("StartDecTime"))
                        {
                            startDecTime = DateTime.Parse(search.Keyword).ToString("yyyy-MM-dd");
                            continue;
                        }
                        if (search.Condition.Equals("EndDecTime"))
                        {
                            endDecTime = DateTime.Parse(search.Keyword).ToString("yyyy-MM-dd");
                            continue;
                        }
                        if (search.Condition.Equals("NoCusDecStatusName"))
                        {
                            continue;
                        }
                        if (search.Condition.Equals("CusDecStatusName"))
                        {
                            continue;
                        }
                        if (search.Condition.Equals("CreateTime"))
                        {
                            expression = $@"{"CreateTime"}>@0";
                            search.Keyword = Convert.ToDateTime(search.Keyword).ToString();
                            createTime = Convert.ToDateTime(search.Keyword);
                        }
                        if (search.Condition.Equals("IsEntryClerk"))
                        {
                            expression = $@"{"IsEntryClerk"}=@0";
                        }
                        if (search.Condition.Equals("IsConfirmOrder"))
                        {
                            expression = $@"{"IsConfirmOrder"}=@0";
                        }
                        if (search.Condition.Equals("IsVerifier"))
                        {
                            expression = $@"{"IsVerifier"}=@0";
                        }
                        if (search.Condition.Equals("OperatorName"))
                        {
                            expression = $@"{"OperatorName"}=@0";
                        }
                        if (search.Condition.Equals("EntryId"))
                        {
                            expression = $@"{"EntryId"}=@0";
                        }
                        if (search.Condition.Equals("OrderType"))
                        {
                            /*orderType = (OrderType)Enum.Parse(typeof(OrderType), search.Keyword);*/
                            continue;
                        }
                        if (search.Condition.Equals("IEFlag"))
                        {
                            expression = $@"{"IEFlag"}=@0";
                        }
                        if (search.Condition.Equals("StartTime")&& orderType == OrderType.确认区)
                        {
                            expression = $@"{"SendTime"}>=@0";
                        }
                        if (search.Condition.Equals("EndTime")&& orderType == OrderType.确认区)
                        {
                            expression = $@"{"SendTime"}<@0";
                        }
                        if (search.Condition.Equals("SeqNo") || search.Condition.Equals("EntryId") || search.Condition.Equals("BillNo") || search.Condition.Equals("IEFlag"))
                        {
                            var newWhereb = DynamicExpressionParser.ParseLambda<tdechead, bool>(
                            ParsingConfig.Default, false, expression, search.Keyword);
                            whereb = whereb.And(newWhereb);
                        }
                        else
                        {
                            var newWhere = DynamicExpressionParser.ParseLambda<temailorder, bool>(
                               ParsingConfig.Default, false, expression, search.Keyword);
                            wherea = wherea.And(newWhere);
                        }
                    }

                }
                //检查开始时间和结束时间字符串是否存在
                if (startDecTime != null)
                {
                    var newWhereb = LinqKit.PredicateBuilder.New<tdechead>();

                    // 假设 startDecTimeString 和 endDecTimeString 是以 "yyyy-MM-dd" 格式的日期字符串
                    newWhereb = newWhereb.And(t => String.Compare(t.DDate, startDecTime) >= 0);

                    whereb = whereb.And(newWhereb);

                }
                if (endDecTime != null)
                {
                    var newWhereb = LinqKit.PredicateBuilder.New<tdechead>();

                    // 假设 startDecTimeString 和 endDecTimeString 是以 "yyyy-MM-dd" 格式的日期字符串
                    newWhereb = newWhereb.And(t => String.Compare(t.DDate, endDecTime) <= 0);

                    whereb = whereb.And(newWhereb);

                }
                List<string> decStatus = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };
                switch (orderType)
                {
                    case OrderType.确认区:
                        wherea = wherea.And(x => @operator.Property.AssocIdList.Contains(x.OperatorId) || @operator.Property.AssocIdList.Contains(x.EntryClerkId) || @operator.Property.AssocIdList.Contains(x.VerifierId) || @operator.Property.AssocIdList.Contains(x.ReviewerId) || @operator.Property.AssocIdList.Contains(x.ConfirmId) || @operator.Property.AssocIdList.Contains(x.RejectId));
                        break;
                    case OrderType.制单区:
                        wherea = wherea.And(x => x.EntryClerkId != null && x.EntryClerkId != "");
                        //where = where.And(x => @operator.Property.AssocIdList.Contains(x.OperatorId) || @operator.Property.AssocIdList.Contains(x.EntryClerkId) || @operator.Property.AssocIdList.Contains(x.VerifierId) || @operator.Property.AssocIdList.Contains(x.ReviewerId) || @operator.Property.AssocIdList.Contains(x.ConfirmId) || @operator.Property.AssocIdList.Contains(x.RejectId));
                        break;
                    case OrderType.待派单区:
                        wherea = wherea.And(x => x.EntryClerkId == null || x.EntryClerkId == "");
                        wherea = wherea.And(x => @operator.Property.AssocIdList.Contains(x.OperatorId) || @operator.Property.AssocIdList.Contains(x.EntryClerkId) || @operator.Property.AssocIdList.Contains(x.VerifierId) || @operator.Property.AssocIdList.Contains(x.ReviewerId) || @operator.Property.AssocIdList.Contains(x.ConfirmId) || @operator.Property.AssocIdList.Contains(x.RejectId));
                        break;
                    case OrderType.审单区:
                        wherea = wherea.And(x => x.DeclarationStatus == null || x.DeclarationStatus == "");
                        wherea = wherea.And(x => @operator.Property.AssocIdList.Contains(x.OperatorId) || @operator.Property.AssocIdList.Contains(x.EntryClerkId) || @operator.Property.AssocIdList.Contains(x.VerifierId) || @operator.Property.AssocIdList.Contains(x.ReviewerId) || @operator.Property.AssocIdList.Contains(x.ConfirmId) || @operator.Property.AssocIdList.Contains(x.RejectId));
                        break;
                    case OrderType.待申报区:
                        wherea = wherea.And(x => x.CusDecStatus == "1");
                        break;
                    case OrderType.已申报区:
                        wherea = wherea.And(x => decStatus.Contains(x.CusDecStatus) || (x.CusDecStatus != null && x.CusDecStatus != "1"));
                        break;
                    default:
                        //where = where.And(x => @operator.Property.AssocIdList.Contains(x.OperatorId) || @operator.Property.AssocIdList.Contains(x.EntryClerkId) || @operator.Property.AssocIdList.Contains(x.VerifierId) || @operator.Property.AssocIdList.Contains(x.ReviewerId) || @operator.Property.AssocIdList.Contains(x.ConfirmId) || @operator.Property.AssocIdList.Contains(x.RejectId));
                        break;
                }
                IQueryable<temailorder> q;
                IQueryable<temailorder> qcount;

                if (whereb.Body.ToString() != "True")//判断dechead 表是否有查询条件
                {
                    List<string> tdecheads = _db.GetIQueryable<tdechead>().Where(whereb).Where(x => x.CreateTime > createTime).Select(a => a.OrderNo).ToList();
                    wherea = wherea.And(a => tdecheads.Contains(a.OrderNo));//将符合查询条件的订单号作为筛选条件传给订单表emailorderno
                }
                q = GetIQueryable().Where(wherea);
                qcount = q;

                switch (orderType)
                {
                    case OrderType.确认区:
                        q = q.OrderByDescending(i => i.IsUrgent)
                            .ThenByDescending(i => i.IsManual)
                            .ThenByDescending(i => i.IsReject)
                           .ThenByDescending(i => i.SendTime)
                           .Skip((input.PageIndex - 1) * input.PageRows)
                           .Take(input.PageRows);
                        break;
                    case OrderType.制单区:
                        q = q.OrderByDescending(i => i.IsUrgent)
                           .ThenBy(i => i.InEntryClerkTime)
                           .Skip((input.PageIndex - 1) * input.PageRows)
                           .Take(input.PageRows);
                        break;
                    case OrderType.待申报区:
                        q = q.OrderByDescending(i => i.IsUrgent)
                           .ThenByDescending(i => i.VerifierTime)
                           .Skip((input.PageIndex - 1) * input.PageRows)
                           .Take(input.PageRows);
                        break;
                    default:
                        q = q.OrderByDescending(i => i.SendTime)
                           .Skip((input.PageIndex - 1) * input.PageRows)
                           .Take(input.PageRows);
                        break;
                }

                var orderInfoList = q.Select(t => new { t.OrderNo, t.InboxId }).ToList();

                List<string> orderNos = orderInfoList.Select(x => x.OrderNo).ToList();
                List<string> inboxIds = orderInfoList.Select(t => t.InboxId).ToList();

                var b1 = _db.GetIQueryable<tdechead>().Where(whereb).Where(t => orderNos.Contains(t.OrderNo)).Select(a => new
                {
                    a.TrafName,
                    a.CusVoyageNo,
                    a.ManualNo,
                    a.IEFlag,
                    a.SeqNo,
                    a.CusDecStatusName,
                    a.BillNo,
                    a.AgentCode,
                    a.AgentName,
                    a.EntryId,
                    a.TradeCode,
                    a.TradeName,
                    a.DDate,
                    a.OrderNo,
                    a.EncryptString,
                    a.EntryType
                });

                List<Base_User> users = _db.GetIQueryable<Base_User>().ToList();
                var attachments = _db.GetIQueryable<tinboxattachment>().Where(t => inboxIds.Contains(t.InboxId)).ToList();

                var tdeccontainers = _db.GetIQueryable<tdeccontainer>().Where(t => orderNos.Contains(t.OrderNo)).ToList();

                var tdeclists = _db.GetIQueryable<tdeclist>().Where(t => orderNos.Contains(t.OrderNo)).GroupBy(a => a.OrderNo).Select(g => new { OrderNo = g.Key, Count = g.Count() }).ToList();

                var tedocrealations = _db.GetIQueryable<tedocrealation>().Where(t => orderNos.Contains(t.OrderNo)).ToList();

                var tdeclicensedocuses = _db.GetIQueryable<tdeclicensedocus>().Where(t => orderNos.Contains(t.OrderNo)).ToList();

                var tdecreviewCountQuery = _db.GetIQueryable<tdecreview>().Where(x => !string.IsNullOrEmpty(x.OrderNo)).GroupBy(x => x.OrderNo).Select(x => new
                {
                    OrderNo = x.Key,
                    RevisionsNumber = x.Count()
                });

                var query = from o in q
                            join b in b1 on o.OrderNo equals b.OrderNo into ob
                            from o1 in ob.DefaultIfEmpty()

                            join c in _db.GetIQueryable<tinboxcontent>() on o.InboxId equals c.Id into oc
                            from o2 in oc.DefaultIfEmpty()
                            join t4 in tdecreviewCountQuery on o.OrderNo equals t4.OrderNo into t4Join
                            from t4 in t4Join.DefaultIfEmpty()
                            select new EmailOrderDto
                            {
                                StartDate = o.StartDate,
                                IsManual = o.IsManual,
                                IsPending = o.IsPending,
                                InEntryClerkTime = o.InEntryClerkTime,
                                PendingTime = o.PendingTime,
                                EncryptString = o1.EncryptString,
                                IsPrint = o.IsPrint,
                                Feedback = o.Feedback,
                                IsReject = o.IsReject,
                                IsUrgent = o.IsUrgent,
                                IsConfirmOrder = o.IsConfirmOrder,
                                ConfirmName = o.ConfirmName,
                                ConfirmId = o.ConfirmId,
                                ConfirmTime = o.ConfirmTime,
                                MAInterfaceResult = o.MAInterfaceResult,
                                IsManifest = o.IsManifest,
                                IsArrival = o.IsArrival,
                                HGManifestTime = o.HGManifestTime,
                                HGArrivalTime = o.HGArrivalTime,
                                MACheckResult = o.MACheckResult,
                                SignDate = o.SignDate,
                                ValidDate = o.ValidDate,
                                InspectionResult = o.InspectionResult,
                                TrafName = o1.TrafName,
                                CusVoyageNo = o1.CusVoyageNo,
                                ManualNo = o1.ManualNo,
                                IEFlag = o1.IEFlag,
                                SenderEmailAddress = o2.SenderEmailAddress,
                                Id = o.Id,
                                SeqNo = o1.SeqNo,
                                CustomerShortName = o.CustomerShortName,
                                OrderNo = o.OrderNo,
                                CreateTime = o.CreateTime,
                                SendTime = o.SendTime,
                                CusDecStatusName = o1.CusDecStatusName,
                                BillNo = o1.BillNo,
                                AgentCode = o1.AgentCode,
                                AgentName = o1.AgentName,
                                EntryId = o1.EntryId,
                                Subject = o.Subject,
                                EntryClerkId = o.EntryClerkId,
                                OperatorId = o.OperatorId,
                                OperatorName = o.OperatorName,
                                CustomerId = o.CustomerId,
                                TradeCode = o1.TradeCode,
                                TradeName = o1.TradeName,
                                EntryType = o1.EntryType,
                                IsEntryClerk = o.IsEntryClerk,
                                IsReviewer = o.IsReviewer,
                                IsVerifier = o.IsVerifier,
                                DDate = o1.DDate,
                                UserRemark = o.UserRemark,
                                EntryClerkTime = o.EntryClerkTime,
                                EntryClerkName = o.EntryClerkName,
                                RejectTime = o.RejectTime,
                                RejectName = o.RejectName,
                                RejectReason = o.RejectReason,
                                VerifierName = o.VerifierName,
                                ReviewerName = o.ReviewerName,
                                HandlerName = o.HandlerName,
                                VerifierTime = o.VerifierTime,
                                ReviewerTime = o.ReviewerTime,
                                HandlerTime = o.HandlerTime,
                                DeclarationStatus = o.DeclarationStatus,
                                DeclarationReason = o.DeclarationReason,
                                INVDeclarationStatus = o.INVDeclarationStatus,
                                INVDeclarationReason = o.INVDeclarationReason,
                                InboxId = o.InboxId,
                                ContactName = o.ContactName,
                                ContactId = o.ContactId,
                                DepartureTime = o.DepartureTime,
                                ArrivalTime = o.ArrivalTime,
                                CustomsCode = o.CustomsCode,
                                EntrustedStatus = o.EntrustedStatus,
                                EntrustedReason = o.EntrustedReason,
                                FeeMark = o.FeeMark,
                                InputId = o.InputId,
                                Location = o.IsConfirmOrder == "0" ? "确认区" : o.IsEntryClerk == "0" && o.IsConfirmOrder == "1" && o.IsVerifier == "0" && (o.EntryClerkId == null || o.EntryClerkId == "") ? "待派单区"
                                : o.IsEntryClerk == "1" && o.IsVerifier == "0" && (o.DeclarationStatus == null || o.DeclarationStatus == "") ? "审单区" : o.IsEntryClerk == "1" && o.IsVerifier == "1" && o1.CusDecStatusName == "保存" ? "待申报区" : o1.CusDecStatusName != "保存" && o.IsVerifier == "1" ? "已申报区" : "制单区",
                                Sxkssj = o.Sxkssj,
                                Sxjssj = o.Sxjssj,
                                RevisionsNumber = t4.RevisionsNumber,
                                AllTip = ((o.EntrustedStatus != null && o.EntrustedStatus == "3") ? "委托异常：" + o.EntrustedReason + "\r\n" : "")
                                + ((o.INVDeclarationStatus != null && o.INVDeclarationStatus == "3") ? "核注清单异常:" + o.INVDeclarationReason + "\r\n" : "")
                                + ((o.DeclarationStatus != null && o.DeclarationStatus == "3") ? "报关异常:" + o.DeclarationReason + "\r\n" : "")
                                + (!string.IsNullOrEmpty(o.MACheckResult) ? "运抵舱单校验异常:" + o.MACheckResult + "\r\n" : "")
                                + (!string.IsNullOrEmpty(o.DepotResult) ? "场站校验异常:" + o.DepotResult + "\r\n" : ""),
                                AllTipValue = !string.IsNullOrEmpty(((o.EntrustedStatus != null && o.EntrustedStatus == "3") ? "委托异常：" + o.EntrustedReason + "\r\n" : "")
                                + ((o.INVDeclarationStatus != null && o.INVDeclarationStatus == "3") ? "核注清单异常:" + o.INVDeclarationReason + "\r\n" : "")
                                + ((o.DeclarationStatus != null && o.DeclarationStatus == "3") ? "报关异常:" + o.DeclarationReason + "\r\n" : "")
                                + (!string.IsNullOrEmpty(o.MACheckResult) ? "运抵舱单校验异常:" + o.MACheckResult + "\r\n" : "")
                                + (!string.IsNullOrEmpty(o.DepotResult) ? "场站校验异常:" + o.DepotResult + "\r\n" : "")
                                ) ? "1" : "0"
                            };


                int count = await qcount.CountAsync();

                int IsConfirmOrderCount = qcount.Count(x => x.IsConfirmOrder == "1" && x.IsEntryClerk != "1");

                int IsRejectCount = qcount.Count(x => x.IsReject == "1");

                int IsEntryClerkCount = qcount.Count(x => x.IsEntryClerk == "1");

                List<EmailOrderDto> list = await query.ToListAsync();

                foreach (var item in list)
                {
                    item.Entrust = "";
                    var tdeclist = tdeclists.Where(t => t.OrderNo == item.OrderNo).FirstOrDefault();
                    if (tdeclist != null)
                    {
                        item.GoodsNum = tdeclist.Count;
                    }
                    tedocrealation tedocrealation = tedocrealations.Where(t => t.OrderNo == item.OrderNo && t.EdocCode == "10000001").FirstOrDefault();
                    tdeclicensedocus tdeclicensedocus = tdeclicensedocuses.Where(t => t.OrderNo == item.OrderNo && (t.DocuCode == "a" || t.DocuCode == "b")).FirstOrDefault();
                    if (tedocrealation != null)
                    {
                        item.EdocID = tedocrealation.EdocID;
                        item.Entrust = "电子";
                    }
                    if (tedocrealations.Where(t => t.OrderNo == item.OrderNo && t.EdocCode == "00000008").Any())
                    {
                        item.Entrust = "纸质";
                    }
                    item.Attachment = attachments.Where(t => t.InboxId == item.InboxId).Any() ? "有附件" : "";
                    if (tdeclicensedocus != null)
                    {
                        item.DocuCode = tdeclicensedocus.DocuCode;
                        item.CertCode = tdeclicensedocus.CertCode;
                        item.Inspection = "有商检";
                    }
                    if (!string.IsNullOrEmpty(item.InputId))
                    {
                        string inputNames = string.Join(",", item.InputId.Split(',').Select(id => users.Where(x => x.Id == id).FirstOrDefault()?.RealName).ToList());

                        item.InputStatus = !string.IsNullOrEmpty(inputNames) ? $"({inputNames})正在输单..." : "";
                    }
                    item.CntrNos = string.Join(",", tdeccontainers.Where(t => t.OrderNo == item.OrderNo).Select(t => t.ContainerId).ToList());
                    item.DraftOrder = attachments.Where(t => t.InboxId == item.InboxId && (t.AttachmentName.Contains("草单") || t.AttachmentName.Contains("报关单") || t.AttachmentName.Contains("报关资料"))).Any() ? "有草单" : "";
                }


                return new PageResultOrder<EmailOrderDto> { Data = list, Total = count, IsConfirmOrderCount = IsConfirmOrderCount, IsRejectCount = IsRejectCount, IsEntryClerkCount = IsEntryClerkCount };
            }
            catch (Exception ex)
            {

                throw new BusException(ex.Message);
            }


            //return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<PageResult<temailorderjonhead>> GetDataListjoinHeadAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<temailorderjonhead>();
            var search = input.Search;
            Expression<Func<temailorder, tdechead, temailorderjonhead>> select = (a, b) => new temailorderjonhead
            {
                Id = a.Id,
                CreateTime = a.CreateTime,
                CreatorId = a.CreatorId,
                OrderNo = a.OrderNo
            };
            select = select.BuildExtendSelectExpre();
            var q2 = from a in q.AsExpandable()
                     join b in Db.GetIQueryable<tdechead>() on a.OrderNo equals b.OrderNo into ab
                     from b in ab.DefaultIfEmpty()
                     select @select.Invoke(a, b);

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<temailorderjonhead, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q2.Where(where).GetPageResultAsync(input);
        }

        public async Task<PageResult<temailorder>> GetDataListAsyncWhere(PageInput<List<ConditionDTO>> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<temailorder>();
            var searchs = input.Search;

            foreach (ConditionDTO search in searchs)
            {
                //筛选
                if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                {
                    string expression = $@"{search.Condition}.Contains(@0)";
                    if (search.Condition.Equals("StartTime"))
                    {
                        expression = $@"{"SendTime"}>=@0";
                    }
                    if (search.Condition.Equals("EndTime"))
                    {
                        expression = $@"{"SendTime"}<@0";
                    }
                    var newWhere = DynamicExpressionParser.ParseLambda<temailorder, bool>(
                        ParsingConfig.Default, false, expression, search.Keyword);
                    where = where.And(newWhere);

                }
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<PageResult<temailorderjonhead>> GetDataListjoinHeadAsyncWhere(PageInput<List<ConditionDTO>> input)
        {
            try
            {
                var q = GetIQueryable();
                var where = LinqHelper.True<temailorderjonhead>();
                var searchs = input.Search;

                Expression<Func<temailorder, tdechead, tbasecustomerbgremark, tdeclist, temailorderjonhead>> select = (a, b, c, d) => new temailorderjonhead
                {
                    Id = a.Id,
                    CreateTime = a.CreateTime,
                    CreatorId = a.CreatorId,
                    OrderNo = a.OrderNo,
                    BillNo = b.BillNo,
                    SeqNo = b.SeqNo,
                    AgentCode = b.AgentCode,
                    AgentName = b.AgentName,
                    EntryId = b.EntryId,
                    EntryType = b.EntryType,
                    TrafName = b.TrafName,
                    CusVoyageNo = b.CusVoyageNo,
                    TradeCountry = b.TradeCountry,
                    OwnerCode = b.OwnerCode,
                    OwnerName = b.OwnerName,
                    CodeTS = d.CodeTS,
                    GName = d.GName
                };
                select = select.BuildExtendSelectExpre();
                var q2 = from a in q.AsExpandable()
                         join b in _db.GetIQueryable<tdechead>() on a.OrderNo equals b.OrderNo into ab
                         from b in ab.DefaultIfEmpty()
                         join c in _db.GetIQueryable<tbasecustomerbgremark>() on a.CustomerId equals c.CId into ac
                         from c in ac.DefaultIfEmpty()
                         join d in _db.GetIQueryable<tdeclist>() on a.OrderNo equals d.OrderNo into ad
                         from d in ad.DefaultIfEmpty()
                         select @select.Invoke(a, b, c, d);
                foreach (ConditionDTO search in searchs)
                {
                    //筛选
                    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                    {
                        string expression = $@"{search.Condition}.Contains(@0)";
                        if (search.Condition.Equals("StartTime"))
                        {
                            expression = $@"{"SendTime"}>=@0";
                        }
                        if (search.Condition.Equals("EndTime"))
                        {
                            expression = $@"{"SendTime"}<@0";
                        }
                        if (search.Condition.Equals("NoCusDecStatusName"))
                        {
                            expression = $@"{"CusDecStatusName"}!=@0";
                        }
                        if (search.Condition.Equals("CreateTime"))
                        {
                            expression = $@"{"CreateTime"}>@0";
                            search.Keyword = DateTime.Now.Date.AddDays(-(Convert.ToInt32(search.Keyword))).ToString();
                        }
                        var newWhere = DynamicExpressionParser.ParseLambda<temailorderjonhead, bool>(
                            ParsingConfig.Default, false, expression, search.Keyword);
                        where = where.And(newWhere);

                    }
                }

                return await q2.Where(where).GetPageResultAsync(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<temailorder> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(temailorder data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(temailorder data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }
        [Transactional]
        public async Task AuditCompletedAsync(List<string> ids)
        {
            List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => ids.Contains(x.Id)).ToList();
            main.ForEach(x => { x.IsVerifier = "1"; x.VerifierId = @operator.UserId; x.VerifierName = @operator.Property.RealName; x.VerifierTime = DateTime.Now; });
            await _db.UpdateAsync(main);
        }

        [Transactional]
        public async Task<string> Merge(List<temailorderjonhead> orderlist)
        {
            var orders = orderlist.FindAll(x => !x.IsSelected).ToList();
            temailorderjonhead item = orderlist.Find(x => x.IsSelected);
            temailorder temailorder = Db.GetIQueryable<temailorder>().Where(x => x.Id == item.Id).FirstOrDefault();
            if (orders.Count > 0)
            {
                temailorder.Subject = temailorder.Subject + " " + (string.Join(' ', orders.Select(x => x.Subject).ToList()));
                await DeleteAsync(orders.Select(x => x.Id).ToList());
            }
            var inboxids = orderlist.FindAll(x => !x.IsSelected).Select(x => x.InboxId).ToList();
            var tinboxattachmentlist = await _db.GetIQueryable<tinboxattachment>().Where(a => inboxids.Contains(a.InboxId)).ToListAsync();
            var tinboxcontent = await _db.GetIQueryable<tinboxcontent>().Where(a => a.Id == item.InboxId).FirstOrDefaultAsync();
            var tinboxcontentlist = await _db.GetIQueryable<tinboxcontent>().Where(a => inboxids.Contains(a.Id)).ToListAsync();
            if (tinboxcontent != null && tinboxcontentlist != null && tinboxcontentlist.Any())
            {
                tinboxcontent.Subject = tinboxcontent.Subject + " " + (string.Join(' ', tinboxcontentlist.Select(x => x.Subject).ToList()));
                tinboxcontent.HtmlContent = tinboxcontent.HtmlContent + " " + (string.Join(' ', tinboxcontentlist.Select(x => x.HtmlContent).ToList()));
                tinboxcontent.TextContent = tinboxcontent.TextContent + " " + (string.Join(' ', tinboxcontentlist.Select(x => x.TextContent).ToList()));
                await _db.UpdateAsync<tinboxcontent>(tinboxcontent);
                await _db.DeleteAsync<tinboxcontent>(tinboxcontentlist);
            }
            if (tinboxattachmentlist != null && tinboxattachmentlist.Any())
            {
                tinboxattachmentlist.ForEach(x => x.InboxId = item.InboxId);
                await _db.UpdateAsync<tinboxattachment>(tinboxattachmentlist);
            }
            await UpdateAsync(temailorder);
            return item.Id;
        }
        public Task<string> GetOrderNo()
        {
            return Task.Run(() => "HTL" + IdHelper.GetId());
        }

        public async Task EntryClerkAsync(List<string> orderNos)
        {
            try
            {
                // List<temailorder> emailorders = _db.GetIQueryable<temailorder>().Where(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && x.EntryClerkId == null).OrderByDescending(x => x.IsUrgent).ThenBy(x => x.ConfirmTime).ToList();
                if (orderNos.Count > 0)
                {
                    List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => orderNos.Contains(x.OrderNo)).ToList();
                    main.ForEach(x =>
                    {
                        x.IsEntryClerk = "1";
                        x.EntryClerkId = @operator.UserId;
                        x.EntryClerkName = @operator.Property.RealName;
                        x.EntryClerkTime = DateTime.Now;
                        x.InEntryClerkTime = x.InEntryClerkTime != null ? x.InEntryClerkTime : DateTime.Now;
                    });
                    int update = await _db.UpdateAsync(main);
                    LogHelper.LogInformation($"更新结果：" + update);
                }
                //List<Base_Dispatch> base_dispatches = _db.GetIQueryable<Base_Dispatch>().Where(a => a.IsOnline == 1).ToList();
                //if (emailorders.Count <= 0)
                //{
                //    return;
                //}
                ////取得在线的账号进行派单
                //foreach (Base_Dispatch base_Dispatch in base_dispatches)
                //{
                //    //已确认，未制单完成，且制单人是自己 非挂起单据 统计一下还有几票
                //    int needNum = (int)base_Dispatch.DispatchCount - _db.GetIQueryable<temailorder>().Count(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && x.IsPending != 1 && x.EntryClerkId == base_Dispatch.DispatchId);
                //    List<temailorder> list = emailorders.OrderBy(a => a.ConfirmTime).Take(needNum).ToList();
                //    foreach (var item in list)
                //    {
                //        item.EntryClerkId = @operator.UserId;
                //        item.EntryClerkName = @operator.Property.RealName;
                //        item.EntryClerkTime = DateTime.Now;
                //        item.InEntryClerkTime = DateTime.Now;
                //    }
                //    await _db.UpdateAsync(list);
                //}
            }
            catch (Exception ex)
            {
                LogHelper.LogInformation(ex.Message);
            }

        }
        public async Task UrgentAsync(List<string> orderNos, string userId)
        {
            List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => orderNos.Contains(x.OrderNo)).ToList();
            main.ForEach(x =>
            {
                x.IsUrgent = "1";
            });
            await _db.UpdateAsync(main);
            await ConfirmOrderAsync(orderNos, userId);
        }
        public async Task ConfirmOrderAsync(List<string> orderNos, string userId)
        {
            if (base_users.Count == 0)
            {
                base_users = _db.GetIQueryable<Base_User>().ToList();
            }
            // 进口接单部
            List<string> inUsers = base_users.Where(t => t.DepartmentId == "1664445802690383872").Select(x => x.Id).ToList();
            // 出口接单部
            List<string> outUsers = base_users.Where(t => t.DepartmentId == "1642823451355910144" || t.DepartmentId == "1642823507060461568").Select(x => x.Id).ToList();
            tsettingconfig settingconfig = _db.GetIQueryable<tsettingconfig>().FirstOrDefault();
            List<Base_Dispatch> base_dispatches = _db.GetIQueryable<Base_Dispatch>().Where(a => a.IsOnline == 1).OrderBy(x => x.DispatchId).ToList();
            List<temailorder> emailorders = _db.GetIQueryable<temailorder>().Where(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && x.CreateTime > DateTime.Now.AddDays(settingconfig != null ? -settingconfig.EmailListDataShowDays : -120)).ToList();
            List<temailorder> temailorders = _db.GetIQueryable<temailorder>().Where(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && !string.IsNullOrEmpty(x.EntryClerkId) && x.InEntryClerkTime != null && x.IsVerifier == "0" && x.CreateTime > DateTime.Now.AddDays(settingconfig != null ? -settingconfig.EmailListDataShowDays : -120)).ToList();
            List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => orderNos.Contains(x.OrderNo)).ToList();
            List<Dispatch> dispatches = new List<Dispatch>();
            foreach (Base_Dispatch base_dispatch in base_dispatches)//新增是否在线
            {
                int orderCount = temailorders.Where(x => x.EntryClerkId == base_dispatch.DispatchId).Count();
                dispatches.Add(new Dispatch()
                {
                    DispatchId = base_dispatch.DispatchId,
                    DispatchCount = base_dispatch.DispatchCount,
                    CurDispatchCount = orderCount
                });
            }
            foreach (var temailorder in main)
            {
                List<string> users = new List<string>();
                if (inUsers.Contains(@operator.UserId))
                {
                    users = inUsers;
                }
                if (outUsers.Contains(@operator.UserId))
                {
                    users = outUsers;
                }
                if (users.Count == 0)
                {
                    users = base_users.Select(x => x.Id).ToList();
                }
                Dispatch dispatch = dispatches.Where(x => x.CurDispatchCount < x.DispatchCount && users.Contains(x.DispatchId)).OrderBy(x => x.CurDispatchCount).ThenBy(x => x.DispatchId).FirstOrDefault();
                if (dispatch != null)
                {
                    foreach (var item in dispatches)
                    {
                        if (item.DispatchId == dispatch.DispatchId)
                        {
                            item.CurDispatchCount += 1;
                        }
                    }
                }
                temailorder.IsConfirmOrder = "1";
                temailorder.ConfirmId = @operator.UserId;
                temailorder.ConfirmName = @operator.Property.RealName;
                temailorder.ConfirmTime = DateTime.Now;
                temailorder.IsReject = "0";
                if (userId.IsNullOrEmpty())
                {
                    temailorder.EntryClerkId = dispatch != null ? dispatch.DispatchId : null;
                    temailorder.EntryClerkName = dispatch != null ? base_users.Where(x => x.Id == dispatch.DispatchId).FirstOrDefault()?.RealName : null;
                    temailorder.InEntryClerkTime = dispatch != null ? DateTime.Now : null;
                }
                else
                {
                    temailorder.EntryClerkId = userId;
                    temailorder.EntryClerkName = base_users.Where(x => x.Id == userId).FirstOrDefault()?.RealName;
                    temailorder.InEntryClerkTime = DateTime.Now;
                }

                //if (emailorders.Count <= 0)
                //{
                //    return;
                //}
                //取得在线的账号进行派单
                //foreach (Base_Dispatch base_Dispatch in base_dispatches)
                //{
                //    //已确认,未制单完成,且制单人是自己 非挂起单据 统计一下还有机票
                //    int needNum = (int)base_Dispatch.DispatchCount - _db.GetIQueryable<temailorder>().Count(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && x.IsPending != 1 && x.EntryClerkId == base_Dispatch.DispatchId);
                //    List<temailorder> list = emailorders.OrderBy(a => a.ConfirmTime).Take(needNum).ToList();
                //    foreach (var item in list)
                //    {
                //        item.EntryClerkId = @operator.UserId;
                //        item.EntryClerkName = @operator.Property.RealName;
                //        item.EntryClerkTime = DateTime.Now;
                //        item.InEntryClerkTime = DateTime.Now;
                //    }
                //    //await _db.UpdateAsync(list);
                //}
            }

            await _db.UpdateAsync(main);
        }
        public async Task<List<string>> IsExistBillNoAsync(List<string> orderNos)
        {
            List<string> decs = await _db.GetIQueryable<temailorder>().Where(x => orderNos.Contains(x.OrderNo)).Select(x => x.Description).ToListAsync();
            List<string> billNos = new List<string>();
            foreach (var dec in decs)
            {
                string[] sArray = Regex.Split(dec, "\r\n|\r|\n", RegexOptions.IgnoreCase);
                foreach (var item in sArray)
                {
                    string pattern = @"【提运单号】(.*?)$";

                    System.Text.RegularExpressions.Match match = Regex.Match(item != null ? item : "", pattern);

                    if (match.Success)
                    {
                        string result = match.Groups[1].Value;  // 这将包含 "1111111111"
                        billNos.Add(result.ToUpper().Trim());

                    }
                }
            }
            return await _db.GetIQueryable<tdechead>().Where(x => billNos.Contains(x.BillNo)).Select(x => x.BillNo).Distinct().ToListAsync();
        }
        public async Task UpdateShipDataAsync(temailorder temailorder)
        {
            temailorder main = new temailorder();
            if (!temailorder.Id.IsNullOrEmpty())
            {
                main = _db.GetIQueryable<temailorder>().FirstOrDefault(x => x.Id == temailorder.Id);
            }
            else if (!temailorder.OrderNo.IsNullOrEmpty())
            {
                main = _db.GetIQueryable<temailorder>().FirstOrDefault(x => x.OrderNo == temailorder.OrderNo);
            }
            else
            {
                throw new BusException("订单ID或订单编号不能为空！");
            }
            main.DepartureTime = temailorder.DepartureTime;
            main.ArrivalTime = temailorder.ArrivalTime;
            main.CustomsCode = temailorder.CustomsCode;
            main.Sxkssj = temailorder.Sxkssj;
            main.Sxjssj = temailorder.Sxjssj;
            await _db.UpdateAsync(main);
        }
        public async Task UpdateFeeMarkAsync(string id, string type, string feename, string feecode)
        {
            temailorder main = new temailorder();
            if (!id.IsNullOrEmpty())
            {
                main = _db.GetIQueryable<temailorder>().FirstOrDefault(x => x.Id == id);
            }
            else
            {
                throw new BusException("订单ID不能为空！");
            }
            if (type == "1")
            {
                main.FeeMark = main.FeeMark.IsNullOrEmpty() ? "(" + feecode + ")" + feename : main.FeeMark + "|(" + feecode + ")" + feename;
            }
            else
            {
                main.FeeMark = main.FeeMark.Replace("|(" + feecode + ")" + feename, "").Replace("(" + feecode + ")" + feename, "");
            }
            await _db.UpdateAsync(main);
        }
        public async Task UpdateInspectionDataAsync(temailorder temailorder)
        {
            temailorder main = _db.GetIQueryable<temailorder>().FirstOrDefault(x => x.Id == temailorder.Id);
            main.SignDate = temailorder.SignDate;
            main.ValidDate = temailorder.ValidDate;
            main.InspectionResult = temailorder.InspectionResult;
            await _db.UpdateAsync(main);
        }
        public async Task UpdateManifestArrivalAsync(temailorder temailorder)
        {
            temailorder main = _db.GetIQueryable<temailorder>().FirstOrDefault(x => x.OrderNo == temailorder.OrderNo);
            if (main != null)
            {
                main.IsManifest = temailorder.IsManifest;
                main.IsArrival = temailorder.IsArrival;
                main.HGManifestTime = temailorder.HGManifestTime;
                main.HGArrivalTime = temailorder.HGArrivalTime;
                main.MACheckResult = temailorder.MACheckResult;
                main.MAInterfaceResult = temailorder.MAInterfaceResult;
                await _db.UpdateAsync(main);
            }
            else
            {
                throw new BusException("订单编号查不到！");
            }
        }
        [Transactional]
        public async Task<int> EmailUpdateStatus(EmailUpdateStatus updateStatus)
        {
            string orderNo = "";
            if (!string.IsNullOrEmpty(updateStatus.OrderNo))
            {
                orderNo = updateStatus.OrderNo;
                if (!string.IsNullOrEmpty(updateStatus.SeqNo) && !string.IsNullOrEmpty(updateStatus.DeclarationStatus))
                {
                    tdechead tdechead = await _db.GetIQueryable<tdechead>().FirstOrDefaultAsync(p => p.OrderNo == updateStatus.OrderNo);
                    tdechead.SeqNo = updateStatus.SeqNo;
                    if (!string.IsNullOrEmpty(updateStatus.CusDecStatus))
                    {
                        tdechead.CusDecStatus = updateStatus.CusDecStatus;
                        tdechead.CusDecStatusName = updateStatus.CusDecStatusName;
                    }
                    if (!string.IsNullOrEmpty(updateStatus.EntryId))
                    {
                        tdechead.EntryId = updateStatus.EntryId;
                    }
                    if (!string.IsNullOrEmpty(updateStatus.DDate))
                    {
                        tdechead.DDate = updateStatus.DDate;
                    }
                    await _db.UpdateAsync(tdechead);
                }

                if (!string.IsNullOrEmpty(updateStatus.SeqNo) && !string.IsNullOrEmpty(updateStatus.INVDeclarationStatus))
                {
                    tinvthead invthead = await _db.GetIQueryable<tinvthead>().FirstOrDefaultAsync(p => p.OrderNo == updateStatus.OrderNo);
                    invthead.SeqNo = updateStatus.SeqNo;
                    invthead.BondInvtNo = updateStatus.BondInvtNo;
                    await _db.UpdateAsync(invthead);
                }
            }
            else
            {

                if (!string.IsNullOrEmpty(updateStatus.SeqNo) && !string.IsNullOrEmpty(updateStatus.DeclarationStatus))
                {
                    tdechead tdechead = await _db.GetIQueryable<tdechead>().FirstOrDefaultAsync(p => p.SeqNo == updateStatus.SeqNo);
                    orderNo = tdechead.OrderNo;
                    if (!string.IsNullOrEmpty(updateStatus.CusDecStatus))
                    {
                        tdechead.CusDecStatus = updateStatus.CusDecStatus;
                        tdechead.CusDecStatusName = updateStatus.CusDecStatusName;
                    }
                    if (!string.IsNullOrEmpty(updateStatus.EntryId))
                    {
                        tdechead.EntryId = updateStatus.EntryId;
                    }
                    if (!string.IsNullOrEmpty(updateStatus.DDate))
                    {
                        tdechead.DDate = updateStatus.DDate;
                    }
                    await _db.UpdateAsync(tdechead);
                }

                if (!string.IsNullOrEmpty(updateStatus.SeqNo) && !string.IsNullOrEmpty(updateStatus.INVDeclarationStatus))
                {
                    tinvthead invthead = await _db.GetIQueryable<tinvthead>().FirstOrDefaultAsync(p => p.OrderNo == updateStatus.OrderNo);
                    orderNo = invthead.OrderNo;
                    invthead.SeqNo = updateStatus.SeqNo;
                    invthead.BondInvtNo = updateStatus.BondInvtNo;
                    await _db.UpdateAsync(invthead);
                }

            }

            temailorder temailorder = await GetIQueryable().FirstOrDefaultAsync(p => p.OrderNo == orderNo);
            if (!string.IsNullOrEmpty(updateStatus.DeclarationStatus))
            {
                temailorder.DeclarationStatus = updateStatus.DeclarationStatus;
                temailorder.DeclarationReason = updateStatus.DeclarationReason;
            }
            if (!string.IsNullOrEmpty(updateStatus.INVDeclarationStatus))
            {
                temailorder.INVDeclarationStatus = updateStatus.INVDeclarationStatus;
                temailorder.INVDeclarationReason = updateStatus.INVDeclarationReason;
            }
            ///电子委托
            if (!string.IsNullOrEmpty(updateStatus.EntrustedStatus))
            {
                tedocrealation tedocrealation = await Db.GetIQueryable<tedocrealation>().FirstOrDefaultAsync(p => p.OrderNo == orderNo && (p.EdocCode == "00000008" || p.EdocCode == "10000001"));
                if (tedocrealation == null)
                {
                    temailorder.EntrustedStatus = updateStatus.EntrustedStatus;
                    temailorder.EntrustedReason = updateStatus.EntrustedReason;
                }
            }
            else
            {
                temailorder.EntrustedStatus = null;
                temailorder.EntrustedReason = null;
            }
            return await _db.UpdateAsync(temailorder);
        }
        public async Task<List<tbasecustomerbgremark>> GetRemark(string orderNo)
        {
            var query = from a in _db.GetIQueryable<temailorder>().Where(t => t.OrderNo == orderNo)
                        join b in _db.GetIQueryable<tbasecustomerbgremark>()
                        on a.CustomerId equals b.CId
                        select new tbasecustomerbgremark
                        {
                            TradeName = b.TradeName,
                            Remark = b.Remark
                        };
            var data = await query.ToListAsync();

            return data;
        }
        public async Task<bool> UpdatePrintState(string orderNo)
        {
            temailorder emailorder = _db.GetIQueryable<temailorder>().FirstOrDefault(t => t.OrderNo == orderNo);
            emailorder.IsPrint = 1;
            return await _db.UpdateAsync(emailorder) > 1;

        }
        public async Task<bool> IsPending(string orderNo)
        {
            temailorder emailorder = _db.GetIQueryable<temailorder>().FirstOrDefault(t => t.OrderNo == orderNo);
            emailorder.IsPending = 1;
            emailorder.PendingTime = DateTime.Now;
            int i = await _db.UpdateAsync(emailorder);
            //await EntryClerkAsync(new List<string>());
            return await Task.Run(() => i >= 1 ? true : false);

        }
        public async Task TransferOrder(List<string> orderNos, string userId, string username)
        {
            List<temailorder> emailorders = _db.GetIQueryable<temailorder>().Where(t => orderNos.Contains(t.OrderNo)).ToList();
            foreach (var item in emailorders)
            {
                item.EntryClerkId = userId;
                item.EntryClerkName = username;
                item.InEntryClerkTime = DateTime.Now;
            }
            await UpdateAsync(emailorders);
            //await EntryClerkAsync(new List<string>());
        }
        public async Task<bool> UpdateOnlineState(string DispatchId, int Online)
        {
            Base_Dispatch _Dispatch = _db.GetIQueryable<Base_Dispatch>().FirstOrDefault(t => t.DispatchId == DispatchId);
            if (_Dispatch == null)
            {
                return false;
            }
            _Dispatch.IsOnline = Online;
            //await EntryClerkAsync(new List<string>());
            return await _db.UpdateAsync(_Dispatch) > 1;
        }
        public async Task<bool> UpdateBGStates(string orderNo, List<BGBillState> bGBillStates)
        {
            var order = _db.GetIQueryable<temailorder>().FirstOrDefault(t => t.OrderNo == orderNo);
            var head = _db.GetIQueryable<tdechead>().FirstOrDefault(t => t.OrderNo == orderNo);
            BGBillState bGBillJ = bGBillStates.FirstOrDefault(a => a.Channel == "J");
            if (bGBillJ != null)
            {
                if (order != null)
                {
                    order.AuditTime = Convert.ToDateTime(bGBillJ.NoticeDate);
                }
                head.CusDecStatus = "7";
                head.CusDecStatusName = "审结";
            }
            BGBillState bGBillP = bGBillStates.FirstOrDefault(a => a.Channel == "P");
            if (bGBillP != null)
            {
                if (order != null)
                {
                    order.ReleaseTime = Convert.ToDateTime(bGBillP.NoticeDate);
                }

                head.CusDecStatus = "9";
                head.CusDecStatusName = "放行";
            }

            BGBillState bGBillR = bGBillStates.FirstOrDefault(a => a.Channel == "R");
            if (bGBillR != null)
            {
                if (order != null)
                {
                    order.ClearanceTime = Convert.ToDateTime(bGBillR.NoticeDate);
                }

                head.CusDecStatus = "10";
                head.CusDecStatusName = "结关";
            }
            if (head != null)
            {
                await _db.UpdateAsync(head);
            }
            if (order != null)
            {
                await _db.UpdateAsync(order);
            }
            return true;

        }
        public async Task<temailinfo> GetDataListJoinAttachment(string id)
        {
            temailinfo temailinfo = new temailinfo();
            temailorder temailorder = await _db.GetIQueryable<temailorder>().Where(t => t.InboxId == id).FirstOrDefaultAsync();
            tinboxcontent tinboxcontent = await _db.GetIQueryable<tinboxcontent>().Where(t => t.Id == id).FirstOrDefaultAsync();
            List<tinboxattachment> tinboxattachments = await _db.GetIQueryable<tinboxattachment>().Where(t => t.InboxId == id).ToListAsync();
            temailinfo.temailorder = temailorder;
            temailinfo.tinboxcontent = tinboxcontent;
            temailinfo.tinboxattachments = tinboxattachments;
            return temailinfo;
        }
        public async Task SaveDataJoinAttachment(temailinfo temailinfo)
        {
            await _db.DeleteAsync<tinboxattachment>(x => x.InboxId == temailinfo.tinboxcontent.Id);

            await _db.UpdateAsync<temailorder>(temailinfo.temailorder);

            temailinfo.tinboxcontent.HtmlContent = null;

            temailinfo.tinboxcontent.TextContent = null;

            await _db.UpdateAsync<tinboxcontent>(temailinfo.tinboxcontent);

            foreach (var tinboxattachment in temailinfo.tinboxattachments)
            {
                tinboxattachment.InboxId = temailinfo.tinboxcontent.Id;
            }

            await _db.InsertAsync<tinboxattachment>(temailinfo.tinboxattachments);
        }
        public async Task<temailorder> GetTheDataByOrderNoAsync(string orderNo)
        {
            temailorder temailorder = await _db.GetIQueryable<temailorder>().Where(x => x.OrderNo == orderNo).FirstOrDefaultAsync();
            return temailorder;
        }
        public async Task RevokeOrderAsync(RejectDTO rejectDTO)
        {
            if (rejectDTO.OrderType == OrderType.制单区)
            {
                List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => rejectDTO.OrderNos.Contains(x.OrderNo)).ToList();
                main.ForEach(x =>
                {
                    x.IsEntryClerk = "0";
                    x.EntryClerkName = null;
                    x.EntryClerkId = null;
                    x.EntryClerkTime = null;
                    x.IsConfirmOrder = "0";
                    x.ConfirmName = null;
                    x.ConfirmId = null;
                    x.ConfirmTime = null;
                    x.IsUrgent = "0";
                    x.IsReject = "1";
                    x.RejectName = @operator.Property.RealName;
                    x.RejectId = @operator.UserId;
                    x.RejectTime = DateTime.Now;
                    x.RejectReason = rejectDTO.RejectReason;
                });
                await _db.UpdateAsync(main);
            }
            else if (rejectDTO.OrderType == OrderType.审单区)
            {
                List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => rejectDTO.OrderNos.Contains(x.OrderNo)).ToList();
                main.ForEach(x =>
                {
                    x.IsEntryClerk = "0";
                    x.IsVerifier = "0";
                    x.VerifierId = null;
                    x.VerifierName = null;
                    x.VerifierTime = null;
                    x.IsUrgent = "0";
                    x.IsReject = "1";
                    x.RejectName = @operator.Property.RealName;
                    x.RejectId = @operator.UserId;
                    x.RejectTime = DateTime.Now;
                    x.RejectReason = rejectDTO.RejectReason;
                });
                await _db.UpdateAsync(main);
            }
            else
            {
                throw new BusException("当前状态不可操作！");
            }
        }

        [Transactional]
        public async Task SplitBillAsync(SplitBillInfo info)
        {
            temailorder temailorder = await _db.GetIQueryable<temailorder>().Where(t => t.OrderNo == info.OrderNo).FirstOrDefaultAsync();
            if (temailorder == null)
            {
                throw new BusException("订单号不存在！");
            }
            tinboxcontent tinboxcontent = await _db.GetIQueryable<tinboxcontent>().Where(t => t.Id == temailorder.InboxId).FirstOrDefaultAsync();
            List<tinboxattachment> tinboxattachments = await _db.GetIQueryable<tinboxattachment>().Where(t => info.AttachmentIds.Contains(t.Id)).ToListAsync();
            await _db.DeleteAsync<tinboxattachment>(info.AttachmentIds);
            tinboxcontent.Id = IdHelper.GetId();
            tinboxcontent.Subject = tinboxcontent.Subject + "（拆单）";
            tinboxcontent.CreateTime = DateTime.Now;
            tinboxcontent.CreatorId = @operator.UserId;
            temailorder.Id = IdHelper.GetId();
            temailorder.OrderNo = "HTL" + DateTime.Now.ToString("yyyyMMddHHmmssffffff");
            temailorder.CreateTime = DateTime.Now;
            temailorder.CreatorId = @operator.UserId;
            temailorder.InboxId = tinboxcontent.Id;
            temailorder.Subject = tinboxcontent.Subject;
            foreach (var item in tinboxattachments)
            {
                item.Id = IdHelper.GetId();
                item.CreateTime = DateTime.Now;
                item.CreatorId = @operator.UserId;
                item.InboxId = tinboxcontent.Id;
            }
            await _db.InsertAsync(temailorder);
            await _db.InsertAsync(tinboxcontent);
            await _db.InsertAsync(tinboxattachments);
        }

        public async Task<List<SingleStatisticsOutput>> GetSingleStatistics(SingleStatisticsInput singleStatisticsInput)
        {
            #region 测试
            // 计算日期范围外的变量，避免在每次比较时都调用
            //DateTime? startDate = singleStatisticsInput.StartDate;
            //DateTime? endDate = singleStatisticsInput.EndDate?.AddDays(1);

            //// 构建查询
            //var query = _db.GetIQueryable<temailorder>()
            //               .Where(t => (!string.IsNullOrEmpty(t.EntryClerkName) && t.IsEntryClerk == "1") ||
            //                           (!string.IsNullOrEmpty(t.RejectName) && t.IsReject == "1"));

            //// 应用日期过滤
            //if (startDate.HasValue && endDate.HasValue)
            //{
            //    query = query.Where(t => (t.EntryClerkTime >= startDate.Value && t.EntryClerkTime < endDate.Value) ||
            //                             (t.RejectTime >= startDate.Value && t.RejectTime < endDate.Value));
            //}

            //// 应用客户简称过滤
            //if (!singleStatisticsInput.CustomerShortName.IsNullOrEmpty())
            //{
            //    query = query.Where(t => t.CustomerShortName == singleStatisticsInput.CustomerShortName);
            //}

            //// 在内存中进行分组和选择
            //var groupQuery = query.ToList().GroupBy(a => a.IsEntryClerk == "1" ? a.EntryClerkName : a.RejectName)
            //                      .Select(grouped => new
            //                      {
            //                          EntryClerkName = grouped.Key,
            //                          VoteNumber = grouped.Count(x => x.IsEntryClerk == "1"),
            //                          OrderNos = grouped.Where(x => x.IsEntryClerk == "1").Select(a => a.OrderNo),
            //                          RejectCount = grouped.Count(x => x.IsReject == "1")
            //                      });

            //// 获取所有订单号码
            //var allOrderNos = groupQuery.SelectMany(g => g.OrderNos).Distinct().ToList();

            //// 获取tdeclist计数
            //var tdeclistCounts = _db.GetIQueryable<tdeclist>()
            //                        .Where(t => allOrderNos.Contains(t.OrderNo))
            //                        .GroupBy(b => b.OrderNo)
            //                        .Select(g => new { OrderNo = g.Key, Count = g.Count() })
            //                        .ToDictionary(g => g.OrderNo, g => g.Count);

            //// 构建最终输出
            //var outputs = groupQuery.ToList() // 将groupQuery的结果加载到内存中
            //                .Select(grouped => new SingleStatisticsOutput
            //                {
            //                    EntryClerkName = grouped.EntryClerkName,
            //                    VoteNumber = grouped.VoteNumber,
            //                    ProductNumber = grouped.OrderNos.Sum(orderNo => tdeclistCounts.ContainsKey(orderNo) ? tdeclistCounts[orderNo] : 0),
            //                    RejectCount = grouped.RejectCount
            //                }).ToList();



            #endregion
            var temailorders = _db.GetIQueryable<temailorder>()
                         .Where(t => (!string.IsNullOrEmpty(t.EntryClerkName) && t.IsEntryClerk == "1") || (!string.IsNullOrEmpty(t.RejectName) && t.IsReject == "1"))
                         .WhereIf(!singleStatisticsInput.StartDate.IsNullOrEmpty() && !singleStatisticsInput.EndDate.IsNullOrEmpty(), t => (t.EntryClerkTime >= singleStatisticsInput.StartDate.Value && t.EntryClerkTime <= singleStatisticsInput.EndDate.Value) || (t.RejectTime >= singleStatisticsInput.StartDate.Value && singleStatisticsInput.EndDate.Value >= t.RejectTime))
                         .WhereIf(!singleStatisticsInput.CustomerShortName.IsNullOrEmpty(), t => t.CustomerShortName == singleStatisticsInput.CustomerShortName)
                         .WhereIf(!string.IsNullOrEmpty(singleStatisticsInput.OperatorName), t => t.OperatorName == singleStatisticsInput.OperatorName)
                         .WhereIf(!singleStatisticsInput.EntryClerkName.IsNullOrEmpty(), t => t.EntryClerkName == singleStatisticsInput.EntryClerkName || t.RejectName == singleStatisticsInput.EntryClerkName)
                         .ToList();
            var temailorderList = temailorders
                         .GroupBy(a => !string.IsNullOrEmpty(a.EntryClerkName) ? a.EntryClerkName : a.RejectName)
                         .Select(grouped => new
                         {
                             EntryClerkName = grouped.Key,
                             VoteNumber = grouped.Count(x => !string.IsNullOrEmpty(x.EntryClerkName)),
                             OrderNos = grouped.Where(x => !string.IsNullOrEmpty(x.EntryClerkName)).Select(a => a.OrderNo).ToList(),
                             RejectCount = grouped.Count(x => !string.IsNullOrEmpty(x.RejectName))
                         })
                         .ToList();
            var allOrderNos = temailorderList.SelectMany(grouped => grouped.OrderNos).ToList();
            var tdeclistCounts = _db.GetIQueryable<tdeclist>()
                                    .Where(t => allOrderNos.Contains(t.OrderNo))
                                    .ToList()
                                    .GroupBy(b => b.OrderNo)
                                    .ToDictionary(g => g.Key, g => g.Count());
            var outputs = temailorderList.Select(grouped => new SingleStatisticsOutput
            {
                EntryClerkName = grouped.EntryClerkName,
                VoteNumber = grouped.VoteNumber,
                ProductNumber = grouped.OrderNos.Sum(orderNo => tdeclistCounts.ContainsKey(orderNo) ? tdeclistCounts[orderNo] : 0),
                RejectCount = grouped.RejectCount
            }).ToList();
            return outputs;
        }
        public async Task<List<SingleSummaryOutput>> GetSingleSummary(SingleSummaryInput singleSummaryInput)
        {
            var r = _db.GetIQueryable<tbasecustomerrelation>();
            var q = from a in _db.GetIQueryable<temailorder>().Where(t => !string.IsNullOrEmpty(t.CustomerShortName) && t.IsVerifier == "1")
                    join b in _db.GetIQueryable<tdechead>() on a.OrderNo equals b.OrderNo into ab
                    from b in ab.DefaultIfEmpty()
                    join c in _db.GetIQueryable<tbasecustomer>() on a.CustomsCode equals c.CustomsCode into ac
                    from c in ac.DefaultIfEmpty()
                    select new
                    {
                        CustomerShortName = a.CustomerShortName,
                        CusDecStatusName = b.CusDecStatusName,
                        TradeName = b.TradeName,
                        Relations = r.Where(t => t.CId == c.Id).Select(t => t.Id).ToList()

                    };
            var temailorderList = q.Where(t => t.CusDecStatusName != "保存")
                .WhereIf(!singleSummaryInput.TradeName.IsNullOrEmpty(), t => t.TradeName.Contains(singleSummaryInput.TradeName))
                .WhereIf(!singleSummaryInput.SalespersonId.IsNullOrEmpty(), t => t.Relations.Contains(singleSummaryInput.SalespersonId))
                .WhereIf(!singleSummaryInput.CustomerId.IsNullOrEmpty(), t => t.Relations.Contains(singleSummaryInput.CustomerId))
                .ToList()
                .GroupBy(a => a.CustomerShortName)
                .Select(grouped => new
                {
                    CustomerShortName = grouped.Key,
                    VoteNumber = grouped.Count()
                })
                .ToList();
            var outputs = temailorderList.Select(grouped => new SingleSummaryOutput
            {
                CustomerShortName = grouped.CustomerShortName,
                VoteNumber = grouped.VoteNumber
            }).ToList();
            return outputs;
        }
        private async Task DeleteOrder(List<string> orderNos)
        {
            List<temailorder> temailorders = _db.GetIQueryable<temailorder>().Where(t => orderNos.Contains(t.OrderNo)).ToList();
            List<string> inboxIds = temailorders.Select(t => t.InboxId).Distinct().ToList();
            await _db.DeleteAsync(temailorders);
            await _db.DeleteSqlAsync<tinboxcontent>(t => inboxIds.Contains(t.Id));
            await _db.DeleteSqlAsync<tinboxattachment>(t => inboxIds.Contains(t.InboxId));
        }
        private async Task DeleteDec(List<string> orderNos)
        {
            List<temailorder> temailorders = _db.GetIQueryable<temailorder>().Where(t => orderNos.Contains(t.OrderNo)).ToList();
            foreach (var item in temailorders)
            {
                item.IsConfirmOrder = "0";
                item.ConfirmId = null;
                item.ConfirmName = null;
                item.ConfirmTime = null;
                item.IsEntryClerk = "0";
                item.EntryClerkId = null;
                item.EntryClerkName = null;
                item.EntryClerkTime = null;
                item.InEntryClerkTime = null;
                item.IsReviewer = "0";
                item.ReviewerId = null;
                item.ReviewerName = null;
                item.ReviewerTime = null;
                item.IsVerifier = "0";
                item.VerifierId = null;
                item.VerifierName = null;
                item.VerifierTime = null;
                item.CusDecStatus = null;
                item.CusDecStatusName = null;
                item.EntrustedStatus = null;
                item.EntrustedReason = null;
            }
            await _db.UpdateAsync<temailorder>(temailorders);
            await _db.DeleteSqlAsync<tdechead>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdeclist>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdeccontainer>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdeclicensedocus>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecotherpack>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tedocrealation>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecuser>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdeccoplimit>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecrequestcert>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecgoodslimit>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecgoodslimitvin>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecfreetxt>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdecsign>(t => orderNos.Contains(t.OrderNo));
            await _db.DeleteSqlAsync<tdeccoppromise>(t => orderNos.Contains(t.OrderNo));
        }
        [Transactional]
        public async Task DeleteDocAsync(List<string> orderNos, string type)
        {
            if (orderNos.IsNullOrEmpty() || orderNos.Count < 1)
            {
                throw new BusException("订单号不能为空");
            }
            switch (type)
            {
                case "1":
                    await DeleteOrder(orderNos);
                    break;
                case "2":
                    await DeleteDec(orderNos);
                    break;
                case "3":
                    await DeleteOrder(orderNos);
                    await DeleteDec(orderNos);
                    break;
                default:
                    throw new BusException("暂不支持此类型");
            }
        }

        public async Task UpdateDepotDataAsync(temailorder temailorder)
        {
            temailorder main = _db.GetIQueryable<temailorder>().FirstOrDefault(x => x.Id == temailorder.Id);
            main.DepotResult = temailorder.DepotResult;
            await _db.UpdateAsync(main);
        }

        public async Task<List<ExportOrderDto>> ExportOrderDataAsync(SingleStatisticsInput singleStatisticsInput)
        {
            var declist = Db.GetIQueryable<tdeclist>();
            var q = from a in Db.GetIQueryable<temailorder>().Where(t => t.IsEntryClerk == "1" && t.Subject != "单一窗口自动生成")
                    .WhereIf(!singleStatisticsInput.StartDate.IsNullOrEmpty() && !singleStatisticsInput.EndDate.IsNullOrEmpty(), t => t.EntryClerkTime >= singleStatisticsInput.StartDate.Value && t.EntryClerkTime <= singleStatisticsInput.EndDate.Value.AddDays(1))
                    .WhereIf(!singleStatisticsInput.CustomerShortName.IsNullOrEmpty(), t => t.CustomerShortName == singleStatisticsInput.CustomerShortName)
                    join b in Db.GetIQueryable<tdechead>() on a.OrderNo equals b.OrderNo into ab
                    from b in ab.DefaultIfEmpty()
                    select new ExportOrderDto
                    {
                        BillNo = b.BillNo,
                        OperatorName = a.OperatorName,
                        EntryClerkName = a.EntryClerkName,
                        CustomerShortName = a.CustomerShortName,
                        ContactName = a.ContactName,
                        SendTime = a.SendTime,
                        ConfirmTime = a.ConfirmTime,
                        EntryClerkTime = a.EntryClerkTime,
                        OverseasConsigneeEname = b.OverseasConsigneeEname,
                        CommodityQuantity = declist.Where(t => t.OrderNo == a.OrderNo).Count(),
                        IsUrgent = a.IsUrgent == "1",
                        IsManual = !b.ManualNo.IsNullOrEmpty(),
                        IsAfter6PM = a.ConfirmTime.HasValue && a.ConfirmTime.Value.TimeOfDay >= new TimeSpan(18, 0, 0),
                        IsAfter8PM = a.ConfirmTime.HasValue && a.ConfirmTime.Value.TimeOfDay >= new TimeSpan(20, 0, 0),
                        IsWeekend = a.ConfirmTime.HasValue && a.ConfirmTime.Value.DayOfWeek == DayOfWeek.Saturday || a.ConfirmTime.HasValue && a.ConfirmTime.Value.DayOfWeek == DayOfWeek.Sunday,
                        HasTemplate = false
                    };
            return await q.ToListAsync();
        }

        public async Task UpdateCustomerAsync(temailorder data)
        {
            await _db.UpdateAsync(data, new List<string>() { "CustomerId", "CustomerShortName", "ContactId", "ContactName" });
        }

        public async Task<SendInfoOutput> GetSendInfo(string seqNo)
        {
            var query = from a in _db.GetIQueryable<tdechead>().Where(t => t.SeqNo == seqNo)
                        join b in _db.GetIQueryable<temailorder>() on a.OrderNo equals b.OrderNo into ab
                        from b in ab.DefaultIfEmpty()
                        join c in _db.GetIQueryable<tinboxcontent>() on b.InboxId equals c.Id into ac
                        from c in ac.DefaultIfEmpty()
                        join d in _db.GetIQueryable<tinboxconfig>().Where(t => t.EmailState == "True") on c.Recipient equals d.EmailAddress into cd
                        from d in cd.DefaultIfEmpty()
                        join f in _db.GetIQueryable<tedocrealation>().Where(t => t.EdocCode == "10000001") on a.OrderNo equals f.OrderNo into af
                        from f in af.DefaultIfEmpty()
                        select new SendInfoOutput
                        {
                            OrderNo = a.OrderNo,
                            SendAddress = c.SenderEmailAddress,
                            EmailAddress = d.EmailAddress,
                            EmailPassword = d.EmailPassword,
                            TrafName = a.TrafName,
                            CusVoyageNo = a.CusVoyageNo,
                            EmailType = d.EmailType,
                            BillNo = a.BillNo,
                            SeqNo = a.SeqNo,
                            TradeName = a.TradeName,
                            EdocID = f.EdocID,
                            OperatorId = b.OperatorId,
                            EmailId = c.EmailId
                        };
            SendInfoOutput sendInfo = await query.FirstOrDefaultAsync();
            List<temailcontent> temailcontents = await _db.GetIQueryable<temailcontent>().Where(t => t.CreatorId == sendInfo.OperatorId).ToListAsync();
            sendInfo.Temailcontents = temailcontents;
            return sendInfo;
        }

        public async Task UpdateInputId(string orderNo, bool open)
        {
            List<string> inputId = new List<string>();
            temailorder emailorder = Db.GetIQueryable<temailorder>().Where(x => x.OrderNo == orderNo).FirstOrDefault();
            if (emailorder != null)
            {
                if (!string.IsNullOrEmpty(emailorder.InputId))
                {
                    inputId = emailorder.InputId.Split(',').ToList();
                }
                if (open)
                {
                    if (!inputId.Contains(@operator.Property.Id))
                    {
                        inputId.Add(@operator.Property.Id);
                    }
                }
                else
                {
                    inputId = inputId.Where(x => x != @operator.Property.Id).ToList();
                }
                emailorder.InputId = string.Join(',', inputId);
                await Db.UpdateAsync(emailorder, new List<string> { "InputId" });
            }
        }
        public async Task UpdateActiveClients(List<string> activeClients)
        {
            List<string> inputId = new List<string>();
            List<temailorder> emailorders = Db.GetIQueryable<temailorder>().Where(x => !string.IsNullOrEmpty(x.InputId)).ToList();
            foreach (var emailorder in emailorders)
            {
                //temailorder emailorder = emailorders.Where(x => x.InputId.Contains()).FirstOrDefault();
                if (emailorder != null)
                {
                    if (!string.IsNullOrEmpty(emailorder.InputId))
                    {
                        inputId = emailorder.InputId.Split(',').Where(id => activeClients.Contains(id)).ToList();
                    }
                    emailorder.InputId = string.Join(',', inputId);
                }
            }
            await Db.UpdateAsync(emailorders, new List<string> { "InputId" });
            List<Base_Dispatch> dispatches = _db.GetIQueryable<Base_Dispatch>().ToList();
            foreach (var item in dispatches)
            {
                if (activeClients.Contains(item.DispatchId) && item.IsOnline == 1)
                {
                    item.IsOnline = 1;
                }
                else
                {
                    item.IsOnline = 0;
                }
            }
            await Db.UpdateAsync(dispatches);
        }

        public async Task<temailallGroup> GetAllGroup()
        {
            // 获取当前日期的零点时间
            DateTime startOfDay = DateTime.Today;
            // 获取当前时间
            DateTime now = DateTime.Now;


            var orders = await GetIQueryable()
                .Where(x => (x.RejectTime >= startOfDay && x.RejectTime <= now) ||
                            (x.ConfirmTime >= startOfDay && x.ConfirmTime <= now) ||
                            (x.EntryClerkTime >= startOfDay && x.EntryClerkTime <= now))
                .ToListAsync();


            var temailallGroup = new temailallGroup
            {
                // 计算当天确认的订单数量
                IsConfirmOrder = orders.Count(x => x.IsConfirmOrder == "1" && x.IsEntryClerk != "1").ToString(),
                // 计算当天被驳回的订单数量
                IsReject = orders.Count(x => x.IsReject == "1").ToString(),
                // 计算当天完成的订单数量
                IsEntryClerk = orders.Count(x => x.IsEntryClerk == "1").ToString()
            };

            return temailallGroup;
        }

        public async Task AutoDispatchOrder()
        {
            if (base_users.Count == 0)
            {
                base_users = _db.GetIQueryable<Base_User>().ToList();
            }
            // 进口接单部
            List<string> inUsers = base_users.Where(t => t.DepartmentId == "1664445802690383872").Select(x => x.Id).ToList();
            // 出口接单部
            List<string> outUsers = base_users.Where(t => t.DepartmentId == "1642823451355910144" || t.DepartmentId == "1642823507060461568").Select(x => x.Id).ToList();
            LogHelper.LogInformation("自动派单，每1分钟!" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("自动派单，每1分钟!" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            try
            {
                List<Base_Dispatch> base_dispatches = _db.GetIQueryable<Base_Dispatch>().Where(a => a.IsOnline == 1).ToList();
                if (base_dispatches.Count > 0)
                {
                    tsettingconfig settingconfig = _db.GetIQueryable<tsettingconfig>().FirstOrDefault();
                    List<temailorder> main = _db.GetIQueryable<temailorder>().Where(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && x.EntryClerkId == null && x.CreateTime > DateTime.Now.AddDays(settingconfig != null ? -settingconfig.EmailListDataShowDays : -120)).ToList();
                    List<temailorder> temailorders = _db.GetIQueryable<temailorder>().Where(x => x.IsConfirmOrder == "1" && x.IsEntryClerk == "0" && !string.IsNullOrEmpty(x.EntryClerkId) && x.InEntryClerkTime != null && x.IsVerifier == "0" && x.CreateTime > DateTime.Now.AddDays(settingconfig != null ? -settingconfig.EmailListDataShowDays : -120)).ToList();
                    List<Dispatch> dispatches = new List<Dispatch>();
                    foreach (Base_Dispatch base_dispatch in base_dispatches)//新增是否在线
                    {
                        int orderCount = temailorders.Where(x => x.EntryClerkId == base_dispatch.DispatchId).Count();
                        dispatches.Add(new Dispatch()
                        {
                            DispatchId = base_dispatch.DispatchId,
                            DispatchCount = base_dispatch.DispatchCount,
                            CurDispatchCount = orderCount
                        });
                    }
                    foreach (var temailorder in main)
                    {
                        List<string> users = new List<string>();
                        if (inUsers.Contains(temailorder.ConfirmId))
                        {
                            users = inUsers;
                        }
                        if (outUsers.Contains(temailorder.ConfirmId))
                        {
                            users = outUsers;
                        }
                        if (users.Count == 0)
                        {
                            users = base_users.Select(x => x.Id).ToList();
                        }
                        LogHelper.LogInformation(JsonConvert.SerializeObject(dispatches));
                        Dispatch dispatch = dispatches.Where(x => x.CurDispatchCount < x.DispatchCount && users.Contains(x.DispatchId)).OrderBy(x => x.CurDispatchCount).FirstOrDefault();
                        if (dispatch != null)
                        {
                            foreach (var item in dispatches)
                            {
                                if (item.DispatchId == dispatch.DispatchId)
                                {
                                    item.CurDispatchCount += 1;
                                }
                            }
                        }
                        temailorder.IsReject = "0";
                        temailorder.EntryClerkId = dispatch != null ? dispatch.DispatchId : null;
                        temailorder.EntryClerkName = dispatch != null ? base_users.Where(x => x.Id == dispatch.DispatchId).FirstOrDefault()?.RealName : null;
                        temailorder.InEntryClerkTime = dispatch != null ? DateTime.Now : null;
                    }

                    await _db.UpdateAsync(main);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogInformation(ex.Message);
            }

        }
        #endregion

        #region 私有成员

        #endregion
    }

    public class ConditionDTO1
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string? blNo { get; set; }
    }

}