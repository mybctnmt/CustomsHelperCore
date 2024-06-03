using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 报关数据
    /// </summary>
    [Table("itf_dec_data")]
    public class itf_dec_data
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
        /// MasterCustomsCode
        /// </summary>
        public String MasterCustomsCode { get; set; }

        /// <summary>
        /// PreEntryId
        /// </summary>
        public String PreEntryId { get; set; }

        /// <summary>
        /// SpDecSeqNo
        /// </summary>
        public String SpDecSeqNo { get; set; }

        /// <summary>
        /// TradeCode
        /// </summary>
        public String TradeCode { get; set; }

        /// <summary>
        /// DealCode
        /// </summary>
        public String DealCode { get; set; }

        /// <summary>
        /// DealName
        /// </summary>
        public String DealName { get; set; }

        /// <summary>
        /// FileType
        /// </summary>
        public String FileType { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}