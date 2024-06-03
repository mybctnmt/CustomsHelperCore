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
        <a-form-model-item label="监管仓号" prop="BonNo">
          <a-input v-model="entity.BonNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货场代码" prop="CusFie">
          <a-input v-model="entity.CusFie" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关员联系方式" prop="DecBpNo">
          <a-input v-model="entity.DecBpNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人员证号" prop="DecNo">
          <a-input v-model="entity.DecNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单号" prop="RelId">
          <a-input v-model="entity.RelId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联备案号" prop="RelManNo">
          <a-input v-model="entity.RelManNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="航次号" prop="VoyNo">
          <a-input v-model="entity.VoyNo" autocomplete="off" />
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
        this.$http.post('/Dec/tdecfreetxt/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdecfreetxt/SaveData', this.entity).then(resJson => {
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
