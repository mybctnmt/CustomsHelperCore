using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 所需单证
    /// </summary>
    [Table("required_doc")]
    public class required_doc
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
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// AppCertCode
        /// </summary>
        public String AppCertCode { get; set; }

        /// <summary>
        /// AppCertName
        /// </summary>
        public String AppCertName { get; set; }

        /// <summary>
        /// ApplCopyQuan
        /// </summary>
        public String ApplCopyQuan { get; set; }

        /// <summary>
        /// ApplOri
        /// </summary>
        public String ApplOri { get; set; }

        /// <summary>
        /// CreateUser
        /// </summary>
        public String CreateUser { get; set; }

        /// <summary>
        /// CusCiqNo
        /// </summary>
        public String CusCiqNo { get; set; }

        /// <summary>
        /// IndbTime
        /// </summary>
        public DateTime? IndbTime { get; set; }

        /// <summary>
        /// RequCertSeqNo
        /// </summary>
        public String RequCertSeqNo { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public Boolean? State { get; set; }

        /// <summary>
        /// TableFlag
        /// </summary>
        public String TableFlag { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// UpdateUser
        /// </summary>
        public String UpdateUser { get; set; }

    }
}