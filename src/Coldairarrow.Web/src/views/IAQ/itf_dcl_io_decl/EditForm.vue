<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
  <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="关检关联号" prop="CusCiqNo">
          <a-input v-model="entity.CusCiqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提/运单号" prop="BillNo">
          <a-input v-model="entity.BillNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="目的地代码" prop="CiqDestCode">
          <a-input v-model="entity.CiqDestCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输方式代码" prop="CiqTrafMode">
          <a-input v-model="entity.CiqTrafMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输工具名称" prop="TrafName">
          <a-input v-model="entity.TrafName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输工具号码" prop="CusVoyageNo">
          <a-input v-model="entity.CusVoyageNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="贸易国别代码" prop="CiqTradeCountryCode">
          <a-input v-model="entity.CiqTradeCountryCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="启运国家代码" prop="CiqDespCtryCode">
          <a-input v-model="entity.CiqDespCtryCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="入境口岸代码" prop="CiqEntyPortCode">
          <a-input v-model="entity.CiqEntyPortCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同号" prop="ContractNo">
          <a-input v-model="entity.ContractNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业UUID" prop="EntUuid">
          <a-input v-model="entity.EntUuid" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发货人代码" prop="ConsignorCode">
          <a-input v-model="entity.ConsignorCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发货人名称（中文）" prop="ConsignorCname">
          <a-input v-model="entity.ConsignorCname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发货人名称（外文）" prop="ConsignorEname">
          <a-input v-model="entity.ConsignorEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发货人地址" prop="ConsignorAddr">
          <a-input v-model="entity.ConsignorAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货人代码" prop="ConsigneeCode">
          <a-input v-model="entity.ConsigneeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货人名称（中文）" prop="ConsigneeCname">
          <a-input v-model="entity.ConsigneeCname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货人名称（外文）" prop="ConsigneeEname">
          <a-input v-model="entity.ConsigneeEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货人地址" prop="ConsigneeAddr">
          <a-input v-model="entity.ConsigneeAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="贸易方式代码" prop="TradeModeCode">
          <a-input v-model="entity.TradeModeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="标记及号码" prop="MarkNo">
          <a-input v-model="entity.MarkNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="启运口岸代码" prop="DespPortCode">
          <a-input v-model="entity.DespPortCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经停口岸代码" prop="PortStopCode">
          <a-input v-model="entity.PortStopCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="存放地点" prop="GoodsPlace">
          <a-input v-model="entity.GoodsPlace" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="索赔截止日期" prop="CounterClaim">
          <a-input v-model="entity.CounterClaim" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提货单号" prop="DeliveryOrder">
          <a-input v-model="entity.DeliveryOrder" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="口岸机构" prop="InspOrgCode">
          <a-input v-model="entity.InspOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="施检地代码" prop="InspPlaceCode">
          <a-input v-model="entity.InspPlaceCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特种业务标识, 1表示勾选. 进出境都是传递4位（0或者1组成），第一位：国际赛事，第二位：特殊进出军工物资，第三位：国际援助物资，第四位：国际会议" prop="SpecDeclFlag">
          <a-input v-model="entity.SpecDeclFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="目的机构代码" prop="PurpOrgCode">
          <a-input v-model="entity.PurpOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请员证号" prop="DeclPersnCertNo">
          <a-input v-model="entity.DeclPersnCertNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请员姓名" prop="DeclPersonName">
          <a-input v-model="entity.DeclPersonName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请单位联系人" prop="Contactperson">
          <a-input v-model="entity.Contactperson" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请联系人电话" prop="ContTel">
          <a-input v-model="entity.ContTel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请类别代码" prop="DeclCode">
          <a-input v-model="entity.DeclCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请申报日期" prop="DeclDate">
          <a-input v-model="entity.DeclDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="到货日期" prop="GdsArvlDate">
          <a-input v-model="entity.GdsArvlDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特殊通关模式, 1表示勾选. 入境：直通放行 外交礼遇 转关（需要传递4位字符串，第一位：直通放行，第二位：0，第三位：外交礼遇，第四位：转关） 出境：直通放行 绿色通道 外交礼遇（需要传递3位字符串，第一位：直通放行，第二位：绿色通道，第三位：外交礼遇）" prop="SpecPassFlag">
          <a-input v-model="entity.SpecPassFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="入境：启运日期 出境：发货日期" prop="DespDate">
          <a-input v-model="entity.DespDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据名称串" prop="AttaCollectName">
          <a-input v-model="entity.AttaCollectName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物总值（美元） 申报货物为“0001”或“0002”品目的木质包装或集装箱除外的其他所有货物。" prop="TotalValUsD">
          <a-input v-model="entity.TotalValUsD" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物总值（人民币） 申报货物为“0001”或“0002”品目的木质包装或集装箱除外的其他所有货物。" prop="TotalValCn">
          <a-input v-model="entity.TotalValCn" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="集装箱适载核销状态" prop="ContCancelFlag">
          <a-input v-model="entity.ContCancelFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申请单证名称" prop="AppCertName">
          <a-input v-model="entity.AppCertName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请单位代码" prop="DeclRegNo">
          <a-input v-model="entity.DeclRegNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请单位名称" prop="DeclRegName">
          <a-input v-model="entity.DeclRegName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卸毕日期" prop="CmplDschrgDt">
          <a-input v-model="entity.CmplDschrgDt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联检验检疫申请号" prop="CorrelationDeclNo">
          <a-input v-model="entity.CorrelationDeclNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联理由" prop="CorrelationReasonFlag">
          <a-input v-model="entity.CorrelationReasonFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特殊检验检疫要求" prop="SpeclInspQuraRe">
          <a-input v-model="entity.SpeclInspQuraRe" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="到达口岸代码" prop="ArrivPortCode">
          <a-input v-model="entity.ArrivPortCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="分运单号" prop="SplitBillLadNo">
          <a-input v-model="entity.SplitBillLadNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫申请地" prop="OrgCode">
          <a-input v-model="entity.OrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="领证地" prop="VsaOrgCode">
          <a-input v-model="entity.VsaOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="入境原集装箱装载直接到目的机构，【1：是；0：否】" prop="OrigBoxFlag">
          <a-input v-model="entity.OrigBoxFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="入出境标识（检验检疫）I:进境，E：出境" prop="CiqIEFlag">
          <a-input v-model="entity.CiqIEFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业内部编号" prop="CopNo">
          <a-input v-model="entity.CopNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关海关" prop="CustomMaster">
          <a-input v-model="entity.CustomMaster" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="海关注册号" prop="CustmRegNo">
          <a-input v-model="entity.CustmRegNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否勾选企业承诺; 如勾选需要企业资质中增加证明或声明材料。 0：未勾选；1：勾选。" prop="IsCopPromise">
          <a-input v-model="entity.IsCopPromise" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="属地查检标识：5-属地查检" prop="DeclareFlag">
          <a-input v-model="entity.DeclareFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
        </a-form-model-item>
        
      </a-form-model>
    </a-spin>
  </a-form-model>
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
        this.$http.post('/IAQ/itf_dcl_io_decl/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dcl_io_decl/SaveData', this.entity).then(resJson => {
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
