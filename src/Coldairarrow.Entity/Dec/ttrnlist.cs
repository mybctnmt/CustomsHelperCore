using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 进出口转关单表体(提单) 
    /// </summary>
    [Table("ttrnlist")]
    public class ttrnlist
    {

        /// <summary>
        /// 进出境运输方式
        /// </summary>
        public String TrafMode { get; set; }

        /// <summary>
        /// 进出境运输工具编号
        /// </summary>
        public String ShipId { get; set; }

        /// <summary>
        /// 进出境运输工具名称
        /// </summary>
        public String ShipNameEn { get; set; }

        /// <summary>
        /// 进出境运输工具航次
        /// </summary>
        public String VoyageNo { get; set; }

        /// <summary>
        /// 提单号
        /// </summary>
        public String BillNo { get; set; }

        /// <summary>
        /// 实际进出境日期
        /// </summary>
        public String IEDate { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 7)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}