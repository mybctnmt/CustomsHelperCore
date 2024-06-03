using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Fieldwork
{
    /// <summary>
    /// ttaskhead
    /// </summary>
    [Table("ttaskhead")]
    public class ttaskhead
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
        /// 任务名称
        /// </summary>
        public String TaskName { get; set; }

        /// <summary>
        /// 任务内容
        /// </summary>
        public String TaskContent { get; set; }

        /// <summary>
        /// 是否加急
        /// </summary>
        public Boolean? IsUrgent { get; set; }

        /// <summary>
        /// 操作员Id
        /// </summary>
        public String OperatorId { get; set; }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public String OperatorName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime { get; set; }

        /// <summary>
        /// 接单人Id
        /// </summary>
        public String ReceiverId { get; set; }

        /// <summary>
        /// 接单人名称
        /// </summary>
        public String ReceiverName { get; set; }

        /// <summary>
        /// 接单时间
        /// </summary>
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 是否已完成
        /// </summary>
        public Boolean? IsCompleted { get; set; }

        /// <summary>
        /// 提单号
        /// </summary>
        public String BillNo { get; set; }

        /// <summary>
        /// 订单编号-非申报字段
        /// </summary>
        public String OrderNo { get; set; }

        /// <summary>
        /// 运输工具代码及名称
        /// </summary>
        public String TrafName { get; set; }

        /// <summary>
        /// 航次号
        /// </summary>
        public String CusVoyageNo { get; set; }

        /// <summary>
        /// 启运国/运抵国
        /// </summary>
        public String TradeCountry { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public String CodeTS { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String GName { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位代码
        /// </summary>
        public String OwnerCode { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位名称
        /// </summary>
        public String OwnerName { get; set; }

    }
}