using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Remind
{
    /// <summary>
    /// 提醒记录表
    /// </summary>
    [Table("treminderrecord")]
    public class treminderrecord
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32 Id { get; set; }

        /// <summary>
        /// 提醒名称
        /// </summary>
        public String UserTag { get; set; }

        /// <summary>
        /// 提醒级别
        /// </summary>
        public String ReminderLevel { get; set; }

        /// <summary>
        /// 提醒方式
        /// </summary>
        public String ReminderMethod { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 检测项Id
        /// </summary>
        public String ItemId { get; set; }

    }
}