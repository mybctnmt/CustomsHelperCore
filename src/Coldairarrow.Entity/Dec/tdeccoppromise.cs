using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 企业承诺信息
    /// </summary>
    [Table("tdeccoppromise")]
    public class tdeccoppromise
    {

        /// <summary>
        /// 证明/声明材料代码
        /// </summary>
        public String DeclaratioMaterialCode { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 2)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}