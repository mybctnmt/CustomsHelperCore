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
                <a-select-option key="TrnPreId">转关单统一编号</a-select-option>
                <a-select-option key="TransNo">载货清单号</a-select-option>
                <a-select-option key="TurnNo">转关申报单号</a-select-option>
                <a-select-option key="NativeTrafMode">境内运输方式</a-select-option>
                <a-select-option key="TrafCustomsNo">境内运输工具编号</a-select-option>
                <a-select-option key="NativeShipName">境内运输工具名称</a-select-option>
                <a-select-option key="NativeVoyageNo">境内运输工具航次</a-select-option>
                <a-select-option key="ContractorName">承运单位名称</a-select-option>
                <a-select-option key="ContractorCode">承运单位组织机构代码</a-select-option>
                <a-select-option key="TransFlag">转关类型</a-select-option>
                <a-select-option key="ValidTime">预计运抵指运地时间</a-select-option>
                <a-select-option key="ESealFlag">是否启用电子关锁标志</a-select-option>
                <a-select-option key="Notes">备注</a-select-option>
                <a-select-option key="TrnType">转关单类型</a-select-option>
                <a-select-option key="ApplCodeScc">转关申报单位统一代码</a-select-option>
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
  { title: '转关单统一编号', dataIndex: 'TrnPreId', width: '10%' },
  { title: '载货清单号', dataIndex: 'TransNo', width: '10%' },
  { title: '转关申报单号', dataIndex: 'TurnNo', width: '10%' },
  { title: '境内运输方式', dataIndex: 'NativeTrafMode', width: '10%' },
  { title: '境内运输工具编号', dataIndex: 'TrafCustomsNo', width: '10%' },
  { title: '境内运输工具名称', dataIndex: 'NativeShipName', width: '10%' },
  { title: '境内运输工具航次', dataIndex: 'NativeVoyageNo', width: '10%' },
  { title: '承运单位名称', dataIndex: 'ContractorName', width: '10%' },
  { title: '承运单位组织机构代码', dataIndex: 'ContractorCode', width: '10%' },
  { title: '转关类型', dataIndex: 'TransFlag', width: '10%' },
  { title: '预计运抵指运地时间', dataIndex: 'ValidTime', width: '10%' },
  { title: '是否启用电子关锁标志', dataIndex: 'ESealFlag', width: '10%' },
  { title: '备注', dataIndex: 'Notes', width: '10%' },
  { title: '转关单类型', dataIndex: 'TrnType', width: '10%' },
  { title: '转关申报单位统一代码', dataIndex: 'ApplCodeScc', width: '10%' },
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
        .post('/Dec/ttrnhead/GetDataList', {
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
            thisObj.$http.post('/Dec/ttrnhead/DeleteData', ids).then(resJson => {
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