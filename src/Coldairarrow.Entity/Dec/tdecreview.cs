using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// tdecreview
    /// </summary>
    [Table("tdecreview")]
    public class tdecreview
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }

        /// <summary>
        /// 审核人Id
        /// </summary>
        public String ReviewerId { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public String ReviewerName { get; set; }

        /// <summary>
        /// 更新内容
        /// </summary>
        public String UpdateContent { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

    }
}