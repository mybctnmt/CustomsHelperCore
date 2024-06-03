using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境货物产品信息
    /// </summary>
    [Table("itf_dcl_io_decl_goods")]
    public class itf_dcl_io_decl_goods
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
        /// 货物序号
        /// </summary>
        public String GNo { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public String CodeTs { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String GName { get; set; }

        /// <summary>
        /// 监管要求
        /// </summary>
        public String SupvDmd { get; set; }

        /// <summary>
        /// 币种代码
        /// </summary>
        public String CiqCurr { get; set; }

        /// <summary>
        /// HS标准计量单位数量
        /// </summary>
        public Decimal Qty1 { get; set; }

        /// <summary>
        /// HS标准计量单位
        /// </summary>
        public String Unit1 { get; set; }

        /// <summary>
        /// HS编码描述
        /// </summary>
        public String HsCodeDesc { get; set; }

        /// <summary>
        /// 检验检疫类别
        /// </summary>
        public String InspType { get; set; }

        /// <summary>
        /// CIQ代码
        /// </summary>
        public String CiqCode { get; set; }

        /// <summary>
        /// CIQ名称
        /// </summary>
        public String CiqName { get; set; }

        /// <summary>
        /// 申报货物名称（外文）
        /// </summary>
        public String DeclGoodsEname { get; set; }

        /// <summary>
        /// 货物规格
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
        /// 原产地区代码
        /// </summary>
        public String OrigPlaceCode { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public String ProduceDate { get; set; }

        /// <summary>
        /// 原产国
        /// </summary>
        public String CiqOriginCountry { get; set; }

        /// <summary>
        /// 产地代码（出口-国内地区）
        /// </summary>
        public String CiqDomeOriginCode { get; set; }

        /// <summary>
        /// 生产单位注册号
        /// </summary>
        public String MnufctrRegNo { get; set; }

        /// <summary>
        /// 生产单位名称
        /// </summary>
        public String MnufctrRegName { get; set; }

        /// <summary>
        /// 用途代码
        /// </summary>
        public String Purpose { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        public String ProdBatchNo { get; set; }

        /// <summary>
        /// 产品有效期
        /// </summary>
        public DateTime? ProdValidDt { get; set; }

        /// <summary>
        /// 产品保质期
        /// </summary>
        public Int32? ProdQgp { get; set; }

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
        public String UnCode { get; set; }

        /// <summary>
        /// 危险货物名称
        /// </summary>
        public String DangName { get; set; }

        /// <summary>
        /// 危包类别
        /// </summary>
        public String PackType { get; set; }

        /// <summary>
        /// 危包规格
        /// </summary>
        public String PackSpec { get; set; }

        /// <summary>
        /// 备用一
        /// </summary>
        public String By1 { get; set; }

        /// <summary>
        /// 备用二
        /// </summary>
        public String By2 { get; set; }

        /// <summary>
        /// 境外生产企业名称
        /// </summary>
        public String EngManEntCnm { get; set; }

        /// <summary>
        /// 是否危险品标识
        /// </summary>
        public String DangerFlag { get; set; }

        /// <summary>
        /// 非危险化学品标识
        /// </summary>
        public String NoDangFlag { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Decimal? CiqQty { get; set; }

        /// <summary>
        /// 数量计量单位代码
        /// </summary>
        public String CiqQtyMeasUnit { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public Decimal? CiqWeight { get; set; }

        /// <summary>
        /// 重量计量单位
        /// </summary>
        public String CiqWtMeasUnit { get; set; }

        /// <summary>
        /// HS标准量计量单位类型
        /// </summary>
        public String StdUnitTypeCode { get; set; }

        /// <summary>
        /// 标准重量
        /// </summary>
        public Decimal? StdWeight { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public Decimal? PricePerUnit { get; set; }

        /// <summary>
        /// 货物总值
        /// </summary>
        public Decimal? GoodsTotalVal { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// Gnumber
        /// </summary>
        public String Gnumber { get; set; }
        /// <summary>
        /// MainPackName
        /// </summary>
        public String MainPackName { get; set; }
        /// <summary>
        /// MainPackQty
        /// </summary>
        public String MainPackQty { get; set; }
        

    }
}