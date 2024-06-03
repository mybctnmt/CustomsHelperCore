using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// tTrnContainer进出口提运单集装箱表
    /// </summary>
    [Table("ttrncontainer")]
    public class ttrncontainer
    {

        /// <summary>
        /// 集装箱号
        /// </summary>
        public String ContaNo { get; set; }

        /// <summary>
        /// 集装箱序号
        /// </summary>
        public Int32? ContaSn { get; set; }

        /// <summary>
        /// 集装箱规格
        /// </summary>
        public String ContaModel { get; set; }

        /// <summary>
        /// 电子关锁号
        /// </summary>
        public String SealNo { get; set; }

        /// <summary>
        /// 境内运输工具名称
        /// </summary>
        public String TransName { get; set; }

        /// <summary>
        /// 工具实际重量（海关精度z(14).z(5)）
        /// </summary>
        public Decimal? TransWeight { get; set; }

        /// <summary>
        /// 关锁个数
        /// </summary>
        public String SealQty { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 8)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}