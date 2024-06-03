using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 税费计征结果
    /// </summary>
    [Table("tsddtaxdetails")]
    public class tsddtaxdetails
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }
        /// <summary>
        /// 商品序号
        /// </summary>

        public Int32 GNo { get; set; }

        /// <summary>
        /// 税种
        /// </summary>
        public String TaxType { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? RealTax { get; set; }

      
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}