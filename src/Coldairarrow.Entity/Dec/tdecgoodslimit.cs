using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 许可证信息表
    /// </summary>
    [Table("tdecgoodslimit")]
    public class tdecgoodslimit
    {

        /// <summary>
        /// 商品序号
        /// </summary>
        public Int32? GoodsNo { get; set; }

        /// <summary>
        /// 许可证类别代码
        /// </summary>
        public String LicTypeCode { get; set; }

        /// <summary>
        /// 许可证编号
        /// </summary>
        public String LicenceNo { get; set; }

        /// <summary>
        /// 许可证核销明细序号
        /// </summary>
        public String LicWrtofDetailNo { get; set; }

        /// <summary>
        /// 许可证核销数量
        /// </summary>
        public String LicWrtofQty { get; set; }

        /// <summary>
        /// 许可证核销数量单位
        /// </summary>
        public String LicWrtofQtyUnit { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 7)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }
        public string GoodsId { get; set; }

    }
}