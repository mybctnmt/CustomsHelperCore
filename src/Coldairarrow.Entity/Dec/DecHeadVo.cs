using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    public class DecHeadVo
    {
        public string customsField { get; set; }

        public string insurCurr { get; set; }

        public string ciqEntyPortCode { get; set; }
        //进口的境内名称
        public string consigneeCname { get; set; }
        public string rcvgdTradeCode { get; set; }
        public string ediRemark2 { get; set; }
        public string appCertCode { get; set; }
        public string gdsArvlDate { get; set; }
        public string despDate { get; set; }
        public string rcvgdTradeScc { get; set; }
        public string consignorEname { get; set; }
        public string appCertName { get; set; }

        public string specDeclFlag { get; set; }
        public string consignorCode { get; set; }
        public string insurRate { get; set; }
        public string entryId { get; set; }
        public string ciqDecStatusName { get; set; }
        public string coOwner { get; set; }
        public string ciqTradeCountryCode { get; set; }
        public string declCodeName { get; set; }
        public string customMasterName { get; set; }
        public object preDecCiqMarkLob { get; set; }
        public string contractNo { get; set; }
        public string cusCiqNo { get; set; }
        public object preDecRequCertList { get; set; }
        public string despPortCode { get; set; }
        public string ownerCiqCode { get; set; }
        public string ownerCode { get; set; }
        public string ciqDespCtryCode { get; set; }
        public string ownerName { get; set; }
        public string cnsnTradeCode { get; set; }
        public string dataSrcModeCode { get; set; }
        public object decMergeListVo { get; set; }//商品表   只有他update  tdeclist
        public object preDecUserList { get; set; }
        public string spDecSeqNo { get; set; }
        public string agentCode { get; set; }
        public string transMode { get; set; }
        public string cusTradeCountry { get; set; }
        public string insurMark { get; set; }
        public string dataSrcUnitCode { get; set; }
        public string isudMark { get; set; }
        public string feeMarkName { get; set; }
        public string tradeModeCode { get; set; }
        public string cusVoyageNo { get; set; }
        public string declDate { get; set; }
        public string agentScc { get; set; }
        public string ciqIsudMark { get; set; }
        public string indbTime { get; set; }
        public string cusTradeCountryName { get; set; }
        public string ediRemark { get; set; }
        public string extendField { get; set; }
        public string insurMarkName { get; set; }
        public string tradeModeCodeName { get; set; }
        public string cusTrafMode { get; set; }
        public string consigneeEname { get; set; }
        public string packNo { get; set; }
        public object preDecEntQualifListVo { get; set; }
        public string ciqIEFlag { get; set; }
        public object decOtherPacksVo { get; set; }//其他包装 tDecOtherPack
        public string contaCount { get; set; }
        public string declCode { get; set; }
        public string typistNo { get; set; }
        public string ciqTradeCountryCodeName { get; set; }
        public string feeCurr { get; set; }
        public string dDate { get; set; }
        public string isCopPromise { get; set; }
        public string entryTypeName { get; set; }
        public string ciqVoyageNo { get; set; }
        public string feeRate { get; set; }
        public string iEDate { get; set; }
        public string agentName { get; set; }
        public string supvModeCdde { get; set; }
        public object preDecContainerVo { get; set; }//集装箱 tDecContainer
        public string dclrNo { get; set; }
        public string wrapType { get; set; }
        public string custmRegNo { get; set; }
        public string ownerScc { get; set; }
        public string tableFlag { get; set; }
        public string iEPort { get; set; }
        public string cusIEFlag { get; set; }
        public string attaDocuCdstr { get; set; }
        public string netWt { get; set; }
        public string billNo { get; set; }
        public string cusTradeNationCode { get; set; }
        public string ciqDespCtryCodeName { get; set; }
        public string despPortCodeName { get; set; }
        public string feeMark { get; set; }
        public string updateTime { get; set; }
        public object preDecCiqDeclAttListVo { get; set; }
        public string dclTrnRelFlag { get; set; }
        public string ediId { get; set; }
        public string inputEtpsCode { get; set; }
        public string inputErName { get; set; }
        public string createUser { get; set; }
        public string declRegName { get; set; }
        public string promiseItems { get; set; }
        public string dataSrcCode { get; set; }
        public string markNo { get; set; }
        public string portStopCode { get; set; }
        public string updateUser { get; set; }
        public string arrivPortCode { get; set; }
        public string cnsnTradeScc { get; set; }
        public string transModeName { get; set; }
        public string consignorCname { get; set; }
        public object preDecDocVo { get; set; }
        public string cusDecStatus { get; set; }
        public string distinatePort { get; set; }
        public string cusTrafModeName { get; set; }
        public string deliveryOrder { get; set; }
        public string cusDecStatusName { get; set; }
        public string ciqTrafMode { get; set; }
        public string cutModeName { get; set; }
        public string ciqTrafModeName { get; set; }
        public string wrapTypeName { get; set; }
        public string cutMode { get; set; }
        public string contrNo { get; set; }
        public string chktstFlag { get; set; }
        public string trafName { get; set; }
        public string grossWt { get; set; }
        public string arrivPortCodeName { get; set; }
        public string customMaster { get; set; }
        public string feeCurrName { get; set; }
        public string cusRemark { get; set; }
        public string iEPortName { get; set; }
        public object cusLicenseListVo { get; set; }//随附单证 tDecLicenseDocus
        public string districtCode { get; set; }
        public string entryType { get; set; }
        public string inputEtpsName { get; set; }
        public string supvModeCddeName { get; set; }
        public string cusTradeNationCodeName { get; set; }
        public string specPassFlag { get; set; }
        public string preEntryId { get; set; }
        public string distinatePortName { get; set; }
        public string ciqDecStatus { get; set; }
        public string orderNo { get; set; }

        public string otherRate { get; set; }

        public string noteS { get; set; }


        public string consigneeCode { get; set; }

        public string goodsPlace { get; set; }

        public string otherCurr { get; set; }

        public string speclInspQuraRe { get; set; }

        public string otherCurrName { get; set; }

        public string ciqDestCode { get; set; }

        public string otherMark { get; set; }

        public string relativeId { get; set; }
        public string relmanNo { get; set; }
        public string bonNo { get; set; }
        public string customsFieldName { get; set; }
        public string declRegNo { get; set; }

        public string inspOrgCode { get; set; }
        public string inspOrgCodeName { get; set; }
        public string orgCode { get; set; }
        public string orgCodeName { get; set; }
        public string vsaOrgCode { get; set; }
        public string vsaOrgCodeName { get; set; }
        public string purpOrgCode { get; set; }
        public string purpOrgCodeName { get; set; }
        public string manualNo { get; set; }
        public string licenseNo { get; set; }
        public string correlationDeclNo { get; set; }
        public string correlationReasonFlagName { get; set; }
        public string origBoxFlag { get; set; }
        public string consignorAddr { get; set; }
        public bool? isManualBind { get; set; }
    }
    /// <summary>
    /// 商品
    /// </summary>
    public class MergeListVo
    {
        public string rcepOrigPlaceCode { get; set; }
        public string mnufctrRegName { get; set; }
        public string mnufctrRegno { get; set; }
        public string ciqName { get; set; }
        public string prodBatchNo { get; set; }
        public string produceDate { get; set; }
        public string goodsBrand { get; set; }
        public string goodsModel { get; set; }
        public string goodsSpec { get; set; }
        public string noDangFlag { get; set; }
        public string engManEntCnm { get; set; }
        public string dangPackSpec { get; set; }
        public string dangPackType { get; set; }
        public string dangName { get; set; }
        public string uncode { get; set; }
        public string stuff { get; set; }
        public string goodsAttr { get; set; }
        public string prodQgp { get; set; }
        public string prodValidDt { get; set; }
        public string declGoodsEname { get; set; }
        public string ciqCode { get; set; }
        public decimal? workUsd { get; set; }
        public string useTo { get; set; }
        public decimal? factor { get; set; }

        public int? exgVersion { get; set; }

        public string exgNo { get; set; }

        public string unit2 { get; set; }
        public string qty2 { get; set; }

        public int? gNo { get; set; }
        public string codeTs { get; set; }
        public string gModel { get; set; }
        public string ciqWtMeasUnit { get; set; }
        public string ciqCurr { get; set; }
        public string ciqWtMeasUnitName { get; set; }
        public string gUnitName { get; set; }
        public string tradeCurrName { get; set; }
        public string destinationCountryName { get; set; }
        public string cusOriginCountry { get; set; }
        public string gQty { get; set; }
        public string goodsLegalInspectionMark { get; set; }
        public string declPrice { get; set; }
        public string gName { get; set; }
        public string qty1 { get; set; }
        public string cusCiqNo { get; set; }
        public string dutyModeName { get; set; }
        public string hsCodeDesc { get; set; }
        public string goodsTotalVal { get; set; }
        public string districtCodeName { get; set; }
        public string dutyMode { get; set; }
        public string updateTime { get; set; }
        public string ciqOriginCountry { get; set; }
        public string preDecCiqGoodsCont { get; set; }
        public string stdWeightUnitCode { get; set; }
        public string unit1 { get; set; }
        public string preDecCiqGoodsLimit { get; set; }
        public string ciqCurrName { get; set; }
        public string unit1Name { get; set; }
        public string gUnit { get; set; }
        public List<object> supList { get; set; }
        public string cusOriginCountryName { get; set; }
        public string createUser { get; set; }
        public string ciqWeight { get; set; }
        public string districtCode { get; set; }
        public string tradeCurr { get; set; }
        public string destinationCountry { get; set; }
        public string declTotal { get; set; }
        public string preDecCiqXiangHui { get; set; }
        public string codeTsName { get; set; }
        public string indbTime { get; set; }
        public string updateUser { get; set; }
        public string ciqDestCode { get; set; }
        public string ciqDomeOriginCodeName { get; set; }
        public string ciqDestCodeName { get; set; }
        public int? contrItem { get; set; }
        public string purpose { get; set; }
        public string packSpec { get; set; }
        public string packType { get; set; }

    }
    public class DecCiqXiangHui
    {

        public string preTradeAgreeCodeName { get; set; }
        public string preTradeAgreeCode { get; set; }
        public string oriCertType { get; set; }
        public string certOriCode { get; set; }
        public string rcepOrigPlaceDocCode { get; set; }
        public string rcepOrigPlaceDocCodeName { get; set; }
        public string certOriModItemNum { get; set; } 

    }
    /// <summary>
    /// 集装箱
    /// </summary>
    public class DecContainerVo
    {
        public string lclFlag { get; set; }

        public string cntnrModeCode { get; set; }
        public string contSeqNo { get; set; }
        public string updateTime { get; set; }
        public string cntnrModeCodeName { get; set; }
        public string goodsNo { get; set; }
        public string containerMdCodeName { get; set; }
        public string containerNo { get; set; }
        public string createUser { get; set; }
        public string cusCiqNo { get; set; }
        public string containerMdCode { get; set; }
        public string indbTime { get; set; }
        public string updateUser { get; set; }
        public string addList { get; set; }
        public string containerWt { get; set; }
    }
    /// <summary>
    /// 随附单据
    /// </summary>
    public class DecDocVo
    {
        public string updateTime { get; set; }
        public string attFmtTypeCode { get; set; }
        public string delList { get; set; }
        public string uploadOpTypeCode { get; set; }
        public string bizTypeCode { get; set; }
        public string signWkunitCode { get; set; }
        public string attTypeCode { get; set; }
        public string attEdocNo { get; set; }
        public string createUser { get; set; }
        public string signDate { get; set; }
        public string gNoStr { get; set; }
        public string attEdocStatus { get; set; }
        public string cusCiqNo { get; set; }
        public string attSeqNo { get; set; }
        public string indbTime { get; set; }
        public string attTypeCodeName { get; set; }
        public string updateUser { get; set; }
        public string addList { get; set; }
    }
    /// <summary>
    /// 其他包装
    /// </summary>
    public class DevOtherPacksVo
    {
        public string packTypeName { get; set; }
        public string packType { get; set; }
        public string packQty { get; set; }
        public string packSeqNo { get; set; }
    }
    /// <summary>
    /// 随附单证
    /// </summary>
    public class CusLicenseListVo
    {
        public object preDecCusEcoRel { get; set; }
        public string acmpFormCode { get; set; }
        public string acmpFormName { get; set; }
        public string acmpFormNo { get; set; }

    }
    /// <summary>
    /// 申请单证信息表
    /// </summary>
    public class DecRequCertList
    {
        /// <summary>
        /// 
        /// </summary>
        public string requCertSeqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string applOri { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string appCertName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string applCopyQuan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string appCertCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cusCiqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string indbTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateUser { get; set; }
    }
    /// <summary>
    /// 使用人信息表
    /// </summary>
    public class DecUserList
    {
        /// <summary>
        /// 
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string consumerUsrCode { get; set; }
        /// <summary>
        /// 山东海洋村食品有限公司
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string consumerUsrSeqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cusCiqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string useOrgPersonTel { get; set; }
        /// <summary>
        /// 赵梦绮
        /// </summary>
        public string useOrgPersonCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string indbTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateUser { get; set; }
    }
    /// <summary>
    /// 企业资质信息表
    /// </summary>
    public class DecEntQualifListVo
    {
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entQualifNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entQualifSeqNo { get; set; }
        /// <summary>
        /// 进口食品境外出口商代理商备案
        /// </summary>
        public string entQualifTypeCodeName { get; set; }
        /// <summary>
        /// 进口食品境外出口商代理商备案
        /// </summary>
        public string entQualifTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// 山东海洋村食品有限公司
        /// </summary>
        public string entName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bizType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entOrgCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cusCiqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string indbTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entQualifTypeCode { get; set; }
    }
    /// <summary>
    /// 许可证信息表
    /// </summary>
    public class DecCiqGoodsLimit
    {
        /// <summary>
        /// 
        /// </summary>
        public string gNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string goodsLimitSeqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licWrtofQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licWrtofUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tableFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licWrtofUnitName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licenceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// 兽医(卫生)证书
        /// </summary>
        public string licTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string preDecCiqGoodsLimitVinVo { get; set; }
        /// <summary>
        /// 兽医(卫生)证书
        /// </summary>
        public string licTypeCodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licWrtofDetailNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string measUnitCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cusCiqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string indbTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateUser { get; set; }
    }
    /// <summary>
    /// 许可证VIN信息
    /// </summary>
    public class DecCiqGoodsLimitVin
    {
        /// <summary>
        /// 
        /// </summary>
        public int goodsLimitVinSeqNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string licenceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vinNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string billLadDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qualityQgp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string motorNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string invoiceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string invoiceNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string prodCnnm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string prodEnnm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string modelEn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chassisNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pricePerUnit { get; set; }
    }
}