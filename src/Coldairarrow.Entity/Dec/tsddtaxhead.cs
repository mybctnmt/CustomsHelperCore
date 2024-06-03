using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 报税单自报信息表头
    /// </summary>
    [Table("tsddtaxhead")]
    public class tsddtaxhead
    {

        /// <summary>
        /// 文件名称
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// 与录入号
        /// </summary>
        public String SeqNo { get; set; }

        /// <summary>
        /// 进出口标志
        /// </summary>
        public String IEFlag { get; set; }

        /// <summary>
        /// 申报口岸
        /// </summary>
        public String DeclPort { get; set; }

        /// <summary>
        /// 预计申报日期
        /// </summary>
        public String DDate { get; set; }

        /// <summary>
        /// 境内收发货人编号
        /// </summary>
        public String TradeCo { get; set; }

        /// <summary>
        /// 境内收发货人名称
        /// </summary>
        public String TradeName { get; set; }

        /// <summary>
        /// 内销比率
        /// </summary>
        public Decimal? InRatio { get; set; }

        /// <summary>
        /// 监管方式
        /// </summary>
        public String TradeMode { get; set; }

        /// <summary>
        /// 征免性质分类
        /// </summary>
        public String CutMode { get; set; }

        /// <summary>
        /// 成交方式
        /// </summary>
        public String TransMode { get; set; }

        /// <summary>
        /// 运费标记
        /// </summary>
        public String FeeMark { get; set; }

        /// <summary>
        /// 运费币制
        /// </summary>
        public String FeeCurr { get; set; }

        /// <summary>
        /// 运费／率
        /// </summary>
        public Decimal? FeeRate { get; set; }

        /// <summary>
        /// 保险费标记
        /// </summary>
        public String InsurMark { get; set; }

        /// <summary>
        /// 保险费币制
        /// </summary>
        public String InsurCurr { get; set; }

        /// <summary>
        /// 保险费／率
        /// </summary>
        public Decimal? InsurRate { get; set; }

        /// <summary>
        /// 杂费标记
        /// </summary>
        public String OtherMark { get; set; }

        /// <summary>
        /// 杂费币制
        /// </summary>
        public String OtherCurr { get; set; }

        /// <summary>
        /// 杂费／率
        /// </summary>
        public Decimal? OtherRate { get; set; }

        /// <summary>
        /// 备案号
        /// </summary>
        public String ManualNo { get; set; }

        /// <summary>
        /// 境内收发货人统一代码
        /// </summary>
        public String TradeCoScc { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        public Decimal? GrossWt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String NoteS { get; set; }

        /// <summary>
        /// 法律责任
        /// </summary>
        public String LegalLiability { get; set; }

        /// <summary>
        /// 数字签名信息
        /// </summary>
        public String Sign { get; set; }

        /// <summary>
        /// 签名消息号
        /// </summary>
        public String MessId { get; set; }

        /// <summary>
        /// 签名证书号
        /// </summary>
        public String CertSeqNo { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 30)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}