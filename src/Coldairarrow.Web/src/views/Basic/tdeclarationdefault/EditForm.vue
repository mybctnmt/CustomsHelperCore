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
        <a-form-model-item label="申报代码统一编码" prop="AgentCodeScc">
          <a-input v-model="entity.AgentCodeScc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报单位检验检疫编码" prop="DeclCiqCode">
          <a-input v-model="entity.DeclCiqCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出口标志" prop="IEFlag">
          <a-input v-model="entity.IEFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出境关别" prop="IEPort">
          <a-input v-model="entity.IEPort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="主管海关（申报地海关）" prop="CustomMaster">
          <a-input v-model="entity.CustomMaster" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单类型" prop="EntryType">
          <a-input v-model="entity.EntryType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征免性质" prop="CutMode">
          <a-input v-model="entity.CutMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="监管方式" prop="TradeMode">
          <a-input v-model="entity.TradeMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交方式" prop="TransMode">
          <a-input v-model="entity.TransMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包装种类" prop="WrapType">
          <a-input v-model="entity.WrapType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输方式代码" prop="TrafMode">
          <a-input v-model="entity.TrafMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征免方式" prop="DutyMode">
          <a-input v-model="entity.DutyMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产国" prop="OriginCountry">
          <a-input v-model="entity.OriginCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交币制" prop="TradeCurr">
          <a-input v-model="entity.TradeCurr" autocomplete="off" />
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
        this.$http.post('/Basic/tdeclarationdefault/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tdeclarationdefault/SaveData', this.entity).then(resJson => {
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
