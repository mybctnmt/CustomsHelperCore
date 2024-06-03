using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Remind
{
    /// <summary>
    /// 提醒记录表
    /// </summary>
    [Table("treminderuserlog")]
    public class treminderuserlog
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 提醒人Id
        /// </summary>
        public String UId { get; set; }

        /// <summary>
        /// 提醒记录Id
        /// </summary>
        public Int32? RId { get; set; }
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