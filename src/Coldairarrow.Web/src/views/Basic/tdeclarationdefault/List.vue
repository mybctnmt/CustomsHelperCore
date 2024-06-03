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
                <a-select-option key="AgentCode">申报单位代码</a-select-option>
                <a-select-option key="AgentName">申报单位名称</a-select-option>
                <a-select-option key="AgentCodeScc">申报代码统一编码</a-select-option>
                <a-select-option key="DeclCiqCode">申报单位检验检疫编码</a-select-option>
                <a-select-option key="IEFlag">进出口标志</a-select-option>
                <a-select-option key="IEPort">进出境关别</a-select-option>
                <a-select-option key="CustomMaster">主管海关（申报地海关）</a-select-option>
                <a-select-option key="EntryType">报关单类型</a-select-option>
                <a-select-option key="CutMode">征免性质</a-select-option>
                <a-select-option key="TradeMode">监管方式</a-select-option>
                <a-select-option key="TransMode">成交方式</a-select-option>
                <a-select-option key="WrapType">包装种类</a-select-option>
                <a-select-option key="TrafMode">运输方式代码</a-select-option>
                <a-select-option key="DutyMode">征免方式</a-select-option>
                <a-select-option key="OriginCountry">原产国</a-select-option>
                <a-select-option key="TradeCurr">成交币制</a-select-option>
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
  { title: '申报单位代码', dataIndex: 'AgentCode', width: '10%' },
  { title: '申报单位名称', dataIndex: 'AgentName', width: '10%' },
  { title: '申报代码统一编码', dataIndex: 'AgentCodeScc', width: '10%' },
  { title: '申报单位检验检疫编码', dataIndex: 'DeclCiqCode', width: '10%' },
  { title: '进出口标志', dataIndex: 'IEFlag', width: '10%' },
  { title: '进出境关别', dataIndex: 'IEPort', width: '10%' },
  { title: '主管海关（申报地海关）', dataIndex: 'CustomMaster', width: '10%' },
  { title: '报关单类型', dataIndex: 'EntryType', width: '10%' },
  { title: '征免性质', dataIndex: 'CutMode', width: '10%' },
  { title: '监管方式', dataIndex: 'TradeMode', width: '10%' },
  { title: '成交方式', dataIndex: 'TransMode', width: '10%' },
  { title: '包装种类', dataIndex: 'WrapType', width: '10%' },
  { title: '运输方式代码', dataIndex: 'TrafMode', width: '10%' },
  { title: '征免方式', dataIndex: 'DutyMode', width: '10%' },
  { title: '原产国', dataIndex: 'OriginCountry', width: '10%' },
  { title: '成交币制', dataIndex: 'TradeCurr', width: '10%' },
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
        .post('/Basic/tdeclarationdefault/GetDataList', {
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
            thisObj.$http.post('/Basic/tdeclarationdefault/DeleteData', ids).then(resJson => {
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