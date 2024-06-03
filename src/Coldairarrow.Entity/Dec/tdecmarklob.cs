using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 标记号码附件表
    /// </summary>
    [Table("tdecmarklob")]
    public class tdecmarklob
    {

        /// <summary>
        /// 附件名称
        /// </summary>
        public String AttachName { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        public String AttachType { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public Byte[] Attachment { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 4)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}