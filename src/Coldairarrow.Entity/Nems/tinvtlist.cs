using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Nems
{
    /// <summary>
    /// 核注清单标体
    /// </summary>
    [Table("tinvtlist")]
    public class tinvtlist
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }
        public String Id { get; set; }
        /// <summary>
        /// 中心统一编号
        /// </summary>

        public String SeqNo { get; set; }

        /// <summary>
        /// 商品序号
        /// </summary>
       
        public Decimal GdsSeqNo { get; set; }

        /// <summary>
        /// 备案序号(对应底账序号）
        /// </summary>
       
        public Decimal PutrecSeqNo { get; set; }

        /// <summary>
        /// 商品料号
        /// </summary>
        public String GdsMtno { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public String Gdecd { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String GdsNm { get; set; }

        /// <summary>
        /// 商品规格型号
        /// </summary>
        public String GdsSpcfModelDesc { get; set; }

        /// <summary>
        /// 申报计量单位
        /// </summary>
        public String DclUnitcd { get; set; }

        /// <summary>
        /// 法定计量单位
        /// </summary>
        public String LawfUnitcd { get; set; }

        /// <summary>
        /// 法定第二计量
        /// </summary>
        public String SecdLawfUnitcd { get; set; }

        /// <summary>
        /// 原产国(地区)
        /// </summary>
        public String Natcd { get; set; }

        /// <summary>
        /// 企业申报单价
        /// </summary>
        public Decimal DclUprcAmt { get; set; }

        /// <summary>
        /// 企业申报总价
        /// </summary>
        public Decimal DclTotalAmt { get; set; }

        /// <summary>
        /// 美元统计总金额
        /// </summary>
        public Decimal UsdStatTotalAmt { get; set; }

        /// <summary>
        /// 币制
        /// </summary>
        public String DclCurrcd { get; set; }

        /// <summary>
        /// 法定数量
        /// </summary>
        public Decimal LawfQty { get; set; }

        /// <summary>
        /// 第二法定数量
        /// </summary>
        public Decimal? SecdLawfQty { get; set; }

        /// <summary>
        /// 重量比例因子
        /// </summary>
        public Decimal? WtSfval { get; set; }

        /// <summary>
        /// 第一比例因子
        /// </summary>
        public Decimal? FstSfval { get; set; }

        /// <summary>
        /// 第二比例因子
        /// </summary>
        public Decimal? SecdSfval { get; set; }

        /// <summary>
        /// 申报数量
        /// </summary>
        public Decimal DclQty { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        public Decimal? GrossWt { get; set; }

        /// <summary>
        /// 净重
        /// </summary>
        public Decimal? NetWt { get; set; }

        /// <summary>
        /// 用途代码
        /// </summary>
        public String UseCd { get; set; }

        /// <summary>
        /// 征免方式
        /// </summary>
        public String LvyrlfModecd { get; set; }

        /// <summary>
        /// 单耗版本号
        /// </summary>
        public String UcnsVerno { get; set; }

        /// <summary>
        /// 报关单商品序号
        /// </summary>
        public Decimal? EntryGdsSeqno { get; set; }

        /// <summary>
        /// 归类标志
        /// </summary>
        public String ClyMarkcd { get; set; }

        /// <summary>
        /// 流转申报表序号
        /// </summary>
        public Decimal? ApplyTbSeqno { get; set; }

        /// <summary>
        /// 最终目的国(地区)
        /// </summary>
        public String DestinationNatcd { get; set; }

        /// <summary>
        /// 修改标志
        /// </summary>
        public String ModfMarkcd { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Rmk { get; set; }
        public string OrderNo { get; set; }

    }
}