using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 使用人信息表
    /// </summary>
    [Table("tdecuser")]
    public class tdecuser
    {

        /// <summary>
        /// 使用单位联系人
        /// </summary>
        public String UseOrgPersonCode { get; set; }

        /// <summary>
        /// 使用单位联系电话
        /// </summary>
        public String UseOrgPersonTel { get; set; }

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