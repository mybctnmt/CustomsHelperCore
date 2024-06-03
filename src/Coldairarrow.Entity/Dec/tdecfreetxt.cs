using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 报关单自由文本信息
    /// </summary>
    [Table("tdecfreetxt")]
    public class tdecfreetxt
    {

        /// <summary>
        /// 监管仓号
        /// </summary>
        public String BonNo { get; set; }

        /// <summary>
        /// 货场代码
        /// </summary>
        public String CusFie { get; set; }

        /// <summary>
        /// 报关员联系方式
        /// </summary>
        public String DecBpNo { get; set; }

        /// <summary>
        /// 申报人员证号
        /// </summary>
        public String DecNo { get; set; }

        /// <summary>
        /// 关联报关单号
        /// </summary>
        public String RelId { get; set; }

        /// <summary>
        /// 关联备案号
        /// </summary>
        public String RelManNo { get; set; }

        /// <summary>
        /// 航次号
        /// </summary>
        public String VoyNo { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 8)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}