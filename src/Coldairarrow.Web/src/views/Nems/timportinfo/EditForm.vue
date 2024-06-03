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
        <a-form-model-item label="报文类型" prop="MESSAGE_TYPE">
          <a-input v-model="entity.MESSAGE_TYPE" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="导入操作类型" prop="OP_TYPE">
          <a-input v-model="entity.OP_TYPE" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="导入客户端统一编号" prop="HOST_ID">
          <a-input v-model="entity.HOST_ID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对应的附件关系的个数" prop="FILE_SIZE">
          <a-input v-model="entity.FILE_SIZE" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数字签名" prop="SIGN">
          <a-input v-model="entity.SIGN" autocomplete="off" />
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
        this.$http.post('/Nems/timportinfo/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Nems/timportinfo/SaveData', this.entity).then(resJson => {
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
