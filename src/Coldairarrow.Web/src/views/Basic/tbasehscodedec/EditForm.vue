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
        <a-form-model-item label="hscode" prop="hscode">
          <a-input v-model="entity.hscode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="requireCheck" prop="requireCheck">
          <a-input v-model="entity.requireCheck" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="decFacCode" prop="decFacCode">
          <a-input v-model="entity.decFacCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="codeTs" prop="codeTs">
          <a-input v-model="entity.codeTs" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="decFacName" prop="decFacName">
          <a-input v-model="entity.decFacName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="gname" prop="gname">
          <a-input v-model="entity.gname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="decFacType" prop="decFacType">
          <a-input v-model="entity.decFacType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ieFlag" prop="ieFlag">
          <a-input v-model="entity.ieFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="textName" prop="textName">
          <a-input v-model="entity.textName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="snum" prop="snum">
          <a-input v-model="entity.snum" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="extendFiled" prop="extendFiled">
          <a-input v-model="entity.extendFiled" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="decFacContent" prop="decFacContent">
          <a-input v-model="entity.decFacContent" autocomplete="off" />
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
        this.$http.post('/Basic/tbasehscodedec/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tbasehscodedec/SaveData', this.entity).then(resJson => {
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
