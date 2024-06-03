using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 申请单证信息表
    /// </summary>
    [Table("tdecrequestcert")]
    public class tdecrequestcert
    {

        /// <summary>
        /// 申请单证代码
        /// </summary>
        public String AppCertCode { get; set; }

        /// <summary>
        /// 申请单证正本数
        /// </summary>
        public String ApplOri { get; set; }

        /// <summary>
        /// 申请单证副本数
        /// </summary>
        public String ApplCopyQuan { get; set; }

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