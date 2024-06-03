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
        <a-form-model-item label="集装箱号" prop="ContainerId">
          <a-input v-model="entity.ContainerId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="集装箱规格" prop="ContainerMd">
          <a-input v-model="entity.ContainerMd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品项号用半角逗号分隔，如"1,3"" prop="GoodsNo">
          <a-input v-model="entity.GoodsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="拼箱标识，0-否1-是" prop="LclFlag">
          <a-input v-model="entity.LclFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="箱货重量" prop="GoodsContaWt">
          <a-input v-model="entity.GoodsContaWt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="自重" prop="ContainerWt">
          <a-input v-model="entity.ContainerWt" autocomplete="off" />
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
        this.$http.post('/Dec/tdeccontainer/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdeccontainer/SaveData', this.entity).then(resJson => {
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
