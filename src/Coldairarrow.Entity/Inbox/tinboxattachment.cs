using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Inbox
{
    /// <summary>
    /// 附件表，存储邮件附件信息。
    /// </summary>
    [Table("tinboxattachment")]
    public class tinboxattachment
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 收件箱Id
        /// </summary>
        public String InboxId { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>
        public String AttachmentName { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        public Int32 AttachmentSize { get; set; }

        /// <summary>
        /// 附件路径
        /// </summary>
        public String AttachmentPath { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        public String AttachmentType { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public String FileType { get; set; }

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