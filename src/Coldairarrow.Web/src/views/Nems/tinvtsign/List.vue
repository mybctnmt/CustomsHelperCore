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
                <a-select-option key="SeqNo">预录入统一编号</a-select-option>
                <a-select-option key="BusiType">业务类型</a-select-option>
                <a-select-option key="ChgTmsCnt">变更次数</a-select-option>
                <a-select-option key="BizopEtpsNo">经营单位海关编码</a-select-option>
                <a-select-option key="BizopEtpsSccd">经营单位社会信用代码</a-select-option>
                <a-select-option key="OwnerEtpsNo">加工单位海关编码</a-select-option>
                <a-select-option key="OwnerEtpsSccd">加工单位社会信用代码</a-select-option>
                <a-select-option key="IcCode">加签卡号</a-select-option>
                <a-select-option key="IcEtpsNo">卡用户海关编码</a-select-option>
                <a-select-option key="IcEtpsSccd">卡用户社会信用代码</a-select-option>
                <a-select-option key="SignInfo">签名信息</a-select-option>
                <a-select-option key="SignDate">签名日期</a-select-option>
                <a-select-option key="CertNo">加签证书编号</a-select-option>
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
  { title: '预录入统一编号', dataIndex: 'SeqNo', width: '10%' },
  { title: '业务类型', dataIndex: 'BusiType', width: '10%' },
  { title: '变更次数', dataIndex: 'ChgTmsCnt', width: '10%' },
  { title: '经营单位海关编码', dataIndex: 'BizopEtpsNo', width: '10%' },
  { title: '经营单位社会信用代码', dataIndex: 'BizopEtpsSccd', width: '10%' },
  { title: '加工单位海关编码', dataIndex: 'OwnerEtpsNo', width: '10%' },
  { title: '加工单位社会信用代码', dataIndex: 'OwnerEtpsSccd', width: '10%' },
  { title: '加签卡号', dataIndex: 'IcCode', width: '10%' },
  { title: '卡用户海关编码', dataIndex: 'IcEtpsNo', width: '10%' },
  { title: '卡用户社会信用代码', dataIndex: 'IcEtpsSccd', width: '10%' },
  { title: '签名信息', dataIndex: 'SignInfo', width: '10%' },
  { title: '签名日期', dataIndex: 'SignDate', width: '10%' },
  { title: '加签证书编号', dataIndex: 'CertNo', width: '10%' },
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
        .post('/Nems/tinvtsign/GetDataList', {
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
            thisObj.$http.post('/Nems/tinvtsign/DeleteData', ids).then(resJson => {
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