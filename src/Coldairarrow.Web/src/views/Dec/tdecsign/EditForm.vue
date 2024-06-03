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
        <a-form-model-item label="操作类型" prop="OperType">
          <a-input v-model="entity.OperType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员IC卡号" prop="ICCode">
          <a-input v-model="entity.ICCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员姓名" prop="OperName">
          <a-input v-model="entity.OperName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作企业组织机构代码" prop="CopCode">
          <a-input v-model="entity.CopCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客户端报关单编号" prop="ClientSeqNo">
          <a-input v-model="entity.ClientSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数字签名信息" prop="Sign">
          <a-input v-model="entity.Sign" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名日期" prop="SignDate">
          <a-input v-model="entity.SignDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客户端邮箱的HostId" prop="HostId">
          <a-input v-model="entity.HostId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作员卡的证书号" prop="Certificate">
          <a-input v-model="entity.Certificate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名人分类" prop="DomainId">
          <a-input v-model="entity.DomainId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Note">
          <a-input v-model="entity.Note" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对应清单统一编号" prop="BillSeqNo">
          <a-input v-model="entity.BillSeqNo" autocomplete="off" />
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
        this.$http.post('/Dec/tdecsign/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdecsign/SaveData', this.entity).then(resJson => {
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
