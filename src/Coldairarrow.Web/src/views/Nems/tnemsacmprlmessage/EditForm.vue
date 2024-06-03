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
        <a-form-model-item label="附件文件名称" prop="FileName">
          <a-input v-model="entity.FileName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="变更或报核次数" prop="ChgTmsCnt">
          <a-input v-model="entity.ChgTmsCnt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单证格式" prop="AcmpFormFmt">
          <a-input v-model="entity.AcmpFormFmt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="业务单证类型" prop="BlsType">
          <a-input v-model="entity.BlsType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单证序号" prop="AcmpFormSeqNo">
          <a-input v-model="entity.AcmpFormSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单证类型代码" prop="AcmpFormTypeCd">
          <a-input v-model="entity.AcmpFormTypeCd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单证编号" prop="AcmpFormNo">
          <a-input v-model="entity.AcmpFormNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="随附单证文件名称" prop="AcmpFormFileNm">
          <a-input v-model="entity.AcmpFormFileNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="清单商品序号" prop="InvtGdsSeqNo">
          <a-input v-model="entity.InvtGdsSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="上传人IC卡号" prop="IcCardNo">
          <a-input v-model="entity.IcCardNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="上传单位海关编码" prop="TransferTradeCode">
          <a-input v-model="entity.TransferTradeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Rmk">
          <a-input v-model="entity.Rmk" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="修改标记代码" prop="ModfMarkCd">
          <a-input v-model="entity.ModfMarkCd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="包ID" prop="PocketId">
          <a-input v-model="entity.PocketId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="当前包序号" prop="CurPocketNo">
          <a-input v-model="entity.CurPocketNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="总包数" prop="TotalPocketQty">
          <a-input v-model="entity.TotalPocketQty" autocomplete="off" />
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
        this.$http.post('/Nems/tnemsacmprlmessage/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Nems/tnemsacmprlmessage/SaveData', this.entity).then(resJson => {
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
