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
        <a-form-model-item label="价格预裁定编号" prop="PricePreDeterminNo">
          <a-input v-model="entity.PricePreDeterminNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="应税特许权使用费申报情形" prop="TaxRoyaltyDeclType">
          <a-input v-model="entity.TaxRoyaltyDeclType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同/协议号" prop="ContractNo">
          <a-input v-model="entity.ContractNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="授权方" prop="Authorizer">
          <a-input v-model="entity.Authorizer" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="被授权方" prop="AuthorizedPerson">
          <a-input v-model="entity.AuthorizedPerson" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="支付方式" prop="PayType">
          <a-input v-model="entity.PayType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="支付时间" prop="PayTime">
          <a-input v-model="entity.PayTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="支付计提周期" prop="PayPeriod">
          <a-input v-model="entity.PayPeriod" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同/协议起始执行时间" prop="EffectiveDateTime">
          <a-input v-model="entity.EffectiveDateTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同协议终止时间" prop="ExpirationDateTime">
          <a-input v-model="entity.ExpirationDateTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特许权使用费金额" prop="RoyaltyAmount">
          <a-input v-model="entity.RoyaltyAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="币制" prop="Curr">
          <a-input v-model="entity.Curr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特许权使用费类型" prop="RoyaltyFeeType">
          <a-input v-model="entity.RoyaltyFeeType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附材料清单类型" prop="EdocType">
          <a-input v-model="entity.EdocType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="说明" prop="Statment">
          <a-input v-model="entity.Statment" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否保密" prop="IsSecret">
          <a-input v-model="entity.IsSecret" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否经过海关审核认定" prop="IsCusAudit">
          <a-input v-model="entity.IsCusAudit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否经过海关价格预裁定" prop="IsCusPricePreDetermin">
          <a-input v-model="entity.IsCusPricePreDetermin" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同/协议签约时间" prop="IssueDateTime">
          <a-input v-model="entity.IssueDateTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="本次支付对应的计提周期起始时间" prop="PeriodStartDate">
          <a-input v-model="entity.PeriodStartDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="本次支付对应的计提周期终止时间" prop="PeriodEndDate">
          <a-input v-model="entity.PeriodEndDate" autocomplete="off" />
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
        this.$http.post('/Dec/tdecroyaltyfee/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdecroyaltyfee/SaveData', this.entity).then(resJson => {
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
