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
        <a-form-model-item label="费用类别" prop="CostCategory">
          <a-input v-model="entity.CostCategory" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="费用名称" prop="CostName">
          <a-input v-model="entity.CostName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="费用金额" prop="CostAmount">
          <a-input v-model="entity.CostAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="费用类型" prop="CostType">
          <a-input v-model="entity.CostType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="订单编号" prop="OrderNo">
          <a-input v-model="entity.OrderNo" autocomplete="off" />
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
        this.$http.post('/Fieldwork/ttaskcost/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Fieldwork/ttaskcost/SaveData', this.entity).then(resJson => {
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
