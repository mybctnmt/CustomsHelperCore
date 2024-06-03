using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 检验检疫申请数据
    /// </summary>
    [Table("itf_ciq_data")]
    public class itf_ciq_data
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
        /// DeclGetNo
        /// </summary>
        public String DeclGetNo { get; set; }

        /// <summary>
        /// CertNo
        /// </summary>
        public String CertNo { get; set; }

        /// <summary>
        /// DataType
        /// </summary>
        public String DataType { get; set; }

        /// <summary>
        /// SN
        /// </summary>
        public String SN { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}