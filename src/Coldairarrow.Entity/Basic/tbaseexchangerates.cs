using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 汇率表
    /// </summary>
    [Table("tbaseexchangerates")]
    public class tbaseexchangerates
    {

        /// <summary>
        /// id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 原始货币的三个字母代码
        /// </summary>
        public String CurrencyFrom { get; set; }

        /// <summary>
        /// 目标货币的三个字母代码
        /// </summary>
        public String CurrencyTo { get; set; }

        /// <summary>
        /// 汇率值
        /// </summary>
        public Decimal Rate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

    }
}