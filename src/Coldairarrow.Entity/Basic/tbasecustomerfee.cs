using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    ///  客户费目表
    /// </summary>
    [Table("tbasecustomerfee")]
    public class tbasecustomerfee
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 进出口状态
        /// </summary>
        public String EoI { get; set; }

        /// <summary>
        /// 费目
        /// </summary>
        public String FeeID { get; set; }

        /// <summary>
        /// 费率
        /// </summary>
        public String FeeRate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 应收应付
        /// </summary>
        public String FeeType { get; set; }

        /// <summary>
        /// 客户表ID
        /// </summary>
        public String CId { get; set; }

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