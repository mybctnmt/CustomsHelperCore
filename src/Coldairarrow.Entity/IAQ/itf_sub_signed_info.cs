using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 预留字段相关SubignedInfo
    /// </summary>
    [Table("itf_sub_signed_info")]
    public class itf_sub_signed_info
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
        /// SignerID
        /// </summary>
        public String SignerID { get; set; }

        /// <summary>
        /// KeyName
        /// </summary>
        public String KeyName { get; set; }

        /// <summary>
        /// HashSign
        /// </summary>
        public String HashSign { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}