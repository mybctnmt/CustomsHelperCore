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
        <a-form-model-item label="企业资质编号" prop="EntQualifNo">
          <a-input v-model="entity.EntQualifNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业资质类别代码/企业承诺证明、声明材料代码" prop="EntQualifTypeCode">
          <a-input v-model="entity.EntQualifTypeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="根据HS编码设限情况确定" prop="EntQualifName">
          <a-input v-model="entity.EntQualifName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业组织机构代码" prop="EntOrgCode">
          <a-input v-model="entity.EntOrgCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业名称" prop="EntName">
          <a-input v-model="entity.EntName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="业务类型：0/空：企业资质；1：企业承诺" prop="BizType">
          <a-input v-model="entity.BizType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_dcl_io_decl_ent/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dcl_io_decl_ent/SaveData', this.entity).then(resJson => {
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
