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
        <a-form-model-item label="辅助包装材料长" prop="PackLenth">
          <a-input v-model="entity.PackLenth" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="辅助包装材料高" prop="PackHigh">
          <a-input v-model="entity.PackHigh" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="辅助包装材料宽" prop="PackWide">
          <a-input v-model="entity.PackWide" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="辅助包装材料种类代码" prop="PackTypeCode">
          <a-input v-model="entity.PackTypeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包装种类名称" prop="PackCatgName">
          <a-input v-model="entity.PackCatgName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包装种类中文简称" prop="PackTypeShort">
          <a-input v-model="entity.PackTypeShort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包装件数" prop="PackQty">
          <a-input v-model="entity.PackQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否主要包装" prop="IsMainPack">
          <a-input v-model="entity.IsMainPack" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包装材料种类" prop="MatType">
          <a-input v-model="entity.MatType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工厂家" prop="ProcFactory">
          <a-input v-model="entity.ProcFactory" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods_pack/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods_pack/SaveData', this.entity).then(resJson => {
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
