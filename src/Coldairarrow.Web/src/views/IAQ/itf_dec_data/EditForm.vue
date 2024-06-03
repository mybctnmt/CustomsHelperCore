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
        <a-form-model-item label="MasterCustomsCode" prop="MasterCustomsCode">
          <a-input v-model="entity.MasterCustomsCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="PreEntryId" prop="PreEntryId">
          <a-input v-model="entity.PreEntryId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="SpDecSeqNo" prop="SpDecSeqNo">
          <a-input v-model="entity.SpDecSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="TradeCode" prop="TradeCode">
          <a-input v-model="entity.TradeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="DealCode" prop="DealCode">
          <a-input v-model="entity.DealCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="DealName" prop="DealName">
          <a-input v-model="entity.DealName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="FileType" prop="FileType">
          <a-input v-model="entity.FileType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_dec_data/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dec_data/SaveData', this.entity).then(resJson => {
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
