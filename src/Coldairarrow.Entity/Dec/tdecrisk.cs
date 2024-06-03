using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 风险评估信息
    /// </summary>
    [Table("tdecrisk")]
    public class tdecrisk
    {

        /// <summary>
        /// 风险评估结果
        /// </summary>
        public String Risk { get; set; }

        /// <summary>
        /// 数字签名信息
        /// </summary>
        public String Sign { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 5)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}