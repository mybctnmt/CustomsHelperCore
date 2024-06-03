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
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="AppCertCode" prop="AppCertCode">
          <a-input v-model="entity.AppCertCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="AppCertName" prop="AppCertName">
          <a-input v-model="entity.AppCertName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ApplCopyQuan" prop="ApplCopyQuan">
          <a-input v-model="entity.ApplCopyQuan" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ApplOri" prop="ApplOri">
          <a-input v-model="entity.ApplOri" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CreateUser" prop="CreateUser">
          <a-input v-model="entity.CreateUser" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CusCiqNo" prop="CusCiqNo">
          <a-input v-model="entity.CusCiqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="IndbTime" prop="IndbTime">
          <a-input v-model="entity.IndbTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="RequCertSeqNo" prop="RequCertSeqNo">
          <a-input v-model="entity.RequCertSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="State" prop="State">
          <a-input v-model="entity.State" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="TableFlag" prop="TableFlag">
          <a-input v-model="entity.TableFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="UpdateTime" prop="UpdateTime">
          <a-input v-model="entity.UpdateTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="UpdateUser" prop="UpdateUser">
          <a-input v-model="entity.UpdateUser" autocomplete="off" />
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
        this.$http.post('/IAQ/required_doc/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/required_doc/SaveData', this.entity).then(resJson => {
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
