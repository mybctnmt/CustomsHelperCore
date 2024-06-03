using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 报关回执结构CIQ_RET
    /// </summary>
    [Table("ciq_ret")]
    public class ciq_ret
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
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// 关检关联号
        /// </summary>
        public String CusCiqNo { get; set; }

        /// <summary>
        /// 报检号
        /// </summary>
        public String EntDealNo { get; set; }

        /// <summary>
        /// 通关单号
        /// </summary>
        public String CIBINo { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperTime { get; set; }

        /// <summary>
        /// 回执代码
        /// </summary>
        public String RspCodes { get; set; }

        /// <summary>
        /// 回执信息
        /// </summary>
        public String RspInfo { get; set; }

    }
}