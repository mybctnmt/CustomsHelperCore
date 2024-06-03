using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Base_Manage
{
    /// <summary>
    /// 基础派单表
    /// </summary>
    [Table("base_dispatch")]
    public class Base_Dispatch
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
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 派单数量
        /// </summary>
        public Int32? DispatchCount { get; set; }

        /// <summary>
        /// 派单人
        /// </summary>
        public String DispatchId { get; set; }
        public int? IsOnline { get; set; }

    }

    public class Dispatch
    {
        /// <summary>
        /// 派单数量
        /// </summary>
        public Int32? DispatchCount { get; set; }

        /// <summary>
        /// 派单人
        /// </summary>
        public String DispatchId { get; set; }

        /// <summary>
        /// 当前派单数量
        /// </summary>
        public Int32? CurDispatchCount { get; set; }
    }
}