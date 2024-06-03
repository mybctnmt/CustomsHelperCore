using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 报关单集装箱
    /// </summary>
    [Table("tdeccontainer")]
    public class tdeccontainer
    {

        /// <summary>
        /// 集装箱号
        /// </summary>
        public String ContainerId { get; set; }

        /// <summary>
        /// 集装箱规格
        /// </summary>
        public String ContainerMd { get; set; }

        /// <summary>
        /// 商品项号用半角逗号分隔，如"1,3"
        /// </summary>
        public String GoodsNo { get; set; }

        /// <summary>
        /// 拼箱标识，0-否1-是
        /// </summary>
        public String LclFlag { get; set; }

        /// <summary>
        /// 箱货重量
        /// </summary>
        public Decimal? GoodsContaWt { get; set; }

        /// <summary>
        /// 自重
        /// </summary>
        public Decimal? ContainerWt { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 7)]
        public String Id { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }
    }
}