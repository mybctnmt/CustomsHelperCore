using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 提醒条件表
    /// </summary>
    [Table("talarmcondition")]
    public class talarmcondition
    {

        /// <summary>
        /// Id
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
        /// 提醒名称
        /// </summary>
        public String UserTag { get; set; }

        /// <summary>
        /// 类型1-节点2-条件
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// 是否启用1-是0-否
        /// </summary>
        public String IsEnable { get; set; }

        /// <summary>
        /// 提醒级别
        /// </summary>
        public String ReminderLevel { get; set; }

        /// <summary>
        /// 提醒方式
        /// </summary>
        public String ReminderMethod { get; set; }

        /// <summary>
        /// 检查类型
        /// </summary>
        public String ExamType { get; set; }

        /// <summary>
        /// 检查项Id
        /// </summary>
        public String InspectionItemId { get; set; }

        /// <summary>
        /// 时间条件
        /// </summary>
        public String TimeNode { get; set; }

        /// <summary>
        /// 前-后
        /// </summary>
        public String PriorDate { get; set; }

        /// <summary>
        /// 时间值-天-小时
        /// </summary>
        public Int32? TimeValue { get; set; }

        /// <summary>
        /// 天-小时
        /// </summary>
        public String TimeType { get; set; }
        public int? TimeInterval { get; set; }


    }
}