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
        <a-form-model-item label="集装箱号" prop="ContaNo">
          <a-input v-model="entity.ContaNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="集装箱序号" prop="ContaSn">
          <a-input v-model="entity.ContaSn" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="集装箱规格" prop="ContaModel">
          <a-input v-model="entity.ContaModel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="电子关锁号" prop="SealNo">
          <a-input v-model="entity.SealNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内运输工具名称" prop="TransName">
          <a-input v-model="entity.TransName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="工具实际重量（海关精度z(14).z(5)）" prop="TransWeight">
          <a-input v-model="entity.TransWeight" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关锁个数" prop="SealQty">
          <a-input v-model="entity.SealQty" autocomplete="off" />
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
        this.$http.post('/Dec/ttrncontainer/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/ttrncontainer/SaveData', this.entity).then(resJson => {
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
