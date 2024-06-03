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
        <a-form-model-item label="转关单统一编号" prop="TrnPreId">
          <a-input v-model="entity.TrnPreId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="载货清单号" prop="TransNo">
          <a-input v-model="entity.TransNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="转关申报单号" prop="TurnNo">
          <a-input v-model="entity.TurnNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内运输方式" prop="NativeTrafMode">
          <a-input v-model="entity.NativeTrafMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内运输工具编号" prop="TrafCustomsNo">
          <a-input v-model="entity.TrafCustomsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内运输工具名称" prop="NativeShipName">
          <a-input v-model="entity.NativeShipName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内运输工具航次" prop="NativeVoyageNo">
          <a-input v-model="entity.NativeVoyageNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="承运单位名称" prop="ContractorName">
          <a-input v-model="entity.ContractorName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="承运单位组织机构代码" prop="ContractorCode">
          <a-input v-model="entity.ContractorCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="转关类型" prop="TransFlag">
          <a-input v-model="entity.TransFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="预计运抵指运地时间" prop="ValidTime">
          <a-input v-model="entity.ValidTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否启用电子关锁标志" prop="ESealFlag">
          <a-input v-model="entity.ESealFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Notes">
          <a-input v-model="entity.Notes" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="转关单类型" prop="TrnType">
          <a-input v-model="entity.TrnType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="转关申报单位统一代码" prop="ApplCodeScc">
          <a-input v-model="entity.ApplCodeScc" autocomplete="off" />
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
        this.$http.post('/Dec/ttrnhead/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/ttrnhead/SaveData', this.entity).then(resJson => {
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
