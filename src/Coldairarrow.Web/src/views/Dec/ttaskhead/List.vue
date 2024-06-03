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
                <a-select-option key="TaskName">任务名称</a-select-option>
                <a-select-option key="TaskContent">任务内容</a-select-option>
                <a-select-option key="OperatorId">操作员Id</a-select-option>
                <a-select-option key="OperatorName">操作员名称</a-select-option>
                <a-select-option key="ReceiverId">接单人Id</a-select-option>
                <a-select-option key="ReceiverName">接单人名称</a-select-option>
                <a-select-option key="BillNo">提单号</a-select-option>
                <a-select-option key="OrderNo">订单编号-非申报字段</a-select-option>
                <a-select-option key="TrafName">运输工具代码及名称</a-select-option>
                <a-select-option key="CusVoyageNo">航次号</a-select-option>
                <a-select-option key="TradeCountry">启运国/运抵国</a-select-option>
                <a-select-option key="CodeTS">商品编号</a-select-option>
                <a-select-option key="GName">商品名称</a-select-option>
                <a-select-option key="OwnerCode">消费使用/生产销售单位代码</a-select-option>
                <a-select-option key="OwnerName">消费使用/生产销售单位名称</a-select-option>
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
  { title: '任务名称', dataIndex: 'TaskName', width: '10%' },
  { title: '任务内容', dataIndex: 'TaskContent', width: '10%' },
  { title: '是否加急', dataIndex: 'IsUrgent', width: '10%' },
  { title: '操作员Id', dataIndex: 'OperatorId', width: '10%' },
  { title: '操作员名称', dataIndex: 'OperatorName', width: '10%' },
  { title: '操作时间', dataIndex: 'OperateTime', width: '10%' },
  { title: '接单人Id', dataIndex: 'ReceiverId', width: '10%' },
  { title: '接单人名称', dataIndex: 'ReceiverName', width: '10%' },
  { title: '接单时间', dataIndex: 'ReceiveTime', width: '10%' },
  { title: '是否已完成', dataIndex: 'IsCompleted', width: '10%' },
  { title: '提单号', dataIndex: 'BillNo', width: '10%' },
  { title: '订单编号-非申报字段', dataIndex: 'OrderNo', width: '10%' },
  { title: '运输工具代码及名称', dataIndex: 'TrafName', width: '10%' },
  { title: '航次号', dataIndex: 'CusVoyageNo', width: '10%' },
  { title: '启运国/运抵国', dataIndex: 'TradeCountry', width: '10%' },
  { title: '商品编号', dataIndex: 'CodeTS', width: '10%' },
  { title: '商品名称', dataIndex: 'GName', width: '10%' },
  { title: '消费使用/生产销售单位代码', dataIndex: 'OwnerCode', width: '10%' },
  { title: '消费使用/生产销售单位名称', dataIndex: 'OwnerName', width: '10%' },
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
        .post('/Dec/ttaskhead/GetDataList', {
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
            thisObj.$http.post('/Dec/ttaskhead/DeleteData', ids).then(resJson => {
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