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
        <a-form-model-item label="邮件订单列表显示天数" prop="EmailListDataShowDays">
          <a-input v-model="entity.EmailListDataShowDays" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单列表显示天数" prop="CusListDataShowDays">
          <a-input v-model="entity.CusListDataShowDays" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报文生成Ip" prop="EDIIp">
          <a-input v-model="entity.EDIIp" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报文生成端口" prop="EDIPort">
          <a-input v-model="entity.EDIPort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="文件保存路径" prop="FileSavePath">
          <a-input v-model="entity.FileSavePath" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否弹窗" prop="IsPopUpReminder">
          <a-input v-model="entity.IsPopUpReminder" autocomplete="off" />
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
        this.$http.post('/Basic/tsettingconfig/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tsettingconfig/SaveData', this.entity).then(resJson => {
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
