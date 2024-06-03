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
                <a-select-option key="CodeTs">商品编号</a-select-option>
                <a-select-option key="GName">商品名称</a-select-option>
                <a-select-option key="OriginCountry">产销国</a-select-option>
                <a-select-option key="AgreementId">协定编号</a-select-option>
                <a-select-option key="Unit1">第一计量单位</a-select-option>
                <a-select-option key="Unit2">第二计量单位</a-select-option>
                <a-select-option key="TradeCurr">成交币制</a-select-option>
                <a-select-option key="DutyMode">征减免税方式</a-select-option>
                <a-select-option key="Antidumping">反倾销涉案</a-select-option>
                <a-select-option key="Antisubsidy">反补贴涉案</a-select-option>
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
  { title: '商品序号', dataIndex: 'GNo', width: '10%' },
  { title: '商品编号', dataIndex: 'CodeTs', width: '10%' },
  { title: '商品名称', dataIndex: 'GName', width: '10%' },
  { title: '产销国', dataIndex: 'OriginCountry', width: '10%' },
  { title: '协定编号', dataIndex: 'AgreementId', width: '10%' },
  { title: '第一数量', dataIndex: 'Qty1', width: '10%' },
  { title: '第一计量单位', dataIndex: 'Unit1', width: '10%' },
  { title: '第二数量', dataIndex: 'Qty2', width: '10%' },
  { title: '第二计量单位', dataIndex: 'Unit2', width: '10%' },
  { title: '成交币制', dataIndex: 'TradeCurr', width: '10%' },
  { title: '申报单价', dataIndex: 'DeclPrice', width: '10%' },
  { title: '申报总价', dataIndex: 'DeclTotal', width: '10%' },
  { title: '征减免税方式', dataIndex: 'DutyMode', width: '10%' },
  { title: '反倾销涉案', dataIndex: 'Antidumping', width: '10%' },
  { title: '反补贴涉案', dataIndex: 'Antisubsidy', width: '10%' },
  { title: '特案完税价格', dataIndex: 'DutyValue', width: '10%' },
  { title: '关税从价税率', dataIndex: 'DutyRate', width: '10%' },
  { title: '关税从量税率', dataIndex: 'QtyDutyRate', width: '10%' },
  { title: '消费税从价税率', dataIndex: 'RegRate', width: '10%' },
  { title: '消费税从量税率', dataIndex: 'QtyRegRate', width: '10%' },
  { title: '增值税率', dataIndex: 'TaxRate', width: '10%' },
  { title: '反倾销税率', dataIndex: 'AntidumpingRate', width: '10%' },
  { title: '反补贴税率', dataIndex: 'AntisubsidyRate', width: '10%' },
  { title: '废弃基金税率', dataIndex: 'TrashfundRate', width: '10%' },
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
        .post('/Dec/tsddtaxlists/GetDataList', {
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
            thisObj.$http.post('/Dec/tsddtaxlists/DeleteData', ids).then(resJson => {
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