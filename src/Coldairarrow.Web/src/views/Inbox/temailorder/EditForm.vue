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
        <a-form-model-item label="订单编号" prop="OrderNo">
          <a-input v-model="entity.OrderNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收件箱Id" prop="InboxId">
          <a-input v-model="entity.InboxId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客户Id" prop="CustomerId">
          <a-input v-model="entity.CustomerId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客户简称" prop="CustomerShortName">
          <a-input v-model="entity.CustomerShortName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员Id" prop="OperatorId">
          <a-input v-model="entity.OperatorId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员名称" prop="OperatorName">
          <a-input v-model="entity.OperatorName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮件主题" prop="Subject">
          <a-input v-model="entity.Subject" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发送时间" prop="SendTime">
          <a-input v-model="entity.SendTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客服Id" prop="CustomerServiceId">
          <a-input v-model="entity.CustomerServiceId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客服名称" prop="CustomerServiceName">
          <a-input v-model="entity.CustomerServiceName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="分票" prop="Ticket">
          <a-input v-model="entity.Ticket" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="受理人Id" prop="HandlerId">
          <a-input v-model="entity.HandlerId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="受理人名称" prop="HandlerName">
          <a-input v-model="entity.HandlerName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录单人Id" prop="EntryClerkId">
          <a-input v-model="entity.EntryClerkId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录单人名称" prop="EntryClerkName">
          <a-input v-model="entity.EntryClerkName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="修订次数" prop="RevisionNo">
          <a-input v-model="entity.RevisionNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="审单人Id" prop="VerifierId">
          <a-input v-model="entity.VerifierId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="审单人名称" prop="VerifierName">
          <a-input v-model="entity.VerifierName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="复核人Id" prop="ReviewerId">
          <a-input v-model="entity.ReviewerId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="复核人名称" prop="ReviewerName">
          <a-input v-model="entity.ReviewerName" autocomplete="off" />
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
        this.$http.post('/Inbox/temailorder/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Inbox/temailorder/SaveData', this.entity).then(resJson => {
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
