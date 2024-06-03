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
        <a-form-model-item label="集装箱号码" prop="ContainerNo">
          <a-input v-model="entity.ContainerNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="HS编码" prop="ProdHsCode">
          <a-input v-model="entity.ProdHsCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输工具类型代码" prop="TransMeansType">
          <a-input v-model="entity.TransMeansType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="集装箱规格代码" prop="CntnrModeCode">
          <a-input v-model="entity.CntnrModeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="集装箱数量" prop="Qty">
          <a-input v-model="entity.Qty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数量计量单位" prop="CiqQtyMeasUnit">
          <a-input v-model="entity.CiqQtyMeasUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="标准计量单位数量" prop="Qty1">
          <a-input v-model="entity.Qty1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重量" prop="CiqWeight">
          <a-input v-model="entity.CiqWeight" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="HS标准计量单位" prop="Unit1">
          <a-input v-model="entity.Unit1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重量单位代码" prop="CiqWtUnitCode">
          <a-input v-model="entity.CiqWtUnitCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Gnumber" prop="Gnumber">
          <a-input v-model="entity.Gnumber" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods_cont/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods_cont/SaveData', this.entity).then(resJson => {
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
