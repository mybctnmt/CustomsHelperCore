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
        <a-form-model-item label="发件人名称" prop="SenderName">
          <a-input v-model="entity.SenderName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发件人账号" prop="SenderEmailAddress">
          <a-input v-model="entity.SenderEmailAddress" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发送时间" prop="SendTime">
          <a-input v-model="entity.SendTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收件人" prop="Recipient">
          <a-input v-model="entity.Recipient" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件主题" prop="Subject">
          <a-input v-model="entity.Subject" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件内容Html" prop="HtmlContent">
          <a-input v-model="entity.HtmlContent" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件内容文本" prop="TextContent">
          <a-input v-model="entity.TextContent" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件大小" prop="Size">
          <a-input v-model="entity.Size" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件Id" prop="EmailId">
          <a-input v-model="entity.EmailId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件类型" prop="EmailType">
          <a-input v-model="entity.EmailType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作状态" prop="OperationStatus">
          <a-input v-model="entity.OperationStatus" autocomplete="off" />
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
        this.$http.post('/Inbox/tinboxcontent/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Inbox/tinboxcontent/SaveData', this.entity).then(resJson => {
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
