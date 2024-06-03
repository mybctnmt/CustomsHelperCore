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
        <a-form-model-item label="货物申报_发送文件" prop="Deccus001OutBox">
          <a-input v-model="entity.Deccus001OutBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物申报_回执文件" prop="Deccus001InBox">
          <a-input v-model="entity.Deccus001InBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物申报_回执文件备份" prop="Deccus001HDNBox">
          <a-input v-model="entity.Deccus001HDNBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物申报_压缩回执文件备份" prop="Deccus001HDNBoxZIP">
          <a-input v-model="entity.Deccus001HDNBoxZIP" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易手册_发送文件" prop="NptsOutBox">
          <a-input v-model="entity.NptsOutBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易手册_回执文件" prop="NptsInBox">
          <a-input v-model="entity.NptsInBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易手册_回执文件备份" prop="NptsHDNBox">
          <a-input v-model="entity.NptsHDNBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易手册_压缩回执文件备份" prop="NptsHDNBoxZIP">
          <a-input v-model="entity.NptsHDNBoxZIP" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易账册_发送文件" prop="NemsOutBox">
          <a-input v-model="entity.NemsOutBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易账册_回执文件" prop="NemsInBox">
          <a-input v-model="entity.NemsInBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易账册_回执文件备份" prop="NemsHDNBox">
          <a-input v-model="entity.NemsHDNBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易账册_压缩回执文件备份" prop="NemsHDNBoxZIP">
          <a-input v-model="entity.NemsHDNBoxZIP" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易随附单据_发送文件" prop="AcmpOutBox">
          <a-input v-model="entity.AcmpOutBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易随附单据_回执文件" prop="AcmpInBox">
          <a-input v-model="entity.AcmpInBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易随附单据_回执文件备份" prop="AcmpHDNBox">
          <a-input v-model="entity.AcmpHDNBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="加工贸易随附单据_压缩回执文件备份" prop="AcmpHDNBoxZIP">
          <a-input v-model="entity.AcmpHDNBoxZIP" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据_发送文件" prop="Decedoc001OutBox">
          <a-input v-model="entity.Decedoc001OutBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据_回执文件" prop="Decedoc001InBox">
          <a-input v-model="entity.Decedoc001InBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据_回执文件备份" prop="Decedoc001HDNBox">
          <a-input v-model="entity.Decedoc001HDNBox" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单据_压缩回执文件备份" prop="Decedoc001HDNBoxZIP">
          <a-input v-model="entity.Decedoc001HDNBoxZIP" autocomplete="off" />
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
        this.$http.post('/Basic/tsinglewindowsetup/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tsinglewindowsetup/SaveData', this.entity).then(resJson => {
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
