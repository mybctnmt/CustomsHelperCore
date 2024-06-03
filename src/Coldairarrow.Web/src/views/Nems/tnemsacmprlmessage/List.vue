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
                <a-select-option key="FileName">附件文件名称</a-select-option>
                <a-select-option key="ChgTmsCnt">变更或报核次数</a-select-option>
                <a-select-option key="AcmpFormFmt">随附单证格式</a-select-option>
                <a-select-option key="BlsType">业务单证类型</a-select-option>
                <a-select-option key="AcmpFormTypeCd">随附单证类型代码</a-select-option>
                <a-select-option key="AcmpFormNo">随附单证编号</a-select-option>
                <a-select-option key="AcmpFormFileNm">随附单证文件名称</a-select-option>
                <a-select-option key="IcCardNo">上传人IC卡号</a-select-option>
                <a-select-option key="TransferTradeCode">上传单位海关编码</a-select-option>
                <a-select-option key="Rmk">备注</a-select-option>
                <a-select-option key="ModfMarkCd">修改标记代码</a-select-option>
                <a-select-option key="PocketId">包ID</a-select-option>
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
  { title: '附件文件名称', dataIndex: 'FileName', width: '10%' },
  { title: '变更或报核次数', dataIndex: 'ChgTmsCnt', width: '10%' },
  { title: '随附单证格式', dataIndex: 'AcmpFormFmt', width: '10%' },
  { title: '业务单证类型', dataIndex: 'BlsType', width: '10%' },
  { title: '随附单证序号', dataIndex: 'AcmpFormSeqNo', width: '10%' },
  { title: '随附单证类型代码', dataIndex: 'AcmpFormTypeCd', width: '10%' },
  { title: '随附单证编号', dataIndex: 'AcmpFormNo', width: '10%' },
  { title: '随附单证文件名称', dataIndex: 'AcmpFormFileNm', width: '10%' },
  { title: '清单商品序号', dataIndex: 'InvtGdsSeqNo', width: '10%' },
  { title: '上传人IC卡号', dataIndex: 'IcCardNo', width: '10%' },
  { title: '上传单位海关编码', dataIndex: 'TransferTradeCode', width: '10%' },
  { title: '备注', dataIndex: 'Rmk', width: '10%' },
  { title: '修改标记代码', dataIndex: 'ModfMarkCd', width: '10%' },
  { title: '包ID', dataIndex: 'PocketId', width: '10%' },
  { title: '当前包序号', dataIndex: 'CurPocketNo', width: '10%' },
  { title: '总包数', dataIndex: 'TotalPocketQty', width: '10%' },
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
        .post('/Nems/tnemsacmprlmessage/GetDataList', {
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
            thisObj.$http.post('/Nems/tnemsacmprlmessage/DeleteData', ids).then(resJson => {
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