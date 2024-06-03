using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境货物与集装箱关联信息
    /// </summary>
    [Table("itf_dcl_io_decl_goods_cont")]
    public class itf_dcl_io_decl_goods_cont
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 集装箱号码
        /// </summary>
        public String ContainerNo { get; set; }

        /// <summary>
        /// HS编码
        /// </summary>
        public String ProdHsCode { get; set; }

        /// <summary>
        /// 运输工具类型代码
        /// </summary>
        public String TransMeansType { get; set; }

        /// <summary>
        /// 集装箱规格代码
        /// </summary>
        public String CntnrModeCode { get; set; }

        /// <summary>
        /// 集装箱数量
        /// </summary>
        public Decimal? Qty { get; set; }

        /// <summary>
        /// 数量计量单位
        /// </summary>
        public String CiqQtyMeasUnit { get; set; }

        /// <summary>
        /// 标准计量单位数量
        /// </summary>
        public Decimal? Qty1 { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public Decimal? CiqWeight { get; set; }

        /// <summary>
        /// HS标准计量单位
        /// </summary>
        public String Unit1 { get; set; }

        /// <summary>
        /// 重量单位代码
        /// </summary>
        public String CiqWtUnitCode { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// Gnumber
        /// </summary>
        public String Gnumber { get; set; }

    }
}