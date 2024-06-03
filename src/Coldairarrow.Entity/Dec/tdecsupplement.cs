using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 补充申报单信息
    /// </summary>
    [Table("tdecsupplement")]
    public class tdecsupplement
    {

        /// <summary>
        /// 补充申报单商品序号
        /// </summary>
        public Int32 GNo { get; set; }

        /// <summary>
        /// 补充申报单类型
        /// </summary>
        public String SupType { get; set; }

        /// <summary>
        /// 品牌中文
        /// </summary>
        public String BrandCN { get; set; }

        /// <summary>
        /// 品牌英文
        /// </summary>
        public String BrandEN { get; set; }

        /// <summary>
        /// 买方名称
        /// </summary>
        public String Buyer { get; set; }

        /// <summary>
        /// 买方联系人
        /// </summary>
        public String BuyerContact { get; set; }

        /// <summary>
        /// 买方地址
        /// </summary>
        public String BuyerAddr { get; set; }

        /// <summary>
        /// 买方电话
        /// </summary>
        public String BuyerTel { get; set; }

        /// <summary>
        /// 卖方名称
        /// </summary>
        public String Seller { get; set; }

        /// <summary>
        /// 卖方联系人
        /// </summary>
        public String SellerContact { get; set; }

        /// <summary>
        /// 卖方地址
        /// </summary>
        public String SellerAddr { get; set; }

        /// <summary>
        /// 卖方电话
        /// </summary>
        public String SellerTel { get; set; }

        /// <summary>
        /// 生产厂商名称
        /// </summary>
        public String Factory { get; set; }

        /// <summary>
        /// 生产厂商联系人
        /// </summary>
        public String FactoryContact { get; set; }

        /// <summary>
        /// 生产厂商地址
        /// </summary>
        public String FactoryAddr { get; set; }

        /// <summary>
        /// 生产厂商电话
        /// </summary>
        public String FactoryTel { get; set; }

        /// <summary>
        /// 合同协议号
        /// </summary>
        public String ContrNo { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        public String ContrDate { get; set; }

        /// <summary>
        /// 发票编号
        /// </summary>
        public String InvoiceNo { get; set; }

        /// <summary>
        /// 发票日期
        /// </summary>
        public String InvoiceDate { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_BabRel { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_PriceEffect { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_PriceClose { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_OtherLimited { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_OtherEffect { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_Note1 { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项。
        /// </summary>
        public String I_IsUsefee { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_IsProfit { get; set; }

        /// <summary>
        /// 价格申报项，进口货物申报项
        /// </summary>
        public String I_Note2 { get; set; }

        /// <summary>
        /// 价格申报项，币制
        /// </summary>
        public String Curr { get; set; }

        /// <summary>
        /// 价格申报项，发票价格单位金额
        /// </summary>
        public Decimal? InvoicePrice { get; set; }

        /// <summary>
        /// 价格申报项，发票价格总金额
        /// </summary>
        public Decimal? InvoiceAmount { get; set; }

        /// <summary>
        /// 价格申报项，发票价格备注
        /// </summary>
        public String InvoiceNote { get; set; }

        /// <summary>
        /// 价格申报项，间接支付/收取的货款单位金额，进口是间接支付，出口是间接收取
        /// </summary>
        public Decimal? GoodsPrice { get; set; }

        /// <summary>
        /// 价格申报项，间接支付/收取的货款总金额，进口是间接支付，出口是间接收取
        /// </summary>
        public Decimal? GoodsAmount { get; set; }

        /// <summary>
        /// 价格申报项，间接支付/收取的货款备注，进口是间接支付，出口是间接收取
        /// </summary>
        public String GoodsNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物除购货佣金以外的佣金和经纪费单位金额
        /// </summary>
        public Decimal? I_CommissionPrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物除购货佣金以外的佣金和经纪费总金额
        /// </summary>
        public Decimal? I_CommissionAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物除购货佣金以外的佣金和经纪费备注
        /// </summary>
        public String I_CommissionNote { get; set; }

        /// <summary>
        /// 价格申报项，与该进口货物视为一体的容器费用单位金额
        /// </summary>
        public Decimal? I_ContainerPrice { get; set; }

        /// <summary>
        /// 价格申报项，与该进口货物视为一体的容器费用总金额
        /// </summary>
        public Decimal? I_ContainerAmount { get; set; }

        /// <summary>
        /// 价格申报项，与该进口货物视为一体的容器费用备注
        /// </summary>
        public String I_ContainerNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物包装材料和包装劳务费用单位金额
        /// </summary>
        public Decimal? I_PackPrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物包装材料和包装劳务费用总金额
        /// </summary>
        public Decimal? I_PackAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物包装材料和包装劳务费用备注
        /// </summary>
        public String I_PackNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物包含的材料、部件、零件和类似货物单位金额
        /// </summary>
        public Decimal? I_PartPrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物包含的材料、部件、零件和类似货物总金额
        /// </summary>
        public Decimal? I_PartAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物包含的材料、部件、零件和类似货物备注
        /// </summary>
        public String I_PartNote { get; set; }

        /// <summary>
        /// 价格申报项，在生产进口货物过程中使用的工具、模具和类似货物单位金额
        /// </summary>
        public Decimal? I_ToolPrice { get; set; }

        /// <summary>
        /// 价格申报项，在生产进口货物过程中使用的工具、模具和类似货物总金额
        /// </summary>
        public Decimal? I_ToolAmount { get; set; }

        /// <summary>
        /// 价格申报项，在生产进口货物过程中使用的工具、模具和类似货物备注
        /// </summary>
        public String I_ToolNote { get; set; }

        /// <summary>
        /// 价格申报项，在生产进口货物过程中消耗的材料单位金额
        /// </summary>
        public Decimal? I_LossPrice { get; set; }

        /// <summary>
        /// 价格申报项，在生产进口货物过程中消耗的材料总金额
        /// </summary>
        public Decimal? I_LossAmount { get; set; }

        /// <summary>
        /// 价格申报项，在生产进口货物过程中消耗的材料备注
        /// </summary>
        public String I_LossNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务单位金额
        /// </summary>
        public Decimal? I_DesignPrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务总金额
        /// </summary>
        public Decimal? I_DesignAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务备注
        /// </summary>
        public String I_DesignNote { get; set; }

        /// <summary>
        /// 价格申报项，特许权使用费单位金额
        /// </summary>
        public Decimal? I_UsefeePrice { get; set; }

        /// <summary>
        /// 价格申报项，特许权使用费总金额
        /// </summary>
        public Decimal? I_UsefeeAmount { get; set; }

        /// <summary>
        /// 价格申报项，特许权使用费备注
        /// </summary>
        public String I_UsefeeNote { get; set; }

        /// <summary>
        /// 价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益单位金额
        /// </summary>
        public Decimal? I_ProfitPrice { get; set; }

        /// <summary>
        /// 价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益总金额
        /// </summary>
        public Decimal? I_ProfitAmount { get; set; }

        /// <summary>
        /// 价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益备注
        /// </summary>
        public String I_ProfitNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物运输费用单位金额
        /// </summary>
        public Decimal? I_FeePrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物运输费用总金额
        /// </summary>
        public Decimal? I_FeeAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物运输费用备注
        /// </summary>
        public String I_FeeNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物运输相关费用单位金额
        /// </summary>
        public Decimal? I_OtherPrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物运输相关费用总金额
        /// </summary>
        public Decimal? I_OtherAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物运输相关费用备注
        /// </summary>
        public String I_OtherNote { get; set; }

        /// <summary>
        /// 价格申报项，进口货物保险费单位金额
        /// </summary>
        public Decimal? I_InsurPrice { get; set; }

        /// <summary>
        /// 价格申报项，进口货物保险费总金额
        /// </summary>
        public Decimal? I_InsurAmount { get; set; }

        /// <summary>
        /// 价格申报项，进口货物保险费备注
        /// </summary>
        public String I_InsurNote { get; set; }

        /// <summary>
        /// 价格申报项，出口关税是否已经从申报价格中扣除
        /// </summary>
        public String E_IsDutyDel { get; set; }

        /// <summary>
        /// 归类申报项，商品其他名称
        /// </summary>
        public String GNameOther { get; set; }

        /// <summary>
        /// 归类申报项，进/出口国地区海关商品编码
        /// </summary>
        public String CodeTsOther { get; set; }

        /// <summary>
        /// 归类申报项
        /// </summary>
        public String IsClassDecision { get; set; }

        /// <summary>
        /// 归类申报项，预归类决定书编号
        /// </summary>
        public String DecisionNO { get; set; }

        /// <summary>
        /// 归类申报项，预归类决定书商品编码
        /// </summary>
        public String CodeTsDecision { get; set; }

        /// <summary>
        /// 归类申报项，作出预归类决定的直属海关
        /// </summary>
        public String DecisionCus { get; set; }

        /// <summary>
        /// 归类申报项，该商品是否曾被海关取样化验
        /// </summary>
        public String IsSampleTest { get; set; }

        /// <summary>
        /// GOptions
        /// </summary>
        public String GOptions { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        public String TrafMode { get; set; }

        /// <summary>
        /// 原产地申报项，是否直接运输
        /// </summary>
        public String IsDirectTraf { get; set; }

        /// <summary>
        /// 原产地申报项，中转国地区，如果选择非直接运输，必填
        /// </summary>
        public String TransitCountry { get; set; }

        /// <summary>
        /// 原产地申报项，到货口岸
        /// </summary>
        public String DestPort { get; set; }

        /// <summary>
        /// 原产地申报项，申报口岸
        /// </summary>
        public String DeclPort { get; set; }

        /// <summary>
        /// 原产地申报项，提单编号
        /// </summary>
        public String BillNo { get; set; }

        /// <summary>
        /// 原产地申报项
        /// </summary>
        public String OriginCountry { get; set; }

        /// <summary>
        /// 原产地申报项，原产国地区标记的位置
        /// </summary>
        public String OriginMark { get; set; }

        /// <summary>
        /// 原产地申报项，原产地证书签发机构及所在国家地区，非参数选项，可录入汉字或字母
        /// </summary>
        public String CertCountry { get; set; }

        /// <summary>
        /// 原产地申报项，原产地证书编号
        /// </summary>
        public String CertNO { get; set; }

        /// <summary>
        /// 原产地申报项，适用的原产地标准
        /// </summary>
        public String CertStandard { get; set; }

        /// <summary>
        /// 公共申报项，其他需要说明的情况
        /// </summary>
        public String OtherNote { get; set; }

        /// <summary>
        /// 对以上申报内容是否需要海关予以保密
        /// </summary>
        public String IsSecret { get; set; }

        /// <summary>
        /// 申报单位类型
        /// </summary>
        public String AgentType { get; set; }

        /// <summary>
        /// 申报人单位地址
        /// </summary>
        public String DeclAddr { get; set; }

        /// <summary>
        /// 申报人邮编
        /// </summary>
        public String DeclPost { get; set; }

        /// <summary>
        /// 申报人电话
        /// </summary>
        public String DeclTel { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 99)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}