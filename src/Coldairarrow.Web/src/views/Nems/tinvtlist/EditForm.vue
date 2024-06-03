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
        <a-form-model-item label="中心统一编号" prop="SeqNo">
          <a-input v-model="entity.SeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品序号" prop="GdsSeqNo">
          <a-input v-model="entity.GdsSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备案序号(对应底账序号）" prop="PutrecSeqNo">
          <a-input v-model="entity.PutrecSeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品料号" prop="GdsMtno">
          <a-input v-model="entity.GdsMtno" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品编码" prop="Gdecd">
          <a-input v-model="entity.Gdecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品名称" prop="GdsNm">
          <a-input v-model="entity.GdsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品规格型号" prop="GdsSpcfModelDesc">
          <a-input v-model="entity.GdsSpcfModelDesc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报计量单位" prop="DclUnitcd">
          <a-input v-model="entity.DclUnitcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="法定计量单位" prop="LawfUnitcd">
          <a-input v-model="entity.LawfUnitcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="法定第二计量" prop="SecdLawfUnitcd">
          <a-input v-model="entity.SecdLawfUnitcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产国(地区)" prop="Natcd">
          <a-input v-model="entity.Natcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业申报单价" prop="DclUprcAmt">
          <a-input v-model="entity.DclUprcAmt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业申报总价" prop="DclTotalAmt">
          <a-input v-model="entity.DclTotalAmt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="美元统计总金额" prop="UsdStatTotalAmt">
          <a-input v-model="entity.UsdStatTotalAmt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="币制" prop="DclCurrcd">
          <a-input v-model="entity.DclCurrcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="法定数量" prop="LawfQty">
          <a-input v-model="entity.LawfQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第二法定数量" prop="SecdLawfQty">
          <a-input v-model="entity.SecdLawfQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重量比例因子" prop="WtSfval">
          <a-input v-model="entity.WtSfval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第一比例因子" prop="FstSfval">
          <a-input v-model="entity.FstSfval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第二比例因子" prop="SecdSfval">
          <a-input v-model="entity.SecdSfval" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报数量" prop="DclQty">
          <a-input v-model="entity.DclQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="毛重" prop="GrossWt">
          <a-input v-model="entity.GrossWt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="净重" prop="NetWt">
          <a-input v-model="entity.NetWt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="用途代码" prop="UseCd">
          <a-input v-model="entity.UseCd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征免方式" prop="LvyrlfModecd">
          <a-input v-model="entity.LvyrlfModecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="单耗版本号" prop="UcnsVerno">
          <a-input v-model="entity.UcnsVerno" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单商品序号" prop="EntryGdsSeqno">
          <a-input v-model="entity.EntryGdsSeqno" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类标志" prop="ClyMarkcd">
          <a-input v-model="entity.ClyMarkcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="流转申报表序号" prop="ApplyTbSeqno">
          <a-input v-model="entity.ApplyTbSeqno" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="最终目的国(地区)" prop="DestinationNatcd">
          <a-input v-model="entity.DestinationNatcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="修改标志" prop="ModfMarkcd">
          <a-input v-model="entity.ModfMarkcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Rmk">
          <a-input v-model="entity.Rmk" autocomplete="off" />
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
        this.$http.post('/Nems/tinvtlist/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Nems/tinvtlist/SaveData', this.entity).then(resJson => {
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
