using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Nems
{
    /// <summary>
    /// 核注清单表头
    /// </summary>
    [Table("tinvthead")]
    public class tinvthead
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }
        public String Id { get; set; }
        /// <summary>
        /// 清单编号
        /// </summary>
        public String BondInvtNo { get; set; }

        /// <summary>
        /// 清单预录入统一编号
        /// </summary>
        public String SeqNo { get; set; }

        /// <summary>
        /// 备案编号
        /// </summary>
        public String PutrecNo { get; set; }

        /// <summary>
        /// 企业内部清单编号
        /// </summary>
        public String EtpsInnerInvtNo { get; set; }

        /// <summary>
        /// 经营企业社会信用代码
        /// </summary>
        public String BizopEtpsSccd { get; set; }

        /// <summary>
        /// 经营企业编号
        /// </summary>
        public String BizopEtpsNo { get; set; }

        /// <summary>
        /// 经营企业名称
        /// </summary>
        public String BizopEtpsNm { get; set; }

        /// <summary>
        /// 收货企业编号
        /// </summary>
        public String RcvgdEtpsNo { get; set; }

        /// <summary>
        /// 收发货企业社会信用代码
        /// </summary>
        public String RvsngdEtpsSccd { get; set; }

        /// <summary>
        /// 收货企业名称
        /// </summary>
        public String RcvgdEtpsNm { get; set; }

        /// <summary>
        /// 申报企业社会信用代码
        /// </summary>
        public String DclEtpsSccd { get; set; }

        /// <summary>
        /// 申报企业编号
        /// </summary>
        public String DclEtpsNo { get; set; }

        /// <summary>
        /// 申报企业名称
        /// </summary>
        public String DclEtpsNm { get; set; }

        /// <summary>
        /// 清单申报时间
        /// </summary>
        public String InvtDclTime { get; set; }

        /// <summary>
        /// 报关单申报日期
        /// </summary>
        public String EntryDclTime { get; set; }

        /// <summary>
        /// 对应报关单编号
        /// </summary>
        public String EntryNo { get; set; }

        /// <summary>
        /// 关联清单编号
        /// </summary>
        public String RltInvtNo { get; set; }

        /// <summary>
        /// 关联手（账）册备案编号
        /// </summary>
        public String RltPutrecNo { get; set; }

        /// <summary>
        /// 关联报关单编号
        /// </summary>
        public String RltEntryNo { get; set; }

        /// <summary>
        /// 关联报关单境内收发货人社会信用代码
        /// </summary>
        public String RltEntryBizopEtpsSccd { get; set; }

        /// <summary>
        /// 关联报关单境内收发货人编号
        /// </summary>
        public String RltEntryBizopEtpsNo { get; set; }

        /// <summary>
        /// 关联报关单境内收发货人名称
        /// </summary>
        public String RltEntryBizopEtpsNm { get; set; }

        /// <summary>
        /// 关联报关单生产销售(消费使用)单位社会统一信用代码
        /// </summary>
        public String RltEntryRvsngdEtpsSccd { get; set; }

        /// <summary>
        /// 关联报关单生产销售(消费使用)单位编码
        /// </summary>
        public String RltEntryRcvgdEtpsNo { get; set; }

        /// <summary>
        /// 关联报关单生产销售(消费使用)单位名称
        /// </summary>
        public String RltEntryRcvgdEtpsNm { get; set; }

        /// <summary>
        /// 关联报关单申报单位社会统一信用代码
        /// </summary>
        public String RltEntryDclEtpsSccd { get; set; }

        /// <summary>
        /// 关联报关单海关申报单位编码
        /// </summary>
        public String RltEntryDclEtpsNo { get; set; }

        /// <summary>
        /// 关联报关单申报单位名称
        /// </summary>
        public String RltEntryDclEtpsNm { get; set; }

        /// <summary>
        /// 进出境关别
        /// </summary>
        public String ImpExpPortcd { get; set; }

        /// <summary>
        /// 申报地关区代码
        /// </summary>
        public String DclPlcCuscd { get; set; }

        /// <summary>
        /// 进出口标记代码
        /// </summary>
        public String ImpExpMarkcd { get; set; }

        /// <summary>
        /// 料件成品标记代码
        /// </summary>
        public String MtpckEndprdMarkcd { get; set; }

        /// <summary>
        /// 监管方式代码
        /// </summary>
        public String SupvModecd { get; set; }

        /// <summary>
        /// 运输方式代码
        /// </summary>
        public String TrspModecd { get; set; }

        /// <summary>
        /// 是否报关标志
        /// </summary>
        public String DclCusFlag { get; set; }

        /// <summary>
        /// 报关类型代码
        /// </summary>
        public String DclCusTypecd { get; set; }

        /// <summary>
        /// 核扣标记代码
        /// </summary>
        public String VrfdedMarkcd { get; set; }

        /// <summary>
        /// 清单进出卡口状态代码
        /// </summary>
        public String InvtIochkptStucd { get; set; }

        /// <summary>
        /// 预核扣时间
        /// </summary>
        public String PrevdTime { get; set; }

        /// <summary>
        /// 正式核扣时间
        /// </summary>
        public String FormalVrfdedTime { get; set; }

        /// <summary>
        /// 申请表编号
        /// </summary>
        public String ApplyNo { get; set; }

        /// <summary>
        /// 流转类型
        /// </summary>
        public String ListType { get; set; }

        /// <summary>
        /// 录入企业编号
        /// </summary>
        public String InputCode { get; set; }

        /// <summary>
        /// 录入企业社会信用代码
        /// </summary>
        public String InputCreditCode { get; set; }

        /// <summary>
        /// 录入单位名称
        /// </summary>
        public String InputName { get; set; }

        /// <summary>
        /// 申报人IC卡号
        /// </summary>
        public String IcCardNo { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        public String InputTime { get; set; }

        /// <summary>
        /// 清单状态
        /// </summary>
        public String ListStat { get; set; }

        /// <summary>
        /// 对应报关单申报单位社会统一信用代码
        /// </summary>
        public String CorrentryDclEtpssccd { get; set; }

        /// <summary>
        /// 对应报关单申报单位代码
        /// </summary>
        public String CorrentryDclEtpsno { get; set; }

        /// <summary>
        /// 对应报关单申报单位名称
        /// </summary>
        public String CorrentryDclEtpsnm { get; set; }

        /// <summary>
        /// 报关单类型
        /// </summary>
        public String DecType { get; set; }

        /// <summary>
        /// 变更次数
        /// </summary>
        public Decimal ChgTmsCnt { get; set; }

        /// <summary>
        /// 起运/运抵国(地区）
        /// </summary>
        public String StshipTrsarvNatcd { get; set; }

        /// <summary>
        /// 清单类型
        /// </summary>
        public String InvtType { get; set; }

        /// <summary>
        /// 报关状态
        /// </summary>
        public String EntryStucd { get; set; }

        /// <summary>
        /// 核放单生成标志代码
        /// </summary>
        public String PassPortUsedTypecd { get; set; }

        /// <summary>
        /// 申报类型
        /// </summary>
        public String DclTypecd { get; set; }

        /// <summary>
        /// 报关单同步修改标志
        /// </summary>
        public String NeedEntryModified { get; set; }

        /// <summary>
        /// 计征金额
        /// </summary>
        public String LevyBlAmt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Rmk { get; set; }

        /// <summary>
        /// 是否生成报关单
        /// </summary>
        public String GenDecFlag { get; set; }
        public string OrderNo { get; set; }

    }
}