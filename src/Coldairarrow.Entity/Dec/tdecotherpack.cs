using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 其他包装信息表
    /// </summary>
    [Table("tdecotherpack")]
    public class tdecotherpack
    {

        /// <summary>
        /// 包装件数
        /// </summary>
        public Decimal? PackQty { get; set; }

        /// <summary>
        /// 包装材料种类
        /// </summary>
        public String PackType { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 3)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}