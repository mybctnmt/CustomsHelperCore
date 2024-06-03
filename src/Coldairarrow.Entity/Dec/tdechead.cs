using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    ///  进出口报关单表头 
    /// </summary>
    [Table("tdechead")]
    public class tdechead
    {

        /// <summary>
        /// 申报单位代码
        /// </summary>
        public String AgentCode { get; set; }

        /// <summary>
        /// 申报单位名称
        /// </summary>
        public String AgentName { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        public String ApprNo { get; set; }

        /// <summary>
        /// 提单号
        /// </summary>
        public String BillNo { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public String ContrNo { get; set; }

        /// <summary>
        /// 录入单位代码
        /// </summary>
        public String CopCode { get; set; }

        /// <summary>
        /// 录入单位名称
        /// </summary>
        public String CopName { get; set; }

        /// <summary>
        /// 主管海关（申报地海关）
        /// </summary>
        public String CustomMaster { get; set; }

        /// <summary>
        /// 征免性质
        /// </summary>
        public String CutMode { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public String DataSource { get; set; }

        /// <summary>
        /// 报关/转关关系标志
        /// </summary>
        public String DeclTrnRel { get; set; }

        /// <summary>
        /// 经停港/指运港
        /// </summary>
        public String DistinatePort { get; set; }

        /// <summary>
        /// 报关标志
        /// </summary>
        public String EdiId { get; set; }

        /// <summary>
        /// 海关编号
        /// </summary>
        public String EntryId { get; set; }

        /// <summary>
        /// 报关单类型
        /// </summary>
        public String EntryType { get; set; }

        /// <summary>
        /// 运费币制
        /// </summary>
        public String FeeCurr { get; set; }

        /// <summary>
        /// 运费标记
        /// </summary>
        public String FeeMark { get; set; }

        /// <summary>
        /// 运费／率
        /// </summary>
        public Decimal? FeeRate { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        public Decimal? GrossWet { get; set; }

        /// <summary>
        /// 进出口日期
        /// </summary>
        public String IEDate { get; set; }

        /// <summary>
        /// 进出口标志
        /// </summary>
        public String IEFlag { get; set; }

        /// <summary>
        /// 进出境关别
        /// </summary>
        public String IEPort { get; set; }

        /// <summary>
        /// 录入员名称
        /// </summary>
        public String InputerName { get; set; }

        /// <summary>
        /// 保险费币制
        /// </summary>
        public String InsurCurr { get; set; }

        /// <summary>
        /// 保险费标记
        /// </summary>
        public String InsurMark { get; set; }

        /// <summary>
        /// 保险费／率
        /// </summary>
        public Decimal? InsurRate { get; set; }

        /// <summary>
        /// 许可证编号
        /// </summary>
        public String LicenseNo { get; set; }

        /// <summary>
        /// 备案号
        /// </summary>
        public String ManualNo { get; set; }

        /// <summary>
        /// 净重
        /// </summary>
        public Decimal? NetWt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String NoteS { get; set; }

        /// <summary>
        /// 杂费币制
        /// </summary>
        public String OtherCurr { get; set; }

        /// <summary>
        /// 杂费标志
        /// </summary>
        public String OtherMark { get; set; }

        /// <summary>
        /// 杂费／率
        /// </summary>
        public Decimal? OtherRate { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位代码
        /// </summary>
        public String OwnerCode { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位名称
        /// </summary>
        public String OwnerName { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public Int32? PackNo { get; set; }

        /// <summary>
        /// 申报人标识
        /// </summary>
        public String PartenerID { get; set; }

        /// <summary>
        /// 打印日期
        /// </summary>
        public String PDate { get; set; }

        /// <summary>
        /// 预录入编号
        /// </summary>
        public String PreEntryId { get; set; }

        /// <summary>
        /// 风险评估参数
        /// </summary>
        public String Risk { get; set; }

        /// <summary>
        /// 数据中心统一编号
        /// </summary>
        public String SeqNo { get; set; }

        /// <summary>
        /// 关联单据号
        /// </summary>
        public String TgdNo { get; set; }

        /// <summary>
        /// 启运国/运抵国
        /// </summary>
        public String TradeCountry { get; set; }

        /// <summary>
        /// 监管方式
        /// </summary>
        public String TradeMode { get; set; }

        /// <summary>
        /// 境内收发货人编号
        /// </summary>
        public String TradeCode { get; set; }

        /// <summary>
        /// 运输方式代码
        /// </summary>
        public String TrafMode { get; set; }

        /// <summary>
        /// 运输工具代码及名称
        /// </summary>
        public String TrafName { get; set; }

        /// <summary>
        /// 境内收发货人名称
        /// </summary>
        public String TradeName { get; set; }

        /// <summary>
        /// 成交方式
        /// </summary>
        public String TransMode { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// 录入员IC卡号
        /// </summary>
        public String TypistNo { get; set; }

        /// <summary>
        /// 包装种类
        /// </summary>
        public String WrapType { get; set; }

        /// <summary>
        /// 担保验放标志
        /// </summary>
        public String ChkSurety { get; set; }

        /// <summary>
        /// 备案清单类型
        /// </summary>
        public String BillType { get; set; }

        /// <summary>
        /// 录入单位统一编码
        /// </summary>
        public String CopCodeScc { get; set; }

        /// <summary>
        /// 收发货人统一编码
        /// </summary>
        public String TradeCoScc { get; set; }

        /// <summary>
        /// 申报代码统一编码
        /// </summary>
        public String AgentCodeScc { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位单位统一编码
        /// </summary>
        public String OwnerCodeScc { get; set; }

        /// <summary>
        /// 价格说明
        /// </summary>
        public String PromiseItmes { get; set; }

        /// <summary>
        /// 贸易国别
        /// </summary>
        public String TradeAreaCode { get; set; }

        /// <summary>
        /// 查验分流
        /// </summary>
        public String CheckFlow { get; set; }

        /// <summary>
        /// 税收征管标记
        /// </summary>
        public String TaxAaminMark { get; set; }

        /// <summary>
        /// 标记唛码
        /// </summary>
        public String MarkNo { get; set; }

        /// <summary>
        /// 启运港代码
        /// </summary>
        public String DespPortCode { get; set; }

        /// <summary>
        /// 入境口岸代码
        /// </summary>
        public String EntyPortCode { get; set; }

        /// <summary>
        /// 存放地点
        /// </summary>
        public String GoodsPlace { get; set; }

        /// <summary>
        /// B/L号
        /// </summary>
        public String BLNo { get; set; }

        /// <summary>
        /// 口岸检验检疫机关
        /// </summary>
        public String InspOrgCode { get; set; }

        /// <summary>
        /// 特种业务标识
        /// </summary>
        public String SpecDeclFlag { get; set; }

        /// <summary>
        /// 目的地检验检疫机关
        /// </summary>
        public String PurpOrgCode { get; set; }

        /// <summary>
        /// 启运日期
        /// </summary>
        public String DespDate { get; set; }

        /// <summary>
        /// 卸毕日期
        /// </summary>
        public String CmplDschrgDt { get; set; }

        /// <summary>
        /// 关联理由
        /// </summary>
        public String CorrelationReasonFlag { get; set; }

        /// <summary>
        /// 领证机关
        /// </summary>
        public String VsaOrgCode { get; set; }

        /// <summary>
        /// 原集装箱标识
        /// </summary>
        public String OrigBoxFlag { get; set; }

        /// <summary>
        /// 申报人员姓名
        /// </summary>
        public String DeclareName { get; set; }

        /// <summary>
        /// 无其他包装
        /// </summary>
        public String NoOtherPack { get; set; }

        /// <summary>
        /// 检验检疫受理机关
        /// </summary>
        public String OrgCode { get; set; }

        /// <summary>
        /// 境外发货人代码
        /// </summary>
        public String OverseasConsignorCode { get; set; }

        /// <summary>
        /// 境外收发货人名称
        /// </summary>
        public String OverseasConsignorCname { get; set; }

        /// <summary>
        /// 境外发货人名称（外文）
        /// </summary>
        public String OverseasConsignorEname { get; set; }

        /// <summary>
        /// 境外收发货人地址
        /// </summary>
        public String OverseasConsignorAddr { get; set; }

        /// <summary>
        /// 境外收货人编码
        /// </summary>
        public String OverseasConsigneeCode { get; set; }

        /// <summary>
        /// 境外收货人名称(外文)
        /// </summary>
        public String OverseasConsigneeEname { get; set; }

        /// <summary>
        /// 境内收发货人名称（外文）
        /// </summary>
        public String DomesticConsigneeEname { get; set; }
        /// <summary>
        /// 境内收发货人名称（中文）
        /// </summary>
        public String DomesticConsigneeCname { get; set; }

        /// <summary>
        /// 关联号码
        /// </summary>
        public String CorrelationNo { get; set; }

        /// <summary>
        /// EDI申报备注
        /// </summary>
        public String EdiRemark { get; set; }

        /// <summary>
        /// EDI申报备注2
        /// </summary>
        public String EdiRemark2 { get; set; }

        /// <summary>
        /// 境内收发货人检验检疫编码
        /// </summary>
        public String TradeCiqCode { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位检验检疫编码
        /// </summary>
        public String OwnerCiqCode { get; set; }

        /// <summary>
        /// 申报单位检验检疫编码
        /// </summary>
        public String DeclCiqCode { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 92)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }


        //新增状态字段 9 放行
        public string CusDecStatus { get; set; }
        public string CusDecStatusName { get; set; }
        public string EncryptString { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public string DDate { get; set; }
        
        /// <summary>
        /// 业务事项
        /// </summary>
        public string CusRemark { get; set; }
        /// <summary>
        /// 航次号
        /// </summary>
        public string CusVoyageNo { get; set; }
        /// <summary>
        /// 企业承诺
        /// </summary>
        public bool? IsCopPromise { get; set; }
        /// <summary>
        /// 是否手动绑定
        /// </summary>
        public bool? IsManualBind { get; set; }
    }
}