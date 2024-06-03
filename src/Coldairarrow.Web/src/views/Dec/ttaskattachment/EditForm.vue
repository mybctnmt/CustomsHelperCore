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
        <a-form-model-item label="任务Id" prop="TaskId">
          <a-input v-model="entity.TaskId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="附件名称" prop="AttachmentName">
          <a-input v-model="entity.AttachmentName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="附件地址" prop="AttachmentUrl">
          <a-input v-model="entity.AttachmentUrl" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="附件大小" prop="AttachmentSize">
          <a-input v-model="entity.AttachmentSize" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="附件类型" prop="AttachmentType">
          <a-input v-model="entity.AttachmentType" autocomplete="off" />
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
        this.$http.post('/Dec/ttaskattachment/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/ttaskattachment/SaveData', this.entity).then(resJson => {
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
