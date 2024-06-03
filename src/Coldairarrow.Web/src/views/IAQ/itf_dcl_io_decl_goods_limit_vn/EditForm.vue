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
        <a-form-model-item label="许可证编号" prop="LicenceNo">
          <a-input v-model="entity.LicenceNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="许可证类别代码" prop="LicTypeCode">
          <a-input v-model="entity.LicTypeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提/运单日期" prop="BillLadDate">
          <a-input v-model="entity.BillLadDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="质量保质期" prop="QualityQgp">
          <a-input v-model="entity.QualityQgp" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发动机号或电机号" prop="MotorNo">
          <a-input v-model="entity.MotorNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="车辆识别代码（VIN）" prop="VinCode">
          <a-input v-model="entity.VinCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="底盘(车架)号" prop="ChassisNo">
          <a-input v-model="entity.ChassisNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发票所列数量" prop="InvoiceNum">
          <a-input v-model="entity.InvoiceNum" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="品名（中文名称）" prop="ProdCnnm">
          <a-input v-model="entity.ProdCnnm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="品名（英文名称）" prop="ProdEnnm">
          <a-input v-model="entity.ProdEnnm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="型号(英文)" prop="ModelEn">
          <a-input v-model="entity.ModelEn" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="单价" prop="PricePerUnit">
          <a-input v-model="entity.PricePerUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发票号" prop="InvoiceNo">
          <a-input v-model="entity.InvoiceNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Gnumber" prop="Gnumber">
          <a-input v-model="entity.Gnumber" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Vnumber" prop="Vnumber">
          <a-input v-model="entity.Vnumber" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods_limit_vn/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods_limit_vn/SaveData', this.entity).then(resJson => {
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
