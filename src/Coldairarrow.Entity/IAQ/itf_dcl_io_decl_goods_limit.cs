using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入证许可证信息
    /// </summary>
    [Table("itf_dcl_io_decl_goods_limit")]
    public class itf_dcl_io_decl_goods_limit
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
        /// 许可证编号
        /// </summary>
        public String LicenceNo { get; set; }

        /// <summary>
        /// 许可证类别代码
        /// </summary>
        public String LicTypeCode { get; set; }

        /// <summary>
        /// 许可证类别名称
        /// </summary>
        public String LicTypeName { get; set; }

        /// <summary>
        /// 许可证核销明细序号
        /// </summary>
        public String LicWrtofDetailNo { get; set; }

        /// <summary>
        /// 许可证核销数量
        /// </summary>
        public Decimal? LicWrtofQty { get; set; }

        /// <summary>
        /// 许可证核销明细余量
        /// </summary>
        public Decimal? LicDetailLeft { get; set; }

        /// <summary>
        /// 许可证核销后余量
        /// </summary>
        public Decimal? LicWrtofLeft { get; set; }

        /// <summary>
        /// 许可证核销数量单位
        /// </summary>
        public String MeasUnitCode { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// Gnumber
        /// </summary>
        public String Gnumber { get; set; }

        /// <summary>
        /// Vnumber
        /// </summary>
        public String Vnumber { get; set; }

    }
}