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
        <a-form-model-item label="预录入统一编号" prop="SeqNo">
          <a-input v-model="entity.SeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="业务类型" prop="BusiType">
          <a-input v-model="entity.BusiType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="变更次数" prop="ChgTmsCnt">
          <a-input v-model="entity.ChgTmsCnt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经营单位海关编码" prop="BizopEtpsNo">
          <a-input v-model="entity.BizopEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经营单位社会信用代码" prop="BizopEtpsSccd">
          <a-input v-model="entity.BizopEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工单位海关编码" prop="OwnerEtpsNo">
          <a-input v-model="entity.OwnerEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工单位社会信用代码" prop="OwnerEtpsSccd">
          <a-input v-model="entity.OwnerEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加签卡号" prop="IcCode">
          <a-input v-model="entity.IcCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卡用户海关编码" prop="IcEtpsNo">
          <a-input v-model="entity.IcEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卡用户社会信用代码" prop="IcEtpsSccd">
          <a-input v-model="entity.IcEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名信息" prop="SignInfo">
          <a-input v-model="entity.SignInfo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名日期" prop="SignDate">
          <a-input v-model="entity.SignDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加签证书编号" prop="CertNo">
          <a-input v-model="entity.CertNo" autocomplete="off" />
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
        this.$http.post('/Nems/tinvtsign/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Nems/tinvtsign/SaveData', this.entity).then(resJson => {
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
