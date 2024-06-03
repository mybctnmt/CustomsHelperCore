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
        <a-form-model-item label="文件名称" prop="FileName">
          <a-input v-model="entity.FileName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="与录入号" prop="SeqNo">
          <a-input v-model="entity.SeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出口标志" prop="IEFlag">
          <a-input v-model="entity.IEFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报口岸" prop="DeclPort">
          <a-input v-model="entity.DeclPort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="预计申报日期" prop="DDate">
          <a-input v-model="entity.DDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人编号" prop="TradeCo">
          <a-input v-model="entity.TradeCo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人名称" prop="TradeName">
          <a-input v-model="entity.TradeName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="内销比率" prop="InRatio">
          <a-input v-model="entity.InRatio" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="监管方式" prop="TradeMode">
          <a-input v-model="entity.TradeMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征免性质分类" prop="CutMode">
          <a-input v-model="entity.CutMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交方式" prop="TransMode">
          <a-input v-model="entity.TransMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运费标记" prop="FeeMark">
          <a-input v-model="entity.FeeMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运费币制" prop="FeeCurr">
          <a-input v-model="entity.FeeCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运费／率" prop="FeeRate">
          <a-input v-model="entity.FeeRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="保险费标记" prop="InsurMark">
          <a-input v-model="entity.InsurMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="保险费币制" prop="InsurCurr">
          <a-input v-model="entity.InsurCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="保险费／率" prop="InsurRate">
          <a-input v-model="entity.InsurRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="杂费标记" prop="OtherMark">
          <a-input v-model="entity.OtherMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="杂费币制" prop="OtherCurr">
          <a-input v-model="entity.OtherCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="杂费／率" prop="OtherRate">
          <a-input v-model="entity.OtherRate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备案号" prop="ManualNo">
          <a-input v-model="entity.ManualNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内收发货人统一代码" prop="TradeCoScc">
          <a-input v-model="entity.TradeCoScc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="毛重" prop="GrossWt">
          <a-input v-model="entity.GrossWt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="NoteS">
          <a-input v-model="entity.NoteS" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="法律责任" prop="LegalLiability">
          <a-input v-model="entity.LegalLiability" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数字签名信息" prop="Sign">
          <a-input v-model="entity.Sign" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名消息号" prop="MessId">
          <a-input v-model="entity.MessId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签名证书号" prop="CertSeqNo">
          <a-input v-model="entity.CertSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="状态" prop="Status">
          <a-input v-model="entity.Status" autocomplete="off" />
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
        this.$http.post('/Dec/tsddtaxhead/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tsddtaxhead/SaveData', this.entity).then(resJson => {
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
