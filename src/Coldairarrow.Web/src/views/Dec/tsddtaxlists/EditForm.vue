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
        <a-form-model-item label="商品序号" prop="GNo">
          <a-input v-model="entity.GNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品编号" prop="CodeTs">
          <a-input v-model="entity.CodeTs" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品名称" prop="GName">
          <a-input v-model="entity.GName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="产销国" prop="OriginCountry">
          <a-input v-model="entity.OriginCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="协定编号" prop="AgreementId">
          <a-input v-model="entity.AgreementId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第一数量" prop="Qty1">
          <a-input v-model="entity.Qty1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第一计量单位" prop="Unit1">
          <a-input v-model="entity.Unit1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第二数量" prop="Qty2">
          <a-input v-model="entity.Qty2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第二计量单位" prop="Unit2">
          <a-input v-model="entity.Unit2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交币制" prop="TradeCurr">
          <a-input v-model="entity.TradeCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报单价" prop="DeclPrice">
          <a-input v-model="entity.DeclPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报总价" prop="DeclTotal">
          <a-input v-model="entity.DeclTotal" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征减免税方式" prop="DutyMode">
          <a-input v-model="entity.DutyMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="反倾销涉案" prop="Antidumping">
          <a-input v-model="entity.Antidumping" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="反补贴涉案" prop="Antisubsidy">
          <a-input v-model="entity.Antisubsidy" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="特案完税价格" prop="DutyValue">
          <a-input v-model="entity.DutyValue" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关税从价税率" prop="DutyRate">
          <a-input v-model="entity.DutyRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关税从量税率" prop="QtyDutyRate">
          <a-input v-model="entity.QtyDutyRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费税从价税率" prop="RegRate">
          <a-input v-model="entity.RegRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="消费税从量税率" prop="QtyRegRate">
          <a-input v-model="entity.QtyRegRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="增值税率" prop="TaxRate">
          <a-input v-model="entity.TaxRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="反倾销税率" prop="AntidumpingRate">
          <a-input v-model="entity.AntidumpingRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="反补贴税率" prop="AntisubsidyRate">
          <a-input v-model="entity.AntisubsidyRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="废弃基金税率" prop="TrashfundRate">
          <a-input v-model="entity.TrashfundRate" autocomplete="off" />
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
        this.$http.post('/Dec/tsddtaxlists/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tsddtaxlists/SaveData', this.entity).then(resJson => {
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
