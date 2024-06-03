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
        <a-form-model-item label="单据类型" prop="CertType">
          <a-input v-model="entity.CertType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单商品项号" prop="DecGNo">
          <a-input v-model="entity.DecGNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="单据证书号" prop="EcoCertNo">
          <a-input v-model="entity.EcoCertNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地证书单证项号" prop="EcoGNo">
          <a-input v-model="entity.EcoGNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="扩展字段" prop="ExtendFiled">
          <a-input v-model="entity.ExtendFiled" autocomplete="off" />
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
        this.$http.post('/Dec/tecorelation/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tecorelation/SaveData', this.entity).then(resJson => {
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
