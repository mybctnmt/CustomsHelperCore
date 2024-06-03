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
                <a-select-option key="LicenceNo">许可证编号</a-select-option>
                <a-select-option key="LicTypeCode">许可证类别代码</a-select-option>
                <a-select-option key="QualityQgp">质量保质期</a-select-option>
                <a-select-option key="MotorNo">发动机号或电机号</a-select-option>
                <a-select-option key="VinCode">车辆识别代码（VIN）</a-select-option>
                <a-select-option key="ChassisNo">底盘(车架)号</a-select-option>
                <a-select-option key="ProdCnnm">品名（中文名称）</a-select-option>
                <a-select-option key="ProdEnnm">品名（英文名称）</a-select-option>
                <a-select-option key="ModelEn">型号(英文)</a-select-option>
                <a-select-option key="PricePerUnit">单价</a-select-option>
                <a-select-option key="InvoiceNo">发票号</a-select-option>
                <a-select-option key="Unumber">Unumber</a-select-option>
                <a-select-option key="Gnumber">Gnumber</a-select-option>
                <a-select-option key="Vnumber">Vnumber</a-select-option>
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
  { title: '许可证编号', dataIndex: 'LicenceNo', width: '10%' },
  { title: '许可证类别代码', dataIndex: 'LicTypeCode', width: '10%' },
  { title: '提/运单日期', dataIndex: 'BillLadDate', width: '10%' },
  { title: '质量保质期', dataIndex: 'QualityQgp', width: '10%' },
  { title: '发动机号或电机号', dataIndex: 'MotorNo', width: '10%' },
  { title: '车辆识别代码（VIN）', dataIndex: 'VinCode', width: '10%' },
  { title: '底盘(车架)号', dataIndex: 'ChassisNo', width: '10%' },
  { title: '发票所列数量', dataIndex: 'InvoiceNum', width: '10%' },
  { title: '品名（中文名称）', dataIndex: 'ProdCnnm', width: '10%' },
  { title: '品名（英文名称）', dataIndex: 'ProdEnnm', width: '10%' },
  { title: '型号(英文)', dataIndex: 'ModelEn', width: '10%' },
  { title: '单价', dataIndex: 'PricePerUnit', width: '10%' },
  { title: '发票号', dataIndex: 'InvoiceNo', width: '10%' },
  { title: 'Unumber', dataIndex: 'Unumber', width: '10%' },
  { title: 'Gnumber', dataIndex: 'Gnumber', width: '10%' },
  { title: 'Vnumber', dataIndex: 'Vnumber', width: '10%' },
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
        .post('/IAQ/itf_dcl_io_decl_goods_limit_vn/GetDataList', {
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
            thisObj.$http.post('/IAQ/itf_dcl_io_decl_goods_limit_vn/DeleteData', ids).then(resJson => {
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