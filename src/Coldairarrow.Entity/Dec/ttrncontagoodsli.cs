using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 进出口提运单集装箱商品装配表
    /// </summary>
    [Table("ttrncontagoodsli")]
    public class ttrncontagoodsli
    {

        /// <summary>
        /// 商品序号
        /// </summary>
        public Int32 GNo { get; set; }

        /// <summary>
        /// 集装箱号
        /// </summary>
        public String ContaNo { get; set; }

        /// <summary>
        /// 商品件数
        /// </summary>
        public Int32? ContaGoodsCount { get; set; }

        /// <summary>
        /// 商品重量
        /// </summary>
        public Decimal? ContaGoodsWeight { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 5)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}