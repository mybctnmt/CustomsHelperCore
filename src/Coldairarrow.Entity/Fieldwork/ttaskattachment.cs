using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Fieldwork
{
    /// <summary>
    /// ttaskattachment
    /// </summary>
    [Table("ttaskattachment")]
    public class ttaskattachment
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
        /// 附件名称
        /// </summary>
        public String AttachmentName { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        public String AttachmentUrl { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        public Int32? AttachmentSize { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        public String AttachmentType { get; set; }

    }
}