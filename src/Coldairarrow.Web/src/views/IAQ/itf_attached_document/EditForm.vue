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
        <a-form-model-item label="MessageType" prop="MessageType">
          <a-input v-model="entity.MessageType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="UuId" prop="UuId">
          <a-input v-model="entity.UuId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="FileName" prop="FileName">
          <a-input v-model="entity.FileName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="FormatType" prop="FormatType">
          <a-input v-model="entity.FormatType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ZipName" prop="ZipName">
          <a-input v-model="entity.ZipName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CopFileName" prop="CopFileName">
          <a-input v-model="entity.CopFileName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="DealType" prop="DealType">
          <a-input v-model="entity.DealType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="SendTime" prop="SendTime">
          <a-input v-model="entity.SendTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="FileSource" prop="FileSource">
          <a-input v-model="entity.FileSource" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="OpNote" prop="OpNote">
          <a-input v-model="entity.OpNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="File" prop="File">
          <a-input v-model="entity.File" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_attached_document/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_attached_document/SaveData', this.entity).then(resJson => {
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
