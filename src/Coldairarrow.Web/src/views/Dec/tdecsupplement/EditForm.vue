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
        <a-form-model-item label="补充申报单商品序号" prop="GNo">
          <a-input v-model="entity.GNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="补充申报单类型" prop="SupType">
          <a-input v-model="entity.SupType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="品牌中文" prop="BrandCN">
          <a-input v-model="entity.BrandCN" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="品牌英文" prop="BrandEN">
          <a-input v-model="entity.BrandEN" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="买方名称" prop="Buyer">
          <a-input v-model="entity.Buyer" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="买方联系人" prop="BuyerContact">
          <a-input v-model="entity.BuyerContact" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="买方地址" prop="BuyerAddr">
          <a-input v-model="entity.BuyerAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="买方电话" prop="BuyerTel">
          <a-input v-model="entity.BuyerTel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卖方名称" prop="Seller">
          <a-input v-model="entity.Seller" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卖方联系人" prop="SellerContact">
          <a-input v-model="entity.SellerContact" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卖方地址" prop="SellerAddr">
          <a-input v-model="entity.SellerAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="卖方电话" prop="SellerTel">
          <a-input v-model="entity.SellerTel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产厂商名称" prop="Factory">
          <a-input v-model="entity.Factory" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产厂商联系人" prop="FactoryContact">
          <a-input v-model="entity.FactoryContact" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产厂商地址" prop="FactoryAddr">
          <a-input v-model="entity.FactoryAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产厂商电话" prop="FactoryTel">
          <a-input v-model="entity.FactoryTel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="合同协议号" prop="ContrNo">
          <a-input v-model="entity.ContrNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="签约日期" prop="ContrDate">
          <a-input v-model="entity.ContrDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发票编号" prop="InvoiceNo">
          <a-input v-model="entity.InvoiceNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="发票日期" prop="InvoiceDate">
          <a-input v-model="entity.InvoiceDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_BabRel">
          <a-input v-model="entity.I_BabRel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_PriceEffect">
          <a-input v-model="entity.I_PriceEffect" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_PriceClose">
          <a-input v-model="entity.I_PriceClose" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_OtherLimited">
          <a-input v-model="entity.I_OtherLimited" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_OtherEffect">
          <a-input v-model="entity.I_OtherEffect" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_Note1">
          <a-input v-model="entity.I_Note1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项。" prop="I_IsUsefee">
          <a-input v-model="entity.I_IsUsefee" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_IsProfit">
          <a-input v-model="entity.I_IsProfit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物申报项" prop="I_Note2">
          <a-input v-model="entity.I_Note2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，币制" prop="Curr">
          <a-input v-model="entity.Curr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，发票价格单位金额" prop="InvoicePrice">
          <a-input v-model="entity.InvoicePrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，发票价格总金额" prop="InvoiceAmount">
          <a-input v-model="entity.InvoiceAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，发票价格备注" prop="InvoiceNote">
          <a-input v-model="entity.InvoiceNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，间接支付/收取的货款单位金额，进口是间接支付，出口是间接收取" prop="GoodsPrice">
          <a-input v-model="entity.GoodsPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，间接支付/收取的货款总金额，进口是间接支付，出口是间接收取" prop="GoodsAmount">
          <a-input v-model="entity.GoodsAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，间接支付/收取的货款备注，进口是间接支付，出口是间接收取" prop="GoodsNote">
          <a-input v-model="entity.GoodsNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物除购货佣金以外的佣金和经纪费单位金额" prop="I_CommissionPrice">
          <a-input v-model="entity.I_CommissionPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物除购货佣金以外的佣金和经纪费总金额" prop="I_CommissionAmount">
          <a-input v-model="entity.I_CommissionAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物除购货佣金以外的佣金和经纪费备注" prop="I_CommissionNote">
          <a-input v-model="entity.I_CommissionNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，与该进口货物视为一体的容器费用单位金额" prop="I_ContainerPrice">
          <a-input v-model="entity.I_ContainerPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，与该进口货物视为一体的容器费用总金额" prop="I_ContainerAmount">
          <a-input v-model="entity.I_ContainerAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，与该进口货物视为一体的容器费用备注" prop="I_ContainerNote">
          <a-input v-model="entity.I_ContainerNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物包装材料和包装劳务费用单位金额" prop="I_PackPrice">
          <a-input v-model="entity.I_PackPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物包装材料和包装劳务费用总金额" prop="I_PackAmount">
          <a-input v-model="entity.I_PackAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物包装材料和包装劳务费用备注" prop="I_PackNote">
          <a-input v-model="entity.I_PackNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物包含的材料、部件、零件和类似货物单位金额" prop="I_PartPrice">
          <a-input v-model="entity.I_PartPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物包含的材料、部件、零件和类似货物总金额" prop="I_PartAmount">
          <a-input v-model="entity.I_PartAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物包含的材料、部件、零件和类似货物备注" prop="I_PartNote">
          <a-input v-model="entity.I_PartNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，在生产进口货物过程中使用的工具、模具和类似货物单位金额" prop="I_ToolPrice">
          <a-input v-model="entity.I_ToolPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，在生产进口货物过程中使用的工具、模具和类似货物总金额" prop="I_ToolAmount">
          <a-input v-model="entity.I_ToolAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，在生产进口货物过程中使用的工具、模具和类似货物备注" prop="I_ToolNote">
          <a-input v-model="entity.I_ToolNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，在生产进口货物过程中消耗的材料单位金额" prop="I_LossPrice">
          <a-input v-model="entity.I_LossPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，在生产进口货物过程中消耗的材料总金额" prop="I_LossAmount">
          <a-input v-model="entity.I_LossAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，在生产进口货物过程中消耗的材料备注" prop="I_LossNote">
          <a-input v-model="entity.I_LossNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务单位金额" prop="I_DesignPrice">
          <a-input v-model="entity.I_DesignPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务总金额" prop="I_DesignAmount">
          <a-input v-model="entity.I_DesignAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务备注" prop="I_DesignNote">
          <a-input v-model="entity.I_DesignNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，特许权使用费单位金额" prop="I_UsefeePrice">
          <a-input v-model="entity.I_UsefeePrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，特许权使用费总金额" prop="I_UsefeeAmount">
          <a-input v-model="entity.I_UsefeeAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，特许权使用费备注" prop="I_UsefeeNote">
          <a-input v-model="entity.I_UsefeeNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益单位金额" prop="I_ProfitPrice">
          <a-input v-model="entity.I_ProfitPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益总金额" prop="I_ProfitAmount">
          <a-input v-model="entity.I_ProfitAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益备注" prop="I_ProfitNote">
          <a-input v-model="entity.I_ProfitNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物运输费用单位金额" prop="I_FeePrice">
          <a-input v-model="entity.I_FeePrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物运输费用总金额" prop="I_FeeAmount">
          <a-input v-model="entity.I_FeeAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物运输费用备注" prop="I_FeeNote">
          <a-input v-model="entity.I_FeeNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物运输相关费用单位金额" prop="I_OtherPrice">
          <a-input v-model="entity.I_OtherPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物运输相关费用总金额" prop="I_OtherAmount">
          <a-input v-model="entity.I_OtherAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物运输相关费用备注" prop="I_OtherNote">
          <a-input v-model="entity.I_OtherNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物保险费单位金额" prop="I_InsurPrice">
          <a-input v-model="entity.I_InsurPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物保险费总金额" prop="I_InsurAmount">
          <a-input v-model="entity.I_InsurAmount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，进口货物保险费备注" prop="I_InsurNote">
          <a-input v-model="entity.I_InsurNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="价格申报项，出口关税是否已经从申报价格中扣除" prop="E_IsDutyDel">
          <a-input v-model="entity.E_IsDutyDel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项，商品其他名称" prop="GNameOther">
          <a-input v-model="entity.GNameOther" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项，进/出口国地区海关商品编码" prop="CodeTsOther">
          <a-input v-model="entity.CodeTsOther" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项" prop="IsClassDecision">
          <a-input v-model="entity.IsClassDecision" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项，预归类决定书编号" prop="DecisionNO">
          <a-input v-model="entity.DecisionNO" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项，预归类决定书商品编码" prop="CodeTsDecision">
          <a-input v-model="entity.CodeTsDecision" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项，作出预归类决定的直属海关" prop="DecisionCus">
          <a-input v-model="entity.DecisionCus" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="归类申报项，该商品是否曾被海关取样化验" prop="IsSampleTest">
          <a-input v-model="entity.IsSampleTest" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="GOptions" prop="GOptions">
          <a-input v-model="entity.GOptions" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运输方式" prop="TrafMode">
          <a-input v-model="entity.TrafMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，是否直接运输" prop="IsDirectTraf">
          <a-input v-model="entity.IsDirectTraf" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，中转国地区，如果选择非直接运输，必填" prop="TransitCountry">
          <a-input v-model="entity.TransitCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，到货口岸" prop="DestPort">
          <a-input v-model="entity.DestPort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，申报口岸" prop="DeclPort">
          <a-input v-model="entity.DeclPort" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，提单编号" prop="BillNo">
          <a-input v-model="entity.BillNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项" prop="OriginCountry">
          <a-input v-model="entity.OriginCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，原产国地区标记的位置" prop="OriginMark">
          <a-input v-model="entity.OriginMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，原产地证书签发机构及所在国家地区，非参数选项，可录入汉字或字母" prop="CertCountry">
          <a-input v-model="entity.CertCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，原产地证书编号" prop="CertNO">
          <a-input v-model="entity.CertNO" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地申报项，适用的原产地标准" prop="CertStandard">
          <a-input v-model="entity.CertStandard" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="公共申报项，其他需要说明的情况" prop="OtherNote">
          <a-input v-model="entity.OtherNote" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="对以上申报内容是否需要海关予以保密" prop="IsSecret">
          <a-input v-model="entity.IsSecret" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报单位类型" prop="AgentType">
          <a-input v-model="entity.AgentType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人单位地址" prop="DeclAddr">
          <a-input v-model="entity.DeclAddr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人邮编" prop="DeclPost">
          <a-input v-model="entity.DeclPost" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报人电话" prop="DeclTel">
          <a-input v-model="entity.DeclTel" autocomplete="off" />
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
        this.$http.post('/Dec/tdecsupplement/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdecsupplement/SaveData', this.entity).then(resJson => {
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
