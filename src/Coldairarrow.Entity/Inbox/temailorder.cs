using Coldairarrow.Entity.Dec;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Inbox
{
    /// <summary>
    /// 订单表，存储邮件相关订单信息。
    /// </summary>
    [Table("temailorder")]
    public class temailorder
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
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
        public String IsEntryClerk { get; set; } = "0";

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
        public String IsVerifier { get; set; } = "0";

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
        public String IsReviewer { get; set; } = "0";

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
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
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string CustomsCode { get; set; }
        public string Sxkssj { get; set; }
        public string Sxjssj { get; set; }

        public string SignDate { get; set; }
        public string ValidDate { get; set; }
        public string InspectionResult { get; set; }

        public string IsManifest { get; set; } = "0";
        public string IsArrival { get; set; } = "0";
        public DateTime? HGManifestTime { get; set; }
        public DateTime? HGArrivalTime { get; set; }
        public string MACheckResult { get; set; }
        public string MAInterfaceResult { get; set; }
        public string ConfirmName { get; set; }
        public string ConfirmId { get; set; }
        public DateTime? ConfirmTime { get; set; }
        public string IsConfirmOrder { get; set; } = "0";
        public string Description { get; set; }
        public string IsUrgent { get; set; } = "0";
        public string IsReject { get; set; } = "0";
        public string Feedback { get; set; }
        public string CheckResult { get; set; }
        public DateTime? RejectTime { get; set; }
        public string RejectName { get; set; }
        public string RejectId { get; set; }
        public string RejectReason { get; set; } 
        public string GenerateStatus { get; set; }
        public string EntrustedStatus { get; set; }
        public string EntrustedReason { get; set; }
        public DateTime? AuditTime { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public DateTime? ClearanceTime { get; set; }
        public int? IsPrint { get; set; } = 0;
        public int? IsOnline { get; set; } = 0;
        public int? IsPending { get; set; } = 0;
        public DateTime? InEntryClerkTime { get; set; }
        public DateTime? PendingTime { get; set; }
        public string DepotResult { get; set; }
        public string FeeMark { get; set; }
        public string InputId { get; set; }
        public string CusDecStatus { get; set; }
        public string CusDecStatusName { get; set; }

        public string StartDate { get; set; }
        public int? IsManual { get; set; } = 0;
    }

    public class temailorderjonhead : tdechead
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
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

        public String UserRemark { get; set; }
        public DateTime? EntryClerkTime { get; set; }
        public DateTime? VerifierTime { get; set; }
        public DateTime? ReviewerTime { get; set; }
        public DateTime? HandlerTime { get; set; }
        public string DeclarationStatus { get; set; }
        public string INVDeclarationStatus { get; set; }
        public string DeclarationReason { get; set; }
        public string INVDeclarationReason { get; set; }
        public string Description { get; set; }
        public string IsUrgent { get; set; }
        public string IsReject { get; set; }
        public string Feedback { get; set; }
        public string CheckResult { get; set; }
        public DateTime? RejectTime { get; set; }
        public string RejectName { get; set; }
        public string RejectId { get; set; }
        public string RejectReason { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
        public string CodeTS { get; set; }
        public string GName { get; set; }
    }
    public class temailorderjoinheadgoods : temailorderjonhead
    {
        public int GoodsCount { get; set; }
    }
}