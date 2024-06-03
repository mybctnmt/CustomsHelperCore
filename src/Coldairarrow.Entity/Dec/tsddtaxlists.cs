using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 自报信息表体
    /// </summary>
    [Table("tsddtaxlists")]
    public class tsddtaxlists
    {

        /// <summary>
        /// 商品序号
        /// </summary>
       
        public Int32 GNo { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public String CodeTs { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String GName { get; set; }

        /// <summary>
        /// 产销国
        /// </summary>
        public String OriginCountry { get; set; }

        /// <summary>
        /// 协定编号
        /// </summary>
        public String AgreementId { get; set; }

        /// <summary>
        /// 第一数量
        /// </summary>
        public Decimal? Qty1 { get; set; }

        /// <summary>
        /// 第一计量单位
        /// </summary>
        public String Unit1 { get; set; }

        /// <summary>
        /// 第二数量
        /// </summary>
        public Decimal? Qty2 { get; set; }

        /// <summary>
        /// 第二计量单位
        /// </summary>
        public String Unit2 { get; set; }

        /// <summary>
        /// 成交币制
        /// </summary>
        public String TradeCurr { get; set; }

        /// <summary>
        /// 申报单价
        /// </summary>
        public Decimal? DeclPrice { get; set; }

        /// <summary>
        /// 申报总价
        /// </summary>
        public Decimal? DeclTotal { get; set; }

        /// <summary>
        /// 征减免税方式
        /// </summary>
        public String DutyMode { get; set; }

        /// <summary>
        /// 反倾销涉案
        /// </summary>
        public String Antidumping { get; set; }

        /// <summary>
        /// 反补贴涉案
        /// </summary>
        public String Antisubsidy { get; set; }

        /// <summary>
        /// 特案完税价格
        /// </summary>
        public Decimal? DutyValue { get; set; }

        /// <summary>
        /// 关税从价税率
        /// </summary>
        public Decimal? DutyRate { get; set; }

        /// <summary>
        /// 关税从量税率
        /// </summary>
        public Decimal? QtyDutyRate { get; set; }

        /// <summary>
        /// 消费税从价税率
        /// </summary>
        public Decimal? RegRate { get; set; }

        /// <summary>
        /// 消费税从量税率
        /// </summary>
        public Decimal? QtyRegRate { get; set; }

        /// <summary>
        /// 增值税率
        /// </summary>
        public Decimal? TaxRate { get; set; }

        /// <summary>
        /// 反倾销税率
        /// </summary>
        public Decimal? AntidumpingRate { get; set; }

        /// <summary>
        /// 反补贴税率
        /// </summary>
        public Decimal? AntisubsidyRate { get; set; }

        /// <summary>
        /// 废弃基金税率
        /// </summary>
        public Decimal? TrashfundRate { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 25)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}