using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 随附单据导入报文结构
    /// </summary>
    [Table("itf_attached_document")]
    public class itf_attached_document
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
        /// MessageType
        /// </summary>
        public String MessageType { get; set; }

        /// <summary>
        /// UuId
        /// </summary>
        public String UuId { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// FormatType
        /// </summary>
        public String FormatType { get; set; }

        /// <summary>
        /// ZipName
        /// </summary>
        public String ZipName { get; set; }

        /// <summary>
        /// CopFileName
        /// </summary>
        public String CopFileName { get; set; }

        /// <summary>
        /// DealType
        /// </summary>
        public String DealType { get; set; }

        /// <summary>
        /// SendTime
        /// </summary>
        public String SendTime { get; set; }

        /// <summary>
        /// FileSource
        /// </summary>
        public String FileSource { get; set; }

        /// <summary>
        /// OpNote
        /// </summary>
        public String OpNote { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public Byte[] File { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}