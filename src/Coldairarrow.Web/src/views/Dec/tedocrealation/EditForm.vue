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
        <a-form-model-item label="文件名、随附单据编号（文件名命名规则是：申报口岸+随附单据类别代码+IM+18位流水号+.pdf）" prop="EdocID">
          <a-input v-model="entity.EdocID" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单证类别" prop="EdocCode">
          <a-input v-model="entity.EdocCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据格式类型" prop="EdocFomatType">
          <a-input v-model="entity.EdocFomatType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作说明（重传原因）" prop="OpNote">
          <a-input v-model="entity.OpNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据文件企业名" prop="EdocCopId">
          <a-input v-model="entity.EdocCopId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="所属单位海关编号" prop="EdocOwnerCode">
          <a-input v-model="entity.EdocOwnerCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名单位代码" prop="SignUnit">
          <a-input v-model="entity.SignUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名时间" prop="SignTime">
          <a-input v-model="entity.SignTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="所属单位名称" prop="EdocOwnerName">
          <a-input v-model="entity.EdocOwnerName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据文件大小" prop="EdocSize">
          <a-input v-model="entity.EdocSize" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品项号关系" prop="GNoStr">
          <a-input v-model="entity.GNoStr" autocomplete="off" />
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
        this.$http.post('/Dec/tedocrealation/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tedocrealation/SaveData', this.entity).then(resJson => {
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
