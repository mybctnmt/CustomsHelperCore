using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Inbox
{
    /// <summary>
    /// temailcontent
    /// </summary>
    [Table("temailcontent")]
    public class temailcontent
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public String Subject { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 邮件附件
        /// </summary>
        public String Attachment { get; set; }

        /// <summary>
        /// 邮件节点
        /// </summary>
        public int? Node { get; set; }

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