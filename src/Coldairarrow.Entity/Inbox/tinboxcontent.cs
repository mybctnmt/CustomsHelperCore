using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Inbox
{
    /// <summary>
    /// 收件箱内容表，存储邮件相关信息。
    /// </summary>
    [Table("tinboxcontent")]
    public class tinboxcontent
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public String SenderName { get; set; }

        /// <summary>
        /// 发件人账号
        /// </summary>
        public String SenderEmailAddress { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public String Recipient { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public String Subject { get; set; }

        /// <summary>
        /// 邮件内容Html
        /// </summary>
        public String HtmlContent { get; set; }

        /// <summary>
        /// 邮件内容文本
        /// </summary>
        public String TextContent { get; set; }

        /// <summary>
        /// 邮件大小
        /// </summary>
        public Int32? Size { get; set; }

        /// <summary>
        /// 邮件Id
        /// </summary>
        public String EmailId { get; set; }

        /// <summary>
        /// 邮件类型
        /// </summary>
        public String EmailType { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        public String OperationStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }
        /// <summary>
        /// 是否有附件
        /// </summary>
        public String HasAttachment { get; set; }

        /// <summary>
        /// 邮件内容Html
        /// </summary>
        public String HtmlAttachment { get; set; }
        /// <summary>
        /// 邮件内容文本
        /// </summary>
        public String TextAttachment { get; set; }
    }
}