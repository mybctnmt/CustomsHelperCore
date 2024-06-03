using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 费目表
    /// </summary>
    [Table("tbasefee")]
    public class tbasefee
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 费用代码
        /// </summary>
        public String FeeCode { get; set; }

        /// <summary>
        /// 费用名称中文
        /// </summary>
        public String FeeNameCn { get; set; }

        /// <summary>
        /// 费用名称英文
        /// </summary>
        public String FeeNameEn { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

    }
}