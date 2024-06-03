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
                <a-select-option key="OrderNo">订单编号</a-select-option>
                <a-select-option key="InboxId">收件箱Id</a-select-option>
                <a-select-option key="CustomerId">客户Id</a-select-option>
                <a-select-option key="CustomerShortName">客户简称</a-select-option>
                <a-select-option key="OperatorId">操作员Id</a-select-option>
                <a-select-option key="OperatorName">操作员名称</a-select-option>
                <a-select-option key="Subject">邮件主题</a-select-option>
                <a-select-option key="CustomerServiceId">客服Id</a-select-option>
                <a-select-option key="CustomerServiceName">客服名称</a-select-option>
                <a-select-option key="HandlerId">受理人Id</a-select-option>
                <a-select-option key="HandlerName">受理人名称</a-select-option>
                <a-select-option key="EntryClerkId">录单人Id</a-select-option>
                <a-select-option key="EntryClerkName">录单人名称</a-select-option>
                <a-select-option key="RevisionNo">修订次数</a-select-option>
                <a-select-option key="VerifierId">审单人Id</a-select-option>
                <a-select-option key="VerifierName">审单人名称</a-select-option>
                <a-select-option key="ReviewerId">复核人Id</a-select-option>
                <a-select-option key="ReviewerName">复核人名称</a-select-option>
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
  { title: '订单编号', dataIndex: 'OrderNo', width: '10%' },
  { title: '收件箱Id', dataIndex: 'InboxId', width: '10%' },
  { title: '客户Id', dataIndex: 'CustomerId', width: '10%' },
  { title: '客户简称', dataIndex: 'CustomerShortName', width: '10%' },
  { title: '操作员Id', dataIndex: 'OperatorId', width: '10%' },
  { title: '操作员名称', dataIndex: 'OperatorName', width: '10%' },
  { title: '邮件主题', dataIndex: 'Subject', width: '10%' },
  { title: '发送时间', dataIndex: 'SendTime', width: '10%' },
  { title: '客服Id', dataIndex: 'CustomerServiceId', width: '10%' },
  { title: '客服名称', dataIndex: 'CustomerServiceName', width: '10%' },
  { title: '分票', dataIndex: 'Ticket', width: '10%' },
  { title: '受理人Id', dataIndex: 'HandlerId', width: '10%' },
  { title: '受理人名称', dataIndex: 'HandlerName', width: '10%' },
  { title: '录单人Id', dataIndex: 'EntryClerkId', width: '10%' },
  { title: '录单人名称', dataIndex: 'EntryClerkName', width: '10%' },
  { title: '修订次数', dataIndex: 'RevisionNo', width: '10%' },
  { title: '审单人Id', dataIndex: 'VerifierId', width: '10%' },
  { title: '审单人名称', dataIndex: 'VerifierName', width: '10%' },
  { title: '复核人Id', dataIndex: 'ReviewerId', width: '10%' },
  { title: '复核人名称', dataIndex: 'ReviewerName', width: '10%' },
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
        .post('/Inbox/temailorder/GetDataList', {
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
            thisObj.$http.post('/Inbox/temailorder/DeleteData', ids).then(resJson => {
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