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
        <a-form-model-item label="导入文件名" prop="FILE_NAME">
          <a-input v-model="entity.FILE_NAME" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="单一窗口业务唯一标识

" prop="FILE_TYPE">
          <a-input v-model="entity.FILE_TYPE" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="回执发送时间

" prop="OP_TIME">
          <a-input v-model="entity.OP_TIME" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="响应结果" prop="PROC_RESULT">
          <a-input v-model="entity.PROC_RESULT" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="相应描述" prop="PROC_DESC">
          <a-input v-model="entity.PROC_DESC" autocomplete="off" />
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
        this.$http.post('/IAQ/usf102/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/usf102/SaveData', this.entity).then(resJson => {
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
