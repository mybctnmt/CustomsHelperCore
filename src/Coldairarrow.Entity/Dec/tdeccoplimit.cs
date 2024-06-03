using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 企业资质信息表
    /// </summary>
    [Table("tdeccoplimit")]
    public class tdeccoplimit
    {

        /// <summary>
        /// 企业资质编号
        /// </summary>
        public String EntQualifNo { get; set; }

        /// <summary>
        /// 企业资质类别代码
        /// </summary>
        public String EntQualifTypeCode { get; set; }

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