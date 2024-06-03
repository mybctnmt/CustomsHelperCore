using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 客户负责人关系表
    /// </summary>
    [Table("tbasecustomerrelation")]
    public class tbasecustomerrelation
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public String UId { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public String DId { get; set; }
        public String CId { get; set; }

    }
}