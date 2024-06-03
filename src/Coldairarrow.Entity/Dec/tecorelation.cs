using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 原产地证明项号关联关系
    /// </summary>
    [Table("tecorelation")]
    public class tecorelation
    {

        /// <summary>
        /// 单据类型
        /// </summary>
       
        public String CertType { get; set; }

        /// <summary>
        /// 报关单商品项号
        /// </summary>
       
        public String DecGNo { get; set; }

        /// <summary>
        /// 单据证书号
        /// </summary>
       
        public String EcoCertNo { get; set; }

        /// <summary>
        /// 原产地证书单证项号
        /// </summary>
       
        public String EcoGNo { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public String ExtendFiled { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 6)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}