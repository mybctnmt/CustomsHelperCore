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
        <a-form-model-item label="客户全称" prop="CustomerName">
          <a-input v-model="entity.CustomerName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客户简称" prop="CustomerShortName">
          <a-input v-model="entity.CustomerShortName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客户代码" prop="CustomerCode">
          <a-input v-model="entity.CustomerCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="外贸" prop="ForeignTrade">
          <a-input v-model="entity.ForeignTrade" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货代" prop="FreightForwarder">
          <a-input v-model="entity.FreightForwarder" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="委托单位" prop="EntrustUnit">
          <a-input v-model="entity.EntrustUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经营单位" prop="BusinessUnit">
          <a-input v-model="entity.BusinessUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发货人" prop="Consignor">
          <a-input v-model="entity.Consignor" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货人" prop="Consignee">
          <a-input v-model="entity.Consignee" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="通知人" prop="Notifier">
          <a-input v-model="entity.Notifier" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="船公司" prop="ShippingCompany">
          <a-input v-model="entity.ShippingCompany" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关行" prop="CustomsBroker">
          <a-input v-model="entity.CustomsBroker" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="场站" prop="Station">
          <a-input v-model="entity.Station" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="航空公司" prop="Airline">
          <a-input v-model="entity.Airline" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="快递公司" prop="ExpressCompany">
          <a-input v-model="entity.ExpressCompany" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="车队" prop="Motorcade">
          <a-input v-model="entity.Motorcade" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="其他" prop="Other">
          <a-input v-model="entity.Other" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="海关编码" prop="CustomsCode">
          <a-input v-model="entity.CustomsCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="业务代码" prop="BusinessCode">
          <a-input v-model="entity.BusinessCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="揽货人员" prop="Collector">
          <a-input v-model="entity.Collector" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="客服人员" prop="CustomerService">
          <a-input v-model="entity.CustomerService" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="电话" prop="Telephone">
          <a-input v-model="entity.Telephone" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="传真" prop="Fax">
          <a-input v-model="entity.Fax" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="网站" prop="Website">
          <a-input v-model="entity.Website" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="地址" prop="Address">
          <a-input v-model="entity.Address" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮箱" prop="Email">
          <a-input v-model="entity.Email" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Remark">
          <a-input v-model="entity.Remark" autocomplete="off" />
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
        this.$http.post('/Basic/tbasecustomer/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tbasecustomer/SaveData', this.entity).then(resJson => {
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
