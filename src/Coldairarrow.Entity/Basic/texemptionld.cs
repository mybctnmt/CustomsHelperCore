using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 征免联动表
    /// </summary>
    [Table("texemptionld")]
    public class texemptionld
    {

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 3)]
        public String Id { get; set; }

        /// <summary>
        /// TradeMode
        /// </summary>
        public String TradeMode { get; set; }

        /// <summary>
        /// CutMode
        /// </summary>
        public String CutMode { get; set; }

        /// <summary>
        /// DutyMode
        /// </summary>
        public String DutyMode { get; set; }

    }
}