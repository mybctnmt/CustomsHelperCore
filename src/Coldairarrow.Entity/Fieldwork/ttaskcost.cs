using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Fieldwork
{
    /// <summary>
    /// ttaskcost
    /// </summary>
    [Table("ttaskcost")]
    public class ttaskcost
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 任务Id
        /// </summary>
        public String TaskId { get; set; }

        /// <summary>
        /// 费用Id
        /// </summary>
        public String FeeId { get; set; }

        /// <summary>
        /// 费用名称
        /// </summary>
        public String CostName { get; set; }

        /// <summary>
        /// 费用金额
        /// </summary>
        public Decimal? CostAmount { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        public String CostType { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }

        /// <summary>
        /// 费用名称
        /// </summary>
        [NotMapped]
        public String FeeNameCn { get; set; }

    }
}