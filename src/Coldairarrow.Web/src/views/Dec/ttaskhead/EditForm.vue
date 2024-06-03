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
        <a-form-model-item label="任务名称" prop="TaskName">
          <a-input v-model="entity.TaskName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="任务内容" prop="TaskContent">
          <a-input v-model="entity.TaskContent" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否加急" prop="IsUrgent">
          <a-input v-model="entity.IsUrgent" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员Id" prop="OperatorId">
          <a-input v-model="entity.OperatorId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员名称" prop="OperatorName">
          <a-input v-model="entity.OperatorName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作时间" prop="OperateTime">
          <a-input v-model="entity.OperateTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="接单人Id" prop="ReceiverId">
          <a-input v-model="entity.ReceiverId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="接单人名称" prop="ReceiverName">
          <a-input v-model="entity.ReceiverName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="接单时间" prop="ReceiveTime">
          <a-input v-model="entity.ReceiveTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否已完成" prop="IsCompleted">
          <a-input v-model="entity.IsCompleted" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提单号" prop="BillNo">
          <a-input v-model="entity.BillNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="订单编号-非申报字段" prop="OrderNo">
          <a-input v-model="entity.OrderNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输工具代码及名称" prop="TrafName">
          <a-input v-model="entity.TrafName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="航次号" prop="CusVoyageNo">
          <a-input v-model="entity.CusVoyageNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="启运国/运抵国" prop="TradeCountry">
          <a-input v-model="entity.TradeCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品编号" prop="CodeTS">
          <a-input v-model="entity.CodeTS" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品名称" prop="GName">
          <a-input v-model="entity.GName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费使用/生产销售单位代码" prop="OwnerCode">
          <a-input v-model="entity.OwnerCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费使用/生产销售单位名称" prop="OwnerName">
          <a-input v-model="entity.OwnerName" autocomplete="off" />
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
        this.$http.post('/Dec/ttaskhead/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/ttaskhead/SaveData', this.entity).then(resJson => {
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
