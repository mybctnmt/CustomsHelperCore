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
        <a-form-model-item label="id" prop="id">
          <a-input v-model="entity.id" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="catalog_id" prop="catalog_id">
          <a-input v-model="entity.catalog_id" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="chapter_id" prop="chapter_id">
          <a-input v-model="entity.chapter_id" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="code" prop="code">
          <a-input v-model="entity.code" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="name" prop="name">
          <a-input v-model="entity.name" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="criteria" prop="criteria">
          <a-input v-model="entity.criteria" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="legal_unit1" prop="legal_unit1">
          <a-input v-model="entity.legal_unit1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="legal_unit2" prop="legal_unit2">
          <a-input v-model="entity.legal_unit2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="import_tariff_conv" prop="import_tariff_conv">
          <a-input v-model="entity.import_tariff_conv" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="import_tariff_norm" prop="import_tariff_norm">
          <a-input v-model="entity.import_tariff_norm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="import_tariff_temp" prop="import_tariff_temp">
          <a-input v-model="entity.import_tariff_temp" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="consumption_rate" prop="consumption_rate">
          <a-input v-model="entity.consumption_rate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="export_tariff" prop="export_tariff">
          <a-input v-model="entity.export_tariff" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="export_tariff_temp" prop="export_tariff_temp">
          <a-input v-model="entity.export_tariff_temp" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="export_rebate_rate" prop="export_rebate_rate">
          <a-input v-model="entity.export_rebate_rate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="VAT" prop="VAT">
          <a-input v-model="entity.VAT" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="cust_supervision_cond" prop="cust_supervision_cond">
          <a-input v-model="entity.cust_supervision_cond" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ins_quaran_type" prop="ins_quaran_type">
          <a-input v-model="entity.ins_quaran_type" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="desc" prop="desc">
          <a-input v-model="entity.desc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="desc_en" prop="desc_en">
          <a-input v-model="entity.desc_en" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="catalog_title" prop="catalog_title">
          <a-input v-model="entity.catalog_title" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="chapter_title" prop="chapter_title">
          <a-input v-model="entity.chapter_title" autocomplete="off" />
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
        this.$http.post('/Basic/thscodedesc/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/thscodedesc/SaveData', this.entity).then(resJson => {
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
