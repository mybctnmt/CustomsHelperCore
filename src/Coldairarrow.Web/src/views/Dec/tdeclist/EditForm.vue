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
        <a-form-model-item label="归类标志" prop="ClassMark">
          <a-input v-model="entity.ClassMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品编号" prop="CodeTS">
          <a-input v-model="entity.CodeTS" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备案序号" prop="ContrItem">
          <a-input v-model="entity.ContrItem" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报单价" prop="DeclPrice">
          <a-input v-model="entity.DeclPrice" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报总价" prop="DeclTotal">
          <a-input v-model="entity.DeclTotal" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="征免方式" prop="DutyMode">
          <a-input v-model="entity.DutyMode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货号" prop="ExgNo">
          <a-input v-model="entity.ExgNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="版本号" prop="ExgVersion">
          <a-input v-model="entity.ExgVersion" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报计量单位与法定单位比例因子" prop="Factor">
          <a-input v-model="entity.Factor" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第一计量单位（法定单位）" prop="FirstUnit">
          <a-input v-model="entity.FirstUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第一法定数量" prop="FirstQty">
          <a-input v-model="entity.FirstQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交计量单位" prop="GUnit">
          <a-input v-model="entity.GUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品规格、型号" prop="GModel">
          <a-input v-model="entity.GModel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品名称" prop="GName">
          <a-input v-model="entity.GName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品序号" prop="GNo">
          <a-input v-model="entity.GNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交数量" prop="GQty">
          <a-input v-model="entity.GQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产国" prop="OriginCountry">
          <a-input v-model="entity.OriginCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第二计量单位" prop="SecondUnit">
          <a-input v-model="entity.SecondUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="第二法定数量" prop="SecondQty">
          <a-input v-model="entity.SecondQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成交币制" prop="TradeCurr">
          <a-input v-model="entity.TradeCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="用途/生产厂家" prop="UseTo">
          <a-input v-model="entity.UseTo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="工缴费" prop="WorkUsd">
          <a-input v-model="entity.WorkUsd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="最终目的国（地区）" prop="DestinationCountry">
          <a-input v-model="entity.DestinationCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫编码" prop="CiqCode">
          <a-input v-model="entity.CiqCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品英文名称" prop="DeclGoodsEname">
          <a-input v-model="entity.DeclGoodsEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地区代码" prop="OrigPlaceCode">
          <a-input v-model="entity.OrigPlaceCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="用途代码" prop="Purpose">
          <a-input v-model="entity.Purpose" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="产品有效期" prop="ProdValidDt">
          <a-input v-model="entity.ProdValidDt" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="产品保质期" prop="ProdQgp">
          <a-input v-model="entity.ProdQgp" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物属性代码" prop="GoodsAttr">
          <a-input v-model="entity.GoodsAttr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="成份/原料/组份" prop="Stuff">
          <a-input v-model="entity.Stuff" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="UN编码" prop="Uncode">
          <a-input v-model="entity.Uncode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="危险货物名称" prop="DangName">
          <a-input v-model="entity.DangName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="危包类别" prop="DangPackType">
          <a-input v-model="entity.DangPackType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="危包规格" prop="DangPackSpec">
          <a-input v-model="entity.DangPackSpec" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外生产企业名称" prop="EngManEntCnm">
          <a-input v-model="entity.EngManEntCnm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="非危险化学品" prop="NoDangFlag">
          <a-input v-model="entity.NoDangFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="目的地代码" prop="DestCode">
          <a-input v-model="entity.DestCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫货物规格" prop="GoodsSpec">
          <a-input v-model="entity.GoodsSpec" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物型号" prop="GoodsModel">
          <a-input v-model="entity.GoodsModel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物品牌" prop="GoodsBrand">
          <a-input v-model="entity.GoodsBrand" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产日期" prop="ProduceDate">
          <a-input v-model="entity.ProduceDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产批号" prop="ProdBatchNo">
          <a-input v-model="entity.ProdBatchNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境内目的地/境内货源地" prop="DistrictCode">
          <a-input v-model="entity.DistrictCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫名称" prop="CiqName">
          <a-input v-model="entity.CiqName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产单位注册号" prop="MnufctrRegno">
          <a-input v-model="entity.MnufctrRegno" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产单位名称" prop="MnufctrRegName">
          <a-input v-model="entity.MnufctrRegName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="优惠贸易协定项下原产地" prop="RcepOrigPlaceCode">
          <a-input v-model="entity.RcepOrigPlaceCode" autocomplete="off" />
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
        this.$http.post('/Dec/tdeclist/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Dec/tdeclist/SaveData', this.entity).then(resJson => {
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
