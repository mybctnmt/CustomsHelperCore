using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 进出口转关单表头
    /// </summary>
    [Table("ttrnhead")]
    public class ttrnhead
    {

        /// <summary>
        /// 转关单统一编号
        /// </summary>
        public String TrnPreId { get; set; }

        /// <summary>
        /// 载货清单号
        /// </summary>
        public String TransNo { get; set; }

        /// <summary>
        /// 转关申报单号
        /// </summary>
        public String TurnNo { get; set; }

        /// <summary>
        /// 境内运输方式
        /// </summary>
        public String NativeTrafMode { get; set; }

        /// <summary>
        /// 境内运输工具编号
        /// </summary>
        public String TrafCustomsNo { get; set; }

        /// <summary>
        /// 境内运输工具名称
        /// </summary>
        public String NativeShipName { get; set; }

        /// <summary>
        /// 境内运输工具航次
        /// </summary>
        public String NativeVoyageNo { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public String ContractorName { get; set; }

        /// <summary>
        /// 承运单位组织机构代码
        /// </summary>
        public String ContractorCode { get; set; }

        /// <summary>
        /// 转关类型
        /// </summary>
        public String TransFlag { get; set; }

        /// <summary>
        /// 预计运抵指运地时间
        /// </summary>
        public String ValidTime { get; set; }

        /// <summary>
        /// 是否启用电子关锁标志
        /// </summary>
        public String ESealFlag { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Notes { get; set; }

        /// <summary>
        /// 转关单类型
        /// </summary>
        public String TrnType { get; set; }

        /// <summary>
        /// 转关申报单位统一代码
        /// </summary>
        public String ApplCodeScc { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 16)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}