<template>
  <a-card :bordered="false">
    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="hanldleAdd()">新建</a-button>
      <a-button
        type="primary"
        icon="minus"
        @click="handleDelete(selectedRowKeys)"
        :disabled="!hasSelected()"
        :loading="loading"
      >删除</a-button>
      <a-button type="primary" icon="redo" @click="getDataList()">刷新</a-button>
    </div>

    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="10">
          <a-col :md="4" :sm="24">
            <a-form-item label="查询类别">
              <a-select allowClear v-model="queryParam.condition">
                <a-select-option key="ClassMark">归类标志</a-select-option>
                <a-select-option key="CodeTS">商品编号</a-select-option>
                <a-select-option key="DutyMode">征免方式</a-select-option>
                <a-select-option key="ExgNo">货号</a-select-option>
                <a-select-option key="FirstUnit">第一计量单位（法定单位）</a-select-option>
                <a-select-option key="GUnit">成交计量单位</a-select-option>
                <a-select-option key="GModel">商品规格、型号</a-select-option>
                <a-select-option key="GName">商品名称</a-select-option>
                <a-select-option key="OriginCountry">原产国</a-select-option>
                <a-select-option key="SecondUnit">第二计量单位</a-select-option>
                <a-select-option key="TradeCurr">成交币制</a-select-option>
                <a-select-option key="UseTo">用途/生产厂家</a-select-option>
                <a-select-option key="DestinationCountry">最终目的国（地区）</a-select-option>
                <a-select-option key="CiqCode">检验检疫编码</a-select-option>
                <a-select-option key="DeclGoodsEname">商品英文名称</a-select-option>
                <a-select-option key="OrigPlaceCode">原产地区代码</a-select-option>
                <a-select-option key="Purpose">用途代码</a-select-option>
                <a-select-option key="ProdValidDt">产品有效期</a-select-option>
                <a-select-option key="ProdQgp">产品保质期</a-select-option>
                <a-select-option key="GoodsAttr">货物属性代码</a-select-option>
                <a-select-option key="Stuff">成份/原料/组份</a-select-option>
                <a-select-option key="Uncode">UN编码</a-select-option>
                <a-select-option key="DangName">危险货物名称</a-select-option>
                <a-select-option key="DangPackType">危包类别</a-select-option>
                <a-select-option key="DangPackSpec">危包规格</a-select-option>
                <a-select-option key="EngManEntCnm">境外生产企业名称</a-select-option>
                <a-select-option key="NoDangFlag">非危险化学品</a-select-option>
                <a-select-option key="DestCode">目的地代码</a-select-option>
                <a-select-option key="GoodsSpec">检验检疫货物规格</a-select-option>
                <a-select-option key="GoodsModel">货物型号</a-select-option>
                <a-select-option key="GoodsBrand">货物品牌</a-select-option>
                <a-select-option key="ProduceDate">生产日期</a-select-option>
                <a-select-option key="ProdBatchNo">生产批号</a-select-option>
                <a-select-option key="DistrictCode">境内目的地/境内货源地</a-select-option>
                <a-select-option key="CiqName">检验检疫名称</a-select-option>
                <a-select-option key="MnufctrRegno">生产单位注册号</a-select-option>
                <a-select-option key="MnufctrRegName">生产单位名称</a-select-option>
                <a-select-option key="RcepOrigPlaceCode">优惠贸易协定项下原产地</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="4" :sm="24">
            <a-form-item>
              <a-input v-model="queryParam.keyword" placeholder="关键字" />
            </a-form-item>
          </a-col>
          <a-col :md="6" :sm="24">
            <a-button type="primary" @click="() => {this.pagination.current = 1; this.getDataList()}">查询</a-button>
            <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <a-table
      ref="table"
      :columns="columns"
      :rowKey="row => row.Id"
      :dataSource="data"
      :pagination="pagination"
      :loading="loading"
      @change="handleTableChange"
      :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      :bordered="true"
      size="small"
    >
      <span slot="action" slot-scope="text, record">
        <template>
          <a @click="handleEdit(record.Id)">编辑</a>
          <a-divider type="vertical" />
          <a @click="handleDelete([record.Id])">删除</a>
        </template>
      </span>
    </a-table>

    <edit-form ref="editForm" :parentObj="this"></edit-form>
  </a-card>
</template>

<script>
import EditForm from './EditForm'

const columns = [
  { title: '归类标志', dataIndex: 'ClassMark', width: '10%' },
  { title: '商品编号', dataIndex: 'CodeTS', width: '10%' },
  { title: '备案序号', dataIndex: 'ContrItem', width: '10%' },
  { title: '申报单价', dataIndex: 'DeclPrice', width: '10%' },
  { title: '申报总价', dataIndex: 'DeclTotal', width: '10%' },
  { title: '征免方式', dataIndex: 'DutyMode', width: '10%' },
  { title: '货号', dataIndex: 'ExgNo', width: '10%' },
  { title: '版本号', dataIndex: 'ExgVersion', width: '10%' },
  { title: '申报计量单位与法定单位比例因子', dataIndex: 'Factor', width: '10%' },
  { title: '第一计量单位（法定单位）', dataIndex: 'FirstUnit', width: '10%' },
  { title: '第一法定数量', dataIndex: 'FirstQty', width: '10%' },
  { title: '成交计量单位', dataIndex: 'GUnit', width: '10%' },
  { title: '商品规格、型号', dataIndex: 'GModel', width: '10%' },
  { title: '商品名称', dataIndex: 'GName', width: '10%' },
  { title: '商品序号', dataIndex: 'GNo', width: '10%' },
  { title: '成交数量', dataIndex: 'GQty', width: '10%' },
  { title: '原产国', dataIndex: 'OriginCountry', width: '10%' },
  { title: '第二计量单位', dataIndex: 'SecondUnit', width: '10%' },
  { title: '第二法定数量', dataIndex: 'SecondQty', width: '10%' },
  { title: '成交币制', dataIndex: 'TradeCurr', width: '10%' },
  { title: '用途/生产厂家', dataIndex: 'UseTo', width: '10%' },
  { title: '工缴费', dataIndex: 'WorkUsd', width: '10%' },
  { title: '最终目的国（地区）', dataIndex: 'DestinationCountry', width: '10%' },
  { title: '检验检疫编码', dataIndex: 'CiqCode', width: '10%' },
  { title: '商品英文名称', dataIndex: 'DeclGoodsEname', width: '10%' },
  { title: '原产地区代码', dataIndex: 'OrigPlaceCode', width: '10%' },
  { title: '用途代码', dataIndex: 'Purpose', width: '10%' },
  { title: '产品有效期', dataIndex: 'ProdValidDt', width: '10%' },
  { title: '产品保质期', dataIndex: 'ProdQgp', width: '10%' },
  { title: '货物属性代码', dataIndex: 'GoodsAttr', width: '10%' },
  { title: '成份/原料/组份', dataIndex: 'Stuff', width: '10%' },
  { title: 'UN编码', dataIndex: 'Uncode', width: '10%' },
  { title: '危险货物名称', dataIndex: 'DangName', width: '10%' },
  { title: '危包类别', dataIndex: 'DangPackType', width: '10%' },
  { title: '危包规格', dataIndex: 'DangPackSpec', width: '10%' },
  { title: '境外生产企业名称', dataIndex: 'EngManEntCnm', width: '10%' },
  { title: '非危险化学品', dataIndex: 'NoDangFlag', width: '10%' },
  { title: '目的地代码', dataIndex: 'DestCode', width: '10%' },
  { title: '检验检疫货物规格', dataIndex: 'GoodsSpec', width: '10%' },
  { title: '货物型号', dataIndex: 'GoodsModel', width: '10%' },
  { title: '货物品牌', dataIndex: 'GoodsBrand', width: '10%' },
  { title: '生产日期', dataIndex: 'ProduceDate', width: '10%' },
  { title: '生产批号', dataIndex: 'ProdBatchNo', width: '10%' },
  { title: '境内目的地/境内货源地', dataIndex: 'DistrictCode', width: '10%' },
  { title: '检验检疫名称', dataIndex: 'CiqName', width: '10%' },
  { title: '生产单位注册号', dataIndex: 'MnufctrRegno', width: '10%' },
  { title: '生产单位名称', dataIndex: 'MnufctrRegName', width: '10%' },
  { title: '优惠贸易协定项下原产地', dataIndex: 'RcepOrigPlaceCode', width: '10%' },
  { title: '操作', dataIndex: 'action', scopedSlots: { customRender: 'action' } }
]

export default {
  components: {
    EditForm
  },
  mounted() {
    this.getDataList()
  },
  data() {
    return {
      data: [],
      pagination: {
        current: 1,
        pageSize: 10,
        showTotal: (total, range) => `总数:${total} 当前:${range[0]}-${range[1]}`
      },
      filters: {},
      sorter: { field: 'Id', order: 'asc' },
      loading: false,
      columns,
      queryParam: {},
      selectedRowKeys: []
    }
  },
  methods: {
    handleTableChange(pagination, filters, sorter) {
      this.pagination = { ...pagination }
      this.filters = { ...filters }
      this.sorter = { ...sorter }
      this.getDataList()
    },
    getDataList() {
      this.selectedRowKeys = []

      this.loading = true
      this.$http
        .post('/Dec/tdeclist/GetDataList', {
          PageIndex: this.pagination.current,
          PageRows: this.pagination.pageSize,
          SortField: this.sorter.field || 'Id',
          SortType: this.sorter.order,
          Search: this.queryParam,
          ...this.filters
        })
        .then(resJson => {
          this.loading = false
          this.data = resJson.Data
          const pagination = { ...this.pagination }
          pagination.total = resJson.Total
          this.pagination = pagination
        })
    },
    onSelectChange(selectedRowKeys) {
      this.selectedRowKeys = selectedRowKeys
    },
    hasSelected() {
      return this.selectedRowKeys.length > 0
    },
    hanldleAdd() {
      this.$refs.editForm.openForm()
    },
    handleEdit(id) {
      this.$refs.editForm.openForm(id)
    },
    handleDelete(ids) {
      var thisObj = this
      this.$confirm({
        title: '确认删除吗?',
        onOk() {
          return new Promise((resolve, reject) => {
            thisObj.$http.post('/Dec/tdeclist/DeleteData', ids).then(resJson => {
              resolve()

              if (resJson.Success) {
                thisObj.$message.success('操作成功!')

                thisObj.getDataList()
              } else {
                thisObj.$message.error(resJson.Msg)
              }
            })
          })
        }
      })
    }
  }
}
</script>