using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// hscode 基础信息
    /// </summary>
    [Table("tbasehscodeinfo")]
    public class tbasehscodeinfo
    {

        /// <summary>
        /// codets
        /// </summary>
        public String codets { get; set; }

        /// <summary>
        /// controlMark
        /// </summary>
        public String controlMark { get; set; }

        /// <summary>
        /// unitFlag
        /// </summary>
        public String unitFlag { get; set; }

        /// <summary>
        /// ciqWtMeasUnit
        /// </summary>
        public String ciqWtMeasUnit { get; set; }

        /// <summary>
        /// ciqWtMeasUnitName
        /// </summary>
        public String ciqWtMeasUnitName { get; set; }

        /// <summary>
        /// gname
        /// </summary>
        public String gname { get; set; }

        /// <summary>
        /// unit1
        /// </summary>
        public String unit1 { get; set; }

        /// <summary>
        /// dangerFlag
        /// </summary>
        public String dangerFlag { get; set; }

        /// <summary>
        /// unit1Name
        /// </summary>
        public String unit1Name { get; set; }

        /// <summary>
        /// unit2
        /// </summary>
        public String unit2 { get; set; }

        /// <summary>
        /// outDutyTypeFlag
        /// </summary>
        public String outDutyTypeFlag { get; set; }

        /// <summary>
        /// inspMonitorCond
        /// </summary>
        public String inspMonitorCond { get; set; }

        /// <summary>
        /// ciqQtyMeasUnitName
        /// </summary>
        public String ciqQtyMeasUnitName { get; set; }

        /// <summary>
        /// ciqQtyMeasUnit
        /// </summary>
        public String ciqQtyMeasUnit { get; set; }

        /// <summary>
        /// noteS
        /// </summary>
        public String noteS { get; set; }

        /// <summary>
        /// unit2Name
        /// </summary>
        public String unit2Name { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 17)]
        public String Id { get; set; }

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