using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class EmailOrderDto
    {
        public String Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }

        /// <summary>
        /// 收件箱Id
        /// </summary>
        public String InboxId { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public String CustomerId { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        public String CustomerShortName { get; set; }

        /// <summary>
        /// 操作员Id
        /// </summary>
        public String OperatorId { get; set; }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public String OperatorName { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public String Subject { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 客服Id
        /// </summary>
        public String CustomerServiceId { get; set; }

        /// <summary>
        /// 客服名称
        /// </summary>
        public String CustomerServiceName { get; set; }

        /// <summary>
        /// 分票
        /// </summary>
        public Int32? Ticket { get; set; }

        /// <summary>
        /// 受理人Id
        /// </summary>
        public String HandlerId { get; set; }

        /// <summary>
        /// 受理人名称
        /// </summary>
        public String HandlerName { get; set; }

        /// <summary>
        /// 录单人Id
        /// </summary>
        public String EntryClerkId { get; set; }

        /// <summary>
        /// 录单人名称
        /// </summary>
        public String EntryClerkName { get; set; }

        /// <summary>
        /// 是否录单完成1-是0-否
        /// </summary>
        public String IsEntryClerk { get; set; }

        /// <summary>
        /// 修订次数
        /// </summary>
        public String RevisionNo { get; set; }

        /// <summary>
        /// 审单人Id
        /// </summary>
        public String VerifierId { get; set; }

        /// <summary>
        /// 审单人名称
        /// </summary>
        public String VerifierName { get; set; }

        /// <summary>
        /// 是否审单完成1-是0-否
        /// </summary>
        public String IsVerifier { get; set; }

        /// <summary>
        /// 复核人Id
        /// </summary>
        public String ReviewerId { get; set; }

        /// <summary>
        /// 复核人名称
        /// </summary>
        public String ReviewerName { get; set; }

        /// <summary>
        /// 是否复核完成1-是0-否
        /// </summary>
        public String IsReviewer { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        public String Remark { get; set; }

        public string SeqNo { get; set; }
        public string CusDecStatusName { get; set; }
        public string BillNo { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string EntryId { get; set; }
        public string EntryType { get; set; }
        public string TradeCode { get; set; }
        public String TradeName { get; set; }
        public string DDate { get; set; }
        public String UserRemark { get; set; }
        public DateTime? EntryClerkTime { get; set; }
        public DateTime? VerifierTime { get; set; }
        public DateTime? ReviewerTime { get; set; }
        public DateTime? HandlerTime { get; set; }
        public string DeclarationStatus { get; set; }
        public string DeclarationReason { get; set; }
        public string INVDeclarationStatus { get; set; }
        public string INVDeclarationReason { get; set; }
        public string ContactId { get; set; }
        public string ContactName { get; set; }
        public string SenderEmailAddress { get; set; }
        public string IEFlag { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string CustomsCode { get; set; }
        public string Sxkssj { get; set; }
        public string Sxjssj { get; set; }
        public string ManualNo { get; set; }
        public string TrafName { get; set; }
        public string CusVoyageNo { get; set; }
        /// <summary>
        /// 委托
        /// </summary>
        public string Entrust { get; set; }
        /// <summary>
        /// 商检
        /// </summary>
        public string Inspection { get; set; }
        /// <summary>
        /// 电子委托号
        /// </summary>
        public string EdocID { get; set; }
        public string SignDate { get; set; }
        public string ValidDate { get; set; }
        public string InspectionResult { get; set; }
        public string DocuCode { get; set; }
        public string CertCode { get; set; }
        public string IsManifest { get; set; }
        public string IsArrival { get; set; }
        public DateTime? HGManifestTime { get; set; }
        public DateTime? HGArrivalTime { get; set; }
        public string MACheckResult { get; set; }
        public string MAInterfaceResult { get; set; }
        public string ConfirmName { get; set; }
        public string ConfirmId { get; set; }
        public DateTime? ConfirmTime { get; set; }
        public string IsConfirmOrder { get; set; }
        public string IsUrgent { get; set; }
        public string IsReject { get; set; }
        public string Feedback { get; set; }
        public DateTime? RejectTime { get; set; }
        public string RejectName { get; set; }
        public string RejectId { get; set; }
        public string RejectReason { get; set; }
        public string EntrustedStatus { get; set; }
        public string EntrustedReason { get; set; }
        public int? IsPrint { get; set; }
        public string Attachment { get; set; }
        public int? IsOnline { get; set; }
        public int? IsPending { get; set; }
        public DateTime? InEntryClerkTime { get; set; }
        public DateTime? PendingTime { get; set; }
        public string AllTip { get; set; }
        public string AllTipValue { get; set; }
        public int? RevisionsNumber { get; set; }
        public string EncryptString { get; set; }
        public string Location { get; set; }
        public string FeeMark { get; set; }
        public string InputId { get; set; }
        public string InputStatus { get; set; }
        public string DepotResult { get; set; }
        public string CntrNos { get; set; }
        public int? GoodsNum { get; set; }
        public string DraftOrder { get; set; }
        public int? IsManual { get; set; }
        public string StartDate { get; set; }
    }
}
