using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Fieldwork
{
    /// <summary>
    /// ttaskfeedback
    /// </summary>
    [Table("ttaskfeedback")]
    public class ttaskfeedback
    {

        /// <summary>
        /// 主键
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
        /// 任务Id
        /// </summary>
        public String TaskId { get; set; }

        /// <summary>
        /// 完成内容
        /// </summary>
        public String CompletedContent { get; set; }

    }
}