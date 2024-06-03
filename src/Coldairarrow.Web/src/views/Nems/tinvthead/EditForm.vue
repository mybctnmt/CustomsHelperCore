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
        <a-form-model-item label="清单编号" prop="BondInvtNo">
          <a-input v-model="entity.BondInvtNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="清单预录入统一编号" prop="SeqNo">
          <a-input v-model="entity.SeqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备案编号" prop="PutrecNo">
          <a-input v-model="entity.PutrecNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="企业内部清单编号" prop="EtpsInnerInvtNo">
          <a-input v-model="entity.EtpsInnerInvtNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经营企业社会信用代码" prop="BizopEtpsSccd">
          <a-input v-model="entity.BizopEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经营企业编号" prop="BizopEtpsNo">
          <a-input v-model="entity.BizopEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="经营企业名称" prop="BizopEtpsNm">
          <a-input v-model="entity.BizopEtpsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货企业编号" prop="RcvgdEtpsNo">
          <a-input v-model="entity.RcvgdEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收发货企业社会信用代码" prop="RvsngdEtpsSccd">
          <a-input v-model="entity.RvsngdEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="收货企业名称" prop="RcvgdEtpsNm">
          <a-input v-model="entity.RcvgdEtpsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报企业社会信用代码" prop="DclEtpsSccd">
          <a-input v-model="entity.DclEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报企业编号" prop="DclEtpsNo">
          <a-input v-model="entity.DclEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报企业名称" prop="DclEtpsNm">
          <a-input v-model="entity.DclEtpsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="清单申报时间" prop="InvtDclTime">
          <a-input v-model="entity.InvtDclTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单申报日期" prop="EntryDclTime">
          <a-input v-model="entity.EntryDclTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对应报关单编号" prop="EntryNo">
          <a-input v-model="entity.EntryNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联清单编号" prop="RltInvtNo">
          <a-input v-model="entity.RltInvtNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联手（账）册备案编号" prop="RltPutrecNo">
          <a-input v-model="entity.RltPutrecNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单编号" prop="RltEntryNo">
          <a-input v-model="entity.RltEntryNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单境内收发货人社会信用代码" prop="RltEntryBizopEtpsSccd">
          <a-input v-model="entity.RltEntryBizopEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单境内收发货人编号" prop="RltEntryBizopEtpsNo">
          <a-input v-model="entity.RltEntryBizopEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单境内收发货人名称" prop="RltEntryBizopEtpsNm">
          <a-input v-model="entity.RltEntryBizopEtpsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单生产销售(消费使用)单位社会统一信用代码" prop="RltEntryRvsngdEtpsSccd">
          <a-input v-model="entity.RltEntryRvsngdEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单生产销售(消费使用)单位编码" prop="RltEntryRcvgdEtpsNo">
          <a-input v-model="entity.RltEntryRcvgdEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单生产销售(消费使用)单位名称" prop="RltEntryRcvgdEtpsNm">
          <a-input v-model="entity.RltEntryRcvgdEtpsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单申报单位社会统一信用代码" prop="RltEntryDclEtpsSccd">
          <a-input v-model="entity.RltEntryDclEtpsSccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单海关申报单位编码" prop="RltEntryDclEtpsNo">
          <a-input v-model="entity.RltEntryDclEtpsNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关联报关单申报单位名称" prop="RltEntryDclEtpsNm">
          <a-input v-model="entity.RltEntryDclEtpsNm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出境关别" prop="ImpExpPortcd">
          <a-input v-model="entity.ImpExpPortcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报地关区代码" prop="DclPlcCuscd">
          <a-input v-model="entity.DclPlcCuscd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="进出口标记代码" prop="ImpExpMarkcd">
          <a-input v-model="entity.ImpExpMarkcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="料件成品标记代码" prop="MtpckEndprdMarkcd">
          <a-input v-model="entity.MtpckEndprdMarkcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="监管方式代码" prop="SupvModecd">
          <a-input v-model="entity.SupvModecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输方式代码" prop="TrspModecd">
          <a-input v-model="entity.TrspModecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否报关标志" prop="DclCusFlag">
          <a-input v-model="entity.DclCusFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关类型代码" prop="DclCusTypecd">
          <a-input v-model="entity.DclCusTypecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="核扣标记代码" prop="VrfdedMarkcd">
          <a-input v-model="entity.VrfdedMarkcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="清单进出卡口状态代码" prop="InvtIochkptStucd">
          <a-input v-model="entity.InvtIochkptStucd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="预核扣时间" prop="PrevdTime">
          <a-input v-model="entity.PrevdTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="正式核扣时间" prop="FormalVrfdedTime">
          <a-input v-model="entity.FormalVrfdedTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申请表编号" prop="ApplyNo">
          <a-input v-model="entity.ApplyNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="流转类型" prop="ListType">
          <a-input v-model="entity.ListType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入企业编号" prop="InputCode">
          <a-input v-model="entity.InputCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入企业社会信用代码" prop="InputCreditCode">
          <a-input v-model="entity.InputCreditCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入单位名称" prop="InputName">
          <a-input v-model="entity.InputName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人IC卡号" prop="IcCardNo">
          <a-input v-model="entity.IcCardNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="录入日期" prop="InputTime">
          <a-input v-model="entity.InputTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="清单状态" prop="ListStat">
          <a-input v-model="entity.ListStat" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对应报关单申报单位社会统一信用代码" prop="CorrentryDclEtpssccd">
          <a-input v-model="entity.CorrentryDclEtpssccd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对应报关单申报单位代码" prop="CorrentryDclEtpsno">
          <a-input v-model="entity.CorrentryDclEtpsno" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对应报关单申报单位名称" prop="CorrentryDclEtpsnm">
          <a-input v-model="entity.CorrentryDclEtpsnm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单类型" prop="DecType">
          <a-input v-model="entity.DecType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="变更次数" prop="ChgTmsCnt">
          <a-input v-model="entity.ChgTmsCnt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="起运/运抵国(地区）" prop="StshipTrsarvNatcd">
          <a-input v-model="entity.StshipTrsarvNatcd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="清单类型" prop="InvtType">
          <a-input v-model="entity.InvtType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关状态" prop="EntryStucd">
          <a-input v-model="entity.EntryStucd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="核放单生成标志代码" prop="PassPortUsedTypecd">
          <a-input v-model="entity.PassPortUsedTypecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报类型" prop="DclTypecd">
          <a-input v-model="entity.DclTypecd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报关单同步修改标志" prop="NeedEntryModified">
          <a-input v-model="entity.NeedEntryModified" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="计征金额" prop="LevyBlAmt">
          <a-input v-model="entity.LevyBlAmt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Rmk">
          <a-input v-model="entity.Rmk" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否生成报关单" prop="GenDecFlag">
          <a-input v-model="entity.GenDecFlag" autocomplete="off" />
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
        this.$http.post('/Nems/tinvthead/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Nems/tinvthead/SaveData', this.entity).then(resJson => {
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
