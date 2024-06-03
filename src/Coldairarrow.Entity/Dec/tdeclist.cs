using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 进出口报关单表体
    /// </summary>
    [Table("tdeclist")]
    public class tdeclist
    {

        /// <summary>
        /// 归类标志
        /// </summary>
        public String ClassMark { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public String CodeTS { get; set; }

        /// <summary>
        /// 备案序号
        /// </summary>
        public Int64? ContrItem { get; set; }

        /// <summary>
        /// 申报单价
        /// </summary>
        public Decimal? DeclPrice { get; set; }

        /// <summary>
        /// 申报总价
        /// </summary>
        public Decimal? DeclTotal { get; set; }

        /// <summary>
        /// 征免方式
        /// </summary>
        public String DutyMode { get; set; }

        /// <summary>
        /// 货号
        /// </summary>
        public String ExgNo { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public Int32? ExgVersion { get; set; }

        /// <summary>
        /// 申报计量单位与法定单位比例因子
        /// </summary>
        public Decimal? Factor { get; set; }

        /// <summary>
        /// 第一计量单位（法定单位）
        /// </summary>
        public String FirstUnit { get; set; }

        /// <summary>
        /// 第一法定数量
        /// </summary>
        public Decimal? FirstQty { get; set; }

        /// <summary>
        /// 成交计量单位
        /// </summary>
        public String GUnit { get; set; }

        /// <summary>
        /// 商品规格、型号
        /// </summary>
        public String GModel { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String GName { get; set; }

        /// <summary>
        /// 商品序号
        /// </summary>
        public Int64? GNo { get; set; }

        /// <summary>
        /// 成交数量
        /// </summary>
        public Decimal? GQty { get; set; }

        /// <summary>
        /// 原产国
        /// </summary>
        public String OriginCountry { get; set; }

        /// <summary>
        /// 第二计量单位
        /// </summary>
        public String SecondUnit { get; set; }

        /// <summary>
        /// 第二法定数量
        /// </summary>
        public Decimal? SecondQty { get; set; }

        /// <summary>
        /// 成交币制
        /// </summary>
        public String TradeCurr { get; set; }

        /// <summary>
        /// 用途/生产厂家
        /// </summary>
        public String UseTo { get; set; }

        /// <summary>
        /// 工缴费
        /// </summary>
        public Decimal? WorkUsd { get; set; }

        /// <summary>
        /// 最终目的国（地区）
        /// </summary>
        public String DestinationCountry { get; set; }

        /// <summary>
        /// 检验检疫编码
        /// </summary>
        public String CiqCode { get; set; }

        /// <summary>
        /// 商品英文名称
        /// </summary>
        public String DeclGoodsEname { get; set; }

        /// <summary>
        /// 原产地区代码
        /// </summary>
        public String OrigPlaceCode { get; set; }

        /// <summary>
        /// 用途代码
        /// </summary>
        public String Purpose { get; set; }

        /// <summary>
        /// 产品有效期
        /// </summary>
        public String ProdValidDt { get; set; }

        /// <summary>
        /// 产品保质期
        /// </summary>
        public String ProdQgp { get; set; }

        /// <summary>
        /// 货物属性代码
        /// </summary>
        public String GoodsAttr { get; set; }

        /// <summary>
        /// 成份/原料/组份
        /// </summary>
        public String Stuff { get; set; }

        /// <summary>
        /// UN编码
        /// </summary>
        public String Uncode { get; set; }

        /// <summary>
        /// 危险货物名称
        /// </summary>
        public String DangName { get; set; }

        /// <summary>
        /// 危包类别
        /// </summary>
        public String DangPackType { get; set; }

        /// <summary>
        /// 危包规格
        /// </summary>
        public String DangPackSpec { get; set; }

        /// <summary>
        /// 境外生产企业名称
        /// </summary>
        public String EngManEntCnm { get; set; }

        /// <summary>
        /// 非危险化学品
        /// </summary>
        public String NoDangFlag { get; set; }

        /// <summary>
        /// 目的地代码
        /// </summary>
        public String DestCode { get; set; }

        /// <summary>
        /// 检验检疫货物规格
        /// </summary>
        public String GoodsSpec { get; set; }

        /// <summary>
        /// 货物型号
        /// </summary>
        public String GoodsModel { get; set; }

        /// <summary>
        /// 货物品牌
        /// </summary>
        public String GoodsBrand { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public String ProduceDate { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        public String ProdBatchNo { get; set; }

        /// <summary>
        /// 境内目的地/境内货源地
        /// </summary>
        public String DistrictCode { get; set; }

        /// <summary>
        /// 检验检疫名称
        /// </summary>
        public String CiqName { get; set; }

        /// <summary>
        /// 生产单位注册号
        /// </summary>
        public String MnufctrRegno { get; set; }

        /// <summary>
        /// 生产单位名称
        /// </summary>
        public String MnufctrRegName { get; set; }

        /// <summary>
        /// 优惠贸易协定项下原产地
        /// </summary>
        public String RcepOrigPlaceCode { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 49)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }
        /// <summary>
        /// 原产地证明编号
        /// </summary>
        public string CertOriCode { get; set; }
        /// <summary>
        /// 优惠贸易协定代码
        /// </summary>
        public string PreTradeAgreeCode { get; set; }
        /// <summary>
        /// 原产地证明商品项号
        /// </summary>
        public string CertOriModItem { get; set; }
        /// <summary>
        /// 原产地证明类型 原产地声明(D) 原产地证书(C)
        /// </summary>
        public string OriCertType { get; set; }


    }
}