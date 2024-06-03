using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 随附单证
    /// </summary>
    [Table("tdeclicensedocus")]
    public class tdeclicensedocus
    {

        /// <summary>
        /// 单证代码
        /// </summary>
        public String DocuCode { get; set; }

        /// <summary>
        /// 单证编号
        /// </summary>
        public String CertCode { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 3)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}