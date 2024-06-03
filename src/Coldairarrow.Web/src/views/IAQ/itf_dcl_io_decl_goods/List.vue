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
                <a-select-option key="GNo">货物序号</a-select-option>
                <a-select-option key="CodeTs">商品编码</a-select-option>
                <a-select-option key="GName">商品名称</a-select-option>
                <a-select-option key="SupvDmd">监管要求</a-select-option>
                <a-select-option key="CiqCurr">币种代码</a-select-option>
                <a-select-option key="Unit1">HS标准计量单位</a-select-option>
                <a-select-option key="HsCodeDesc">HS编码描述</a-select-option>
                <a-select-option key="InspType">检验检疫类别</a-select-option>
                <a-select-option key="CiqCode">CIQ代码</a-select-option>
                <a-select-option key="CiqName">CIQ名称</a-select-option>
                <a-select-option key="DeclGoodsEname">申报货物名称（外文）</a-select-option>
                <a-select-option key="GoodsSpec">货物规格</a-select-option>
                <a-select-option key="GoodsModel">货物型号</a-select-option>
                <a-select-option key="GoodsBrand">货物品牌</a-select-option>
                <a-select-option key="OrigPlaceCode">原产地区代码</a-select-option>
                <a-select-option key="ProduceDate">生产日期</a-select-option>
                <a-select-option key="CiqOriginCountry">原产国</a-select-option>
                <a-select-option key="CiqDomeOriginCode">产地代码（出口-国内地区）</a-select-option>
                <a-select-option key="MnufctrRegNo">生产单位注册号</a-select-option>
                <a-select-option key="MnufctrRegName">生产单位名称</a-select-option>
                <a-select-option key="Purpose">用途代码</a-select-option>
                <a-select-option key="ProdBatchNo">生产批号</a-select-option>
                <a-select-option key="GoodsAttr">货物属性代码</a-select-option>
                <a-select-option key="Stuff">成份/原料/组份</a-select-option>
                <a-select-option key="UnCode">UN编码</a-select-option>
                <a-select-option key="DangName">危险货物名称</a-select-option>
                <a-select-option key="PackType">危包类别</a-select-option>
                <a-select-option key="PackSpec">危包规格</a-select-option>
                <a-select-option key="By1">备用一</a-select-option>
                <a-select-option key="By2">备用二</a-select-option>
                <a-select-option key="EngManEntCnm">境外生产企业名称</a-select-option>
                <a-select-option key="DangerFlag">是否危险品标识</a-select-option>
                <a-select-option key="NoDangFlag">非危险化学品标识</a-select-option>
                <a-select-option key="CiqQtyMeasUnit">数量计量单位代码</a-select-option>
                <a-select-option key="CiqWtMeasUnit">重量计量单位</a-select-option>
                <a-select-option key="StdUnitTypeCode">HS标准量计量单位类型</a-select-option>
                <a-select-option key="Unumber">Unumber</a-select-option>
                <a-select-option key="Gnumber">Gnumber</a-select-option>
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
  { title: '货物序号', dataIndex: 'GNo', width: '10%' },
  { title: '商品编码', dataIndex: 'CodeTs', width: '10%' },
  { title: '商品名称', dataIndex: 'GName', width: '10%' },
  { title: '监管要求', dataIndex: 'SupvDmd', width: '10%' },
  { title: '币种代码', dataIndex: 'CiqCurr', width: '10%' },
  { title: 'HS标准计量单位数量', dataIndex: 'Qty1', width: '10%' },
  { title: 'HS标准计量单位', dataIndex: 'Unit1', width: '10%' },
  { title: 'HS编码描述', dataIndex: 'HsCodeDesc', width: '10%' },
  { title: '检验检疫类别', dataIndex: 'InspType', width: '10%' },
  { title: 'CIQ代码', dataIndex: 'CiqCode', width: '10%' },
  { title: 'CIQ名称', dataIndex: 'CiqName', width: '10%' },
  { title: '申报货物名称（外文）', dataIndex: 'DeclGoodsEname', width: '10%' },
  { title: '货物规格', dataIndex: 'GoodsSpec', width: '10%' },
  { title: '货物型号', dataIndex: 'GoodsModel', width: '10%' },
  { title: '货物品牌', dataIndex: 'GoodsBrand', width: '10%' },
  { title: '原产地区代码', dataIndex: 'OrigPlaceCode', width: '10%' },
  { title: '生产日期', dataIndex: 'ProduceDate', width: '10%' },
  { title: '原产国', dataIndex: 'CiqOriginCountry', width: '10%' },
  { title: '产地代码（出口-国内地区）', dataIndex: 'CiqDomeOriginCode', width: '10%' },
  { title: '生产单位注册号', dataIndex: 'MnufctrRegNo', width: '10%' },
  { title: '生产单位名称', dataIndex: 'MnufctrRegName', width: '10%' },
  { title: '用途代码', dataIndex: 'Purpose', width: '10%' },
  { title: '生产批号', dataIndex: 'ProdBatchNo', width: '10%' },
  { title: '产品有效期', dataIndex: 'ProdValidDt', width: '10%' },
  { title: '产品保质期', dataIndex: 'ProdQgp', width: '10%' },
  { title: '货物属性代码', dataIndex: 'GoodsAttr', width: '10%' },
  { title: '成份/原料/组份', dataIndex: 'Stuff', width: '10%' },
  { title: 'UN编码', dataIndex: 'UnCode', width: '10%' },
  { title: '危险货物名称', dataIndex: 'DangName', width: '10%' },
  { title: '危包类别', dataIndex: 'PackType', width: '10%' },
  { title: '危包规格', dataIndex: 'PackSpec', width: '10%' },
  { title: '备用一', dataIndex: 'By1', width: '10%' },
  { title: '备用二', dataIndex: 'By2', width: '10%' },
  { title: '境外生产企业名称', dataIndex: 'EngManEntCnm', width: '10%' },
  { title: '是否危险品标识', dataIndex: 'DangerFlag', width: '10%' },
  { title: '非危险化学品标识', dataIndex: 'NoDangFlag', width: '10%' },
  { title: '数量', dataIndex: 'CiqQty', width: '10%' },
  { title: '数量计量单位代码', dataIndex: 'CiqQtyMeasUnit', width: '10%' },
  { title: '重量', dataIndex: 'CiqWeight', width: '10%' },
  { title: '重量计量单位', dataIndex: 'CiqWtMeasUnit', width: '10%' },
  { title: 'HS标准量计量单位类型', dataIndex: 'StdUnitTypeCode', width: '10%' },
  { title: '标准重量', dataIndex: 'StdWeight', width: '10%' },
  { title: '单价', dataIndex: 'PricePerUnit', width: '10%' },
  { title: '货物总值', dataIndex: 'GoodsTotalVal', width: '10%' },
  { title: 'Unumber', dataIndex: 'Unumber', width: '10%' },
  { title: 'Gnumber', dataIndex: 'Gnumber', width: '10%' },
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
        .post('/IAQ/itf_dcl_io_decl_goods/GetDataList', {
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
            thisObj.$http.post('/IAQ/itf_dcl_io_decl_goods/DeleteData', ids).then(resJson => {
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