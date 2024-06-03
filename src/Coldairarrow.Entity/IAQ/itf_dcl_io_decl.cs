using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境检验检疫申请基本信息
    /// </summary>
    [Table("itf_dcl_io_decl")]
    public class itf_dcl_io_decl
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
        /// 关检关联号
        /// </summary>
        public String CusCiqNo { get; set; }

        /// <summary>
        /// 提/运单号
        /// </summary>
        public String BillNo { get; set; }

        /// <summary>
        /// 目的地代码
        /// </summary>
        public String CiqDestCode { get; set; }

        /// <summary>
        /// 运输方式代码
        /// </summary>
        public String CiqTrafMode { get; set; }

        /// <summary>
        /// 运输工具名称
        /// </summary>
        public String TrafName { get; set; }

        /// <summary>
        /// 运输工具号码
        /// </summary>
        public String CusVoyageNo { get; set; }

        /// <summary>
        /// 贸易国别代码
        /// </summary>
        public String CiqTradeCountryCode { get; set; }

        /// <summary>
        /// 启运国家代码
        /// </summary>
        public String CiqDespCtryCode { get; set; }

        /// <summary>
        /// 入境口岸代码
        /// </summary>
        public String CiqEntyPortCode { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public String ContractNo { get; set; }

        /// <summary>
        /// 企业UUID
        /// </summary>
        public String EntUuid { get; set; }

        /// <summary>
        /// 发货人代码
        /// </summary>
        public String ConsignorCode { get; set; }

        /// <summary>
        /// 发货人名称（中文）
        /// </summary>
        public String ConsignorCname { get; set; }

        /// <summary>
        /// 发货人名称（外文）
        /// </summary>
        public String ConsignorEname { get; set; }

        /// <summary>
        /// 发货人地址
        /// </summary>
        public String ConsignorAddr { get; set; }

        /// <summary>
        /// 收货人代码
        /// </summary>
        public String ConsigneeCode { get; set; }

        /// <summary>
        /// 收货人名称（中文）
        /// </summary>
        public String ConsigneeCname { get; set; }

        /// <summary>
        /// 收货人名称（外文）
        /// </summary>
        public String ConsigneeEname { get; set; }

        /// <summary>
        /// 收货人地址
        /// </summary>
        public String ConsigneeAddr { get; set; }

        /// <summary>
        /// 贸易方式代码
        /// </summary>
        public String TradeModeCode { get; set; }

        /// <summary>
        /// 标记及号码
        /// </summary>
        public String MarkNo { get; set; }

        /// <summary>
        /// 启运口岸代码
        /// </summary>
        public String DespPortCode { get; set; }

        /// <summary>
        /// 经停口岸代码
        /// </summary>
        public String PortStopCode { get; set; }

        /// <summary>
        /// 存放地点
        /// </summary>
        public String GoodsPlace { get; set; }

        /// <summary>
        /// 索赔截止日期
        /// </summary>
        public DateTime? CounterClaim { get; set; }

        /// <summary>
        /// 提货单号
        /// </summary>
        public String DeliveryOrder { get; set; }

        /// <summary>
        /// 口岸机构
        /// </summary>
        public String InspOrgCode { get; set; }

        /// <summary>
        /// 施检地代码
        /// </summary>
        public String InspPlaceCode { get; set; }

        /// <summary>
        /// 特种业务标识, 1表示勾选. 进出境都是传递4位（0或者1组成），第一位：国际赛事，第二位：特殊进出军工物资，第三位：国际援助物资，第四位：国际会议
        /// </summary>
        public String SpecDeclFlag { get; set; }

        /// <summary>
        /// 目的机构代码
        /// </summary>
        public String PurpOrgCode { get; set; }

        /// <summary>
        /// 检验检疫申请员证号
        /// </summary>
        public String DeclPersnCertNo { get; set; }

        /// <summary>
        /// 检验检疫申请员姓名
        /// </summary>
        public String DeclPersonName { get; set; }

        /// <summary>
        /// 检验检疫申请单位联系人
        /// </summary>
        public String Contactperson { get; set; }

        /// <summary>
        /// 检验检疫申请联系人电话
        /// </summary>
        public String ContTel { get; set; }

        /// <summary>
        /// 检验检疫申请类别代码
        /// </summary>
        public String DeclCode { get; set; }

        /// <summary>
        /// 检验检疫申请申报日期
        /// </summary>
        public DateTime? DeclDate { get; set; }

        /// <summary>
        /// 到货日期
        /// </summary>
        public DateTime? GdsArvlDate { get; set; }

        /// <summary>
        /// 特殊通关模式, 1表示勾选. 入境：直通放行 外交礼遇 转关（需要传递4位字符串，第一位：直通放行，第二位：0，第三位：外交礼遇，第四位：转关） 出境：直通放行 绿色通道 外交礼遇（需要传递3位字符串，第一位：直通放行，第二位：绿色通道，第三位：外交礼遇）
        /// </summary>
        public String SpecPassFlag { get; set; }

        /// <summary>
        /// 入境：启运日期 出境：发货日期
        /// </summary>
        public DateTime? DespDate { get; set; }

        /// <summary>
        /// 随附单据名称串
        /// </summary>
        public String AttaCollectName { get; set; }

        /// <summary>
        /// 货物总值（美元） 申报货物为“0001”或“0002”品目的木质包装或集装箱除外的其他所有货物。
        /// </summary>
        public Decimal? TotalValUsD { get; set; }

        /// <summary>
        /// 货物总值（人民币） 申报货物为“0001”或“0002”品目的木质包装或集装箱除外的其他所有货物。
        /// </summary>
        public Decimal? TotalValCn { get; set; }

        /// <summary>
        /// 集装箱适载核销状态
        /// </summary>
        public String ContCancelFlag { get; set; }

        /// <summary>
        /// 申请单证名称
        /// </summary>
        public String AppCertName { get; set; }

        /// <summary>
        /// 检验检疫申请单位代码
        /// </summary>
        public String DeclRegNo { get; set; }

        /// <summary>
        /// 检验检疫申请单位名称
        /// </summary>
        public String DeclRegName { get; set; }

        /// <summary>
        /// 卸毕日期
        /// </summary>
        public DateTime? CmplDschrgDt { get; set; }

        /// <summary>
        /// 关联检验检疫申请号
        /// </summary>
        public String CorrelationDeclNo { get; set; }

        /// <summary>
        /// 关联理由
        /// </summary>
        public String CorrelationReasonFlag { get; set; }

        /// <summary>
        /// 特殊检验检疫要求
        /// </summary>
        public String SpeclInspQuraRe { get; set; }

        /// <summary>
        /// 到达口岸代码
        /// </summary>
        public String ArrivPortCode { get; set; }

        /// <summary>
        /// 分运单号
        /// </summary>
        public String SplitBillLadNo { get; set; }

        /// <summary>
        /// 检验检疫申请地
        /// </summary>
        public String OrgCode { get; set; }

        /// <summary>
        /// 领证地
        /// </summary>
        public String VsaOrgCode { get; set; }

        /// <summary>
        /// 入境原集装箱装载直接到目的机构，【1：是；0：否】
        /// </summary>
        public String OrigBoxFlag { get; set; }

        /// <summary>
        /// 入出境标识（检验检疫）I:进境，E：出境
        /// </summary>
        public String CiqIEFlag { get; set; }

        /// <summary>
        /// 企业内部编号
        /// </summary>
        public String CopNo { get; set; }

        /// <summary>
        /// 报关海关
        /// </summary>
        public String CustomMaster { get; set; }

        /// <summary>
        /// 海关注册号
        /// </summary>
        public String CustmRegNo { get; set; }

        /// <summary>
        /// 是否勾选企业承诺; 如勾选需要企业资质中增加证明或声明材料。 0：未勾选；1：勾选。
        /// </summary>
        public String IsCopPromise { get; set; }

        /// <summary>
        /// 属地查检标识：5-属地查检
        /// </summary>
        public String DeclareFlag { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}