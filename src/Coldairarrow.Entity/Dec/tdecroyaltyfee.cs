using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 特许权使用费申请表
    /// </summary>
    [Table("tdecroyaltyfee")]
    public class tdecroyaltyfee
    {

        /// <summary>
        /// 价格预裁定编号
        /// </summary>
        public String PricePreDeterminNo { get; set; }

        /// <summary>
        /// 应税特许权使用费申报情形
        /// </summary>
        public String TaxRoyaltyDeclType { get; set; }

        /// <summary>
        /// 合同/协议号
        /// </summary>
        public String ContractNo { get; set; }

        /// <summary>
        /// 授权方
        /// </summary>
        public String Authorizer { get; set; }

        /// <summary>
        /// 被授权方
        /// </summary>
        public String AuthorizedPerson { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public String PayType { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public String PayTime { get; set; }

        /// <summary>
        /// 支付计提周期
        /// </summary>
        public Int32? PayPeriod { get; set; }

        /// <summary>
        /// 合同/协议起始执行时间
        /// </summary>
        public String EffectiveDateTime { get; set; }

        /// <summary>
        /// 合同协议终止时间
        /// </summary>
        public String ExpirationDateTime { get; set; }

        /// <summary>
        /// 特许权使用费金额
        /// </summary>
        public Decimal RoyaltyAmount { get; set; }

        /// <summary>
        /// 币制
        /// </summary>
        public String Curr { get; set; }

        /// <summary>
        /// 特许权使用费类型
        /// </summary>
        public String RoyaltyFeeType { get; set; }

        /// <summary>
        /// 随附材料清单类型
        /// </summary>
        public String EdocType { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public String Statment { get; set; }

        /// <summary>
        /// 是否保密
        /// </summary>
        public String IsSecret { get; set; }

        /// <summary>
        /// 是否经过海关审核认定
        /// </summary>
        public String IsCusAudit { get; set; }

        /// <summary>
        /// 是否经过海关价格预裁定
        /// </summary>
        public String IsCusPricePreDetermin { get; set; }

        /// <summary>
        /// 合同/协议签约时间
        /// </summary>
        public String IssueDateTime { get; set; }

        /// <summary>
        /// 本次支付对应的计提周期起始时间
        /// </summary>
        public String PeriodStartDate { get; set; }

        /// <summary>
        /// 本次支付对应的计提周期终止时间
        /// </summary>
        public String PeriodEndDate { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 22)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}