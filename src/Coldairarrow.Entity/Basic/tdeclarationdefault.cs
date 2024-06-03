using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 报关单默认值
    /// </summary>
    [Table("tdeclarationdefault")]
    public class tdeclarationdefault
    {

        /// <summary>
        /// Id
        /// </summary>
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
        /// 申报单位代码
        /// </summary>
        public String AgentCode { get; set; }

        /// <summary>
        /// 申报单位名称
        /// </summary>
        public String AgentName { get; set; }

        /// <summary>
        /// 申报代码统一编码
        /// </summary>
        public String AgentCodeScc { get; set; }

        /// <summary>
        /// 申报单位检验检疫编码
        /// </summary>
        public String DeclCiqCode { get; set; }

        /// <summary>
        /// 进出口标志
        /// </summary>
        public String IEFlag { get; set; }

        /// <summary>
        /// 进出境关别
        /// </summary>
        public String IEPort { get; set; }

        /// <summary>
        /// 主管海关（申报地海关）
        /// </summary>
        public String CustomMaster { get; set; }

        /// <summary>
        /// 报关单类型
        /// </summary>
        public String EntryType { get; set; }

        /// <summary>
        /// 征免性质
        /// </summary>
        public String CutMode { get; set; }

        /// <summary>
        /// 监管方式
        /// </summary>
        public String TradeMode { get; set; }

        /// <summary>
        /// 成交方式
        /// </summary>
        public String TransMode { get; set; }

        /// <summary>
        /// 包装种类
        /// </summary>
        public String WrapType { get; set; }

        /// <summary>
        /// 运输方式代码
        /// </summary>
        public String TrafMode { get; set; }

        /// <summary>
        /// 征免方式
        /// </summary>
        public String DutyMode { get; set; }

        /// <summary>
        /// 原产国
        /// </summary>
        public String OriginCountry { get; set; }

        /// <summary>
        /// 成交币制
        /// </summary>
        public String TradeCurr { get; set; }

    }
}