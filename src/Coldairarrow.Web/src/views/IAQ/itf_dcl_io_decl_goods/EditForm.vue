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
        <a-form-model-item label="货物序号" prop="GNo">
          <a-input v-model="entity.GNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品编码" prop="CodeTs">
          <a-input v-model="entity.CodeTs" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="商品名称" prop="GName">
          <a-input v-model="entity.GName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="监管要求" prop="SupvDmd">
          <a-input v-model="entity.SupvDmd" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="币种代码" prop="CiqCurr">
          <a-input v-model="entity.CiqCurr" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="HS标准计量单位数量" prop="Qty1">
          <a-input v-model="entity.Qty1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="HS标准计量单位" prop="Unit1">
          <a-input v-model="entity.Unit1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="HS编码描述" prop="HsCodeDesc">
          <a-input v-model="entity.HsCodeDesc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检验检疫类别" prop="InspType">
          <a-input v-model="entity.InspType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CIQ代码" prop="CiqCode">
          <a-input v-model="entity.CiqCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="CIQ名称" prop="CiqName">
          <a-input v-model="entity.CiqName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="申报货物名称（外文）" prop="DeclGoodsEname">
          <a-input v-model="entity.DeclGoodsEname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物规格" prop="GoodsSpec">
          <a-input v-model="entity.GoodsSpec" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物型号" prop="GoodsModel">
          <a-input v-model="entity.GoodsModel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物品牌" prop="GoodsBrand">
          <a-input v-model="entity.GoodsBrand" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产地区代码" prop="OrigPlaceCode">
          <a-input v-model="entity.OrigPlaceCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产日期" prop="ProduceDate">
          <a-input v-model="entity.ProduceDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="原产国" prop="CiqOriginCountry">
          <a-input v-model="entity.CiqOriginCountry" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="产地代码（出口-国内地区）" prop="CiqDomeOriginCode">
          <a-input v-model="entity.CiqDomeOriginCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产单位注册号" prop="MnufctrRegNo">
          <a-input v-model="entity.MnufctrRegNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产单位名称" prop="MnufctrRegName">
          <a-input v-model="entity.MnufctrRegName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="用途代码" prop="Purpose">
          <a-input v-model="entity.Purpose" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="生产批号" prop="ProdBatchNo">
          <a-input v-model="entity.ProdBatchNo" autocomplete="off" />
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
        <a-form-model-item label="UN编码" prop="UnCode">
          <a-input v-model="entity.UnCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="危险货物名称" prop="DangName">
          <a-input v-model="entity.DangName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="危包类别" prop="PackType">
          <a-input v-model="entity.PackType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="危包规格" prop="PackSpec">
          <a-input v-model="entity.PackSpec" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备用一" prop="By1">
          <a-input v-model="entity.By1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备用二" prop="By2">
          <a-input v-model="entity.By2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="境外生产企业名称" prop="EngManEntCnm">
          <a-input v-model="entity.EngManEntCnm" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否危险品标识" prop="DangerFlag">
          <a-input v-model="entity.DangerFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="非危险化学品标识" prop="NoDangFlag">
          <a-input v-model="entity.NoDangFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数量" prop="CiqQty">
          <a-input v-model="entity.CiqQty" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="数量计量单位代码" prop="CiqQtyMeasUnit">
          <a-input v-model="entity.CiqQtyMeasUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重量" prop="CiqWeight">
          <a-input v-model="entity.CiqWeight" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重量计量单位" prop="CiqWtMeasUnit">
          <a-input v-model="entity.CiqWtMeasUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="HS标准量计量单位类型" prop="StdUnitTypeCode">
          <a-input v-model="entity.StdUnitTypeCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="标准重量" prop="StdWeight">
          <a-input v-model="entity.StdWeight" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="单价" prop="PricePerUnit">
          <a-input v-model="entity.PricePerUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="货物总值" prop="GoodsTotalVal">
          <a-input v-model="entity.GoodsTotalVal" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="Gnumber" prop="Gnumber">
          <a-input v-model="entity.Gnumber" autocomplete="off" />
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/itf_dcl_io_decl_goods/SaveData', this.entity).then(resJson => {
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
