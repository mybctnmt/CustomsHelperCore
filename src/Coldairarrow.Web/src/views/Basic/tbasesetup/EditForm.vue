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
        <a-form-model-item label="API请求地址" prop="APIURL">
          <a-input v-model="entity.APIURL" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="自动获取列表" prop="AutoListRetrieval">
          <a-input v-model="entity.AutoListRetrieval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="自动获取明细" prop="AutoDetailRetrieval">
          <a-input v-model="entity.AutoDetailRetrieval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="自动获取运抵舱单" prop="AutoManifestRetrieval">
          <a-input v-model="entity.AutoManifestRetrieval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="自动获取云港通" prop="AutoYungangtongRetrieval">
          <a-input v-model="entity.AutoYungangtongRetrieval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卡密码" prop="CardPass">
          <a-input v-model="entity.CardPass" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="云港通账号" prop="YungangtongAcct">
          <a-input v-model="entity.YungangtongAcct" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="云港通密码" prop="YungangtongPass">
          <a-input v-model="entity.YungangtongPass" autocomplete="off" />
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
        this.$http.post('/Basic/tbasesetup/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tbasesetup/SaveData', this.entity).then(resJson => {
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
