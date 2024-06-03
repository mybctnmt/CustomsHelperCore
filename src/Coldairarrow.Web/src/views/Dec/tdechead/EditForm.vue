<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="申报单位代码" prop="AgentCode">
          <a-input v-model="entity.AgentCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报单位名称" prop="AgentName">
          <a-input v-model="entity.AgentName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="批准文号" prop="ApprNo">
          <a-input v-model="entity.ApprNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提单号" prop="BillNo">
          <a-input v-model="entity.BillNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同号" prop="ContrNo">
          <a-input v-model="entity.ContrNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入单位代码" prop="CopCode">
          <a-input v-model="entity.CopCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入单位名称" prop="CopName">
          <a-input v-model="entity.CopName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="主管海关（申报地海关）" prop="CustomMaster">
          <a-input v-model="entity.CustomMaster" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征免性质" prop="CutMode">
          <a-input v-model="entity.CutMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="扩展字段" prop="DataSource">
          <a-input v-model="entity.DataSource" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关/转关关系标志" prop="DeclTrnRel">
          <a-input v-model="entity.DeclTrnRel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经停港/指运港" prop="DistinatePort">
          <a-input v-model="entity.DistinatePort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关标志" prop="EdiId">
          <a-input v-model="entity.EdiId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="海关编号" prop="EntryId">
          <a-input v-model="entity.EntryId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单类型" prop="EntryType">
          <a-input v-model="entity.EntryType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运费币制" prop="FeeCurr">
          <a-input v-model="entity.FeeCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运费标记" prop="FeeMark">
          <a-input v-model="entity.FeeMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运费／率" prop="FeeRate">
          <a-input v-model="entity.FeeRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="毛重" prop="GrossWet">
          <a-input v-model="entity.GrossWet" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出口日期" prop="IEDate">
          <a-input v-model="entity.IEDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出口标志" prop="IEFlag">
          <a-input v-model="entity.IEFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出境关别" prop="IEPort">
          <a-input v-model="entity.IEPort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入员名称" prop="InputerName">
          <a-input v-model="entity.InputerName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="保险费币制" prop="InsurCurr">
          <a-input v-model="entity.InsurCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="保险费标记" prop="InsurMark">
          <a-input v-model="entity.InsurMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="保险费／率" prop="InsurRate">
          <a-input v-model="entity.InsurRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="许可证编号" prop="LicenseNo">
          <a-input v-model="entity.LicenseNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备案号" prop="ManualNo">
          <a-input v-model="entity.ManualNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="净重" prop="NetWt">
          <a-input v-model="entity.NetWt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="NoteS">
          <a-input v-model="entity.NoteS" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="杂费币制" prop="OtherCurr">
          <a-input v-model="entity.OtherCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="杂费标志" prop="OtherMark">
          <a-input v-model="entity.OtherMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="杂费／率" prop="OtherRate">
          <a-input v-model="entity.OtherRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费使用/生产销售单位代码" prop="OwnerCode">
          <a-input v-model="entity.OwnerCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费使用/生产销售单位名称" prop="OwnerName">
          <a-input v-model="entity.OwnerName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="件数" prop="PackNo">
          <a-input v-model="entity.PackNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人标识" prop="PartenerID">
          <a-input v-model="entity.PartenerID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="打印日期" prop="PDate">
          <a-input v-model="entity.PDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="预录入编号" prop="PreEntryId">
          <a-input v-model="entity.PreEntryId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="风险评估参数" prop="Risk">
          <a-input v-model="entity.Risk" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数据中心统一编号" prop="SeqNo">
          <a-input v-model="entity.SeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联单据号" prop="TgdNo">
          <a-input v-model="entity.TgdNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="启运国/运抵国" prop="TradeCountry">
          <a-input v-model="entity.TradeCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="监管方式" prop="TradeMode">
          <a-input v-model="entity.TradeMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人编号" prop="TradeCode">
          <a-input v-model="entity.TradeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输方式代码" prop="TrafMode">
          <a-input v-model="entity.TrafMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输工具代码及名称" prop="TrafName">
          <a-input v-model="entity.TrafName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人名称" prop="TradeName">
          <a-input v-model="entity.TradeName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交方式" prop="TransMode">
          <a-input v-model="entity.TransMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="单据类型" prop="Type">
          <a-input v-model="entity.Type" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入员IC卡号" prop="TypistNo">
          <a-input v-model="entity.TypistNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包装种类" prop="WrapType">
          <a-input v-model="entity.WrapType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="担保验放标志" prop="ChkSurety">
          <a-input v-model="entity.ChkSurety" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备案清单类型" prop="BillType">
          <a-input v-model="entity.BillType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入单位统一编码" prop="CopCodeScc">
          <a-input v-model="entity.CopCodeScc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收发货人统一编码" prop="TradeCoScc">
          <a-input v-model="entity.TradeCoScc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报代码统一编码" prop="AgentCodeScc">
          <a-input v-model="entity.AgentCodeScc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费使用/生产销售单位单位统一编码" prop="OwnerCodeScc">
          <a-input v-model="entity.OwnerCodeScc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格说明" prop="PromiseItmes">
          <a-input v-model="entity.PromiseItmes" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="贸易国别" prop="TradeAreaCode">
          <a-input v-model="entity.TradeAreaCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="查验分流" prop="CheckFlow">
          <a-input v-model="entity.CheckFlow" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="税收征管标记" prop="TaxAaminMark">
          <a-input v-model="entity.TaxAaminMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="标记唛码" prop="MarkNo">
          <a-input v-model="entity.MarkNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="启运港代码" prop="DespPortCode">
          <a-input v-model="entity.DespPortCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="入境口岸代码" prop="EntyPortCode">
          <a-input v-model="entity.EntyPortCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="存放地点" prop="GoodsPlace">
          <a-input v-model="entity.GoodsPlace" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="B/L号" prop="BLNo">
          <a-input v-model="entity.BLNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="口岸检验检疫机关" prop="InspOrgCode">
          <a-input v-model="entity.InspOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特种业务标识" prop="SpecDeclFlag">
          <a-input v-model="entity.SpecDeclFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="目的地检验检疫机关" prop="PurpOrgCode">
          <a-input v-model="entity.PurpOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="启运日期" prop="DespDate">
          <a-input v-model="entity.DespDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卸毕日期" prop="CmplDschrgDt">
          <a-input v-model="entity.CmplDschrgDt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联理由" prop="CorrelationReasonFlag">
          <a-input v-model="entity.CorrelationReasonFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="领证机关" prop="VsaOrgCode">
          <a-input v-model="entity.VsaOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原集装箱标识" prop="OrigBoxFlag">
          <a-input v-model="entity.OrigBoxFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人员姓名" prop="DeclareName">
          <a-input v-model="entity.DeclareName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="无其他包装" prop="NoOtherPack">
          <a-input v-model="entity.NoOtherPack" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫受理机关" prop="OrgCode">
          <a-input v-model="entity.OrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外发货人代码" prop="OverseasConsignorCode">
          <a-input v-model="entity.OverseasConsignorCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外收发货人名称" prop="OverseasConsignorCname">
          <a-input v-model="entity.OverseasConsignorCname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外发货人名称（外文）" prop="OverseasConsignorEname">
          <a-input v-model="entity.OverseasConsignorEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外收发货人地址" prop="OverseasConsignorAddr">
          <a-input v-model="entity.OverseasConsignorAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外收货人编码" prop="OverseasConsigneeCode">
          <a-input v-model="entity.OverseasConsigneeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外收货人名称(外文)" prop="OverseasConsigneeEname">
          <a-input v-model="entity.OverseasConsigneeEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人名称（外文）" prop="DomesticConsigneeEname">
          <a-input v-model="entity.DomesticConsigneeEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联号码" prop="CorrelationNo">
          <a-input v-model="entity.CorrelationNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="EDI申报备注" prop="EdiRemark">
          <a-input v-model="entity.EdiRemark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="EDI申报备注2" prop="EdiRemark2">
          <a-input v-model="entity.EdiRemark2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人检验检疫编码" prop="TradeCiqCode">
          <a-input v-model="entity.TradeCiqCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费使用/生产销售单位检验检疫编码" prop="OwnerCiqCode">
          <a-input v-model="entity.OwnerCiqCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报单位检验检疫编码" prop="DeclCiqCode">
          <a-input v-model="entity.DeclCiqCode" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/Dec/tdechead/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/Dec/tdechead/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
