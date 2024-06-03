using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 检测内容表
    /// </summary>
    [Table("tdetectioncontent")]
    public class tdetectioncontent
    {

        /// <summary>
        /// Id
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
        /// 检测项目
        /// </summary>
        public String CheckItem { get; set; }

        /// <summary>
        /// 检测内容
        /// </summary>
        public String CheckContent { get; set; }

        /// <summary>
        /// 提醒内容
        /// </summary>
        public String ReminderContent { get; set; }
        public String CheckCondition { get; set; }
        public String IEFlag { get; set; }

    }
}