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
        <a-form-model-item label="审核人Id" prop="ReviewerId">
          <a-input v-model="entity.ReviewerId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="审核人" prop="ReviewerName">
          <a-input v-model="entity.ReviewerName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="更新内容" prop="UpdateContent">
          <a-input v-model="entity.UpdateContent" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="审核时间" prop="ReviewerTime">
          <a-input v-model="entity.ReviewerTime" autocomplete="off" />
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
        this.$http.post('/Dec/tdecreview/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdecreview/SaveData', this.entity).then(resJson => {
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
