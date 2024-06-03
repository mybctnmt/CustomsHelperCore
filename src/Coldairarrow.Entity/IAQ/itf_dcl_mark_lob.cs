using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境检验检疫申请标记号码附件
    /// </summary>
    [Table("itf_dcl_mark_lob")]
    public class itf_dcl_mark_lob
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
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>
        public String AttachName { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        public String AttachType { get; set; }

        /// <summary>
        /// 随附单据文件大小
        /// </summary>
        public String AttEdocSize { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public Byte[] Attachment { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}