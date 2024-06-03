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
                <a-select-option key="Deccus001OutBox">货物申报_发送文件</a-select-option>
                <a-select-option key="Deccus001InBox">货物申报_回执文件</a-select-option>
                <a-select-option key="Deccus001HDNBox">货物申报_回执文件备份</a-select-option>
                <a-select-option key="Deccus001HDNBoxZIP">货物申报_压缩回执文件备份</a-select-option>
                <a-select-option key="NptsOutBox">加工贸易手册_发送文件</a-select-option>
                <a-select-option key="NptsInBox">加工贸易手册_回执文件</a-select-option>
                <a-select-option key="NptsHDNBox">加工贸易手册_回执文件备份</a-select-option>
                <a-select-option key="NptsHDNBoxZIP">加工贸易手册_压缩回执文件备份</a-select-option>
                <a-select-option key="NemsOutBox">加工贸易账册_发送文件</a-select-option>
                <a-select-option key="NemsInBox">加工贸易账册_回执文件</a-select-option>
                <a-select-option key="NemsHDNBox">加工贸易账册_回执文件备份</a-select-option>
                <a-select-option key="NemsHDNBoxZIP">加工贸易账册_压缩回执文件备份</a-select-option>
                <a-select-option key="AcmpOutBox">加工贸易随附单据_发送文件</a-select-option>
                <a-select-option key="AcmpInBox">加工贸易随附单据_回执文件</a-select-option>
                <a-select-option key="AcmpHDNBox">加工贸易随附单据_回执文件备份</a-select-option>
                <a-select-option key="AcmpHDNBoxZIP">加工贸易随附单据_压缩回执文件备份</a-select-option>
                <a-select-option key="Decedoc001OutBox">随附单据_发送文件</a-select-option>
                <a-select-option key="Decedoc001InBox">随附单据_回执文件</a-select-option>
                <a-select-option key="Decedoc001HDNBox">随附单据_回执文件备份</a-select-option>
                <a-select-option key="Decedoc001HDNBoxZIP">随附单据_压缩回执文件备份</a-select-option>
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
  { title: '货物申报_发送文件', dataIndex: 'Deccus001OutBox', width: '10%' },
  { title: '货物申报_回执文件', dataIndex: 'Deccus001InBox', width: '10%' },
  { title: '货物申报_回执文件备份', dataIndex: 'Deccus001HDNBox', width: '10%' },
  { title: '货物申报_压缩回执文件备份', dataIndex: 'Deccus001HDNBoxZIP', width: '10%' },
  { title: '加工贸易手册_发送文件', dataIndex: 'NptsOutBox', width: '10%' },
  { title: '加工贸易手册_回执文件', dataIndex: 'NptsInBox', width: '10%' },
  { title: '加工贸易手册_回执文件备份', dataIndex: 'NptsHDNBox', width: '10%' },
  { title: '加工贸易手册_压缩回执文件备份', dataIndex: 'NptsHDNBoxZIP', width: '10%' },
  { title: '加工贸易账册_发送文件', dataIndex: 'NemsOutBox', width: '10%' },
  { title: '加工贸易账册_回执文件', dataIndex: 'NemsInBox', width: '10%' },
  { title: '加工贸易账册_回执文件备份', dataIndex: 'NemsHDNBox', width: '10%' },
  { title: '加工贸易账册_压缩回执文件备份', dataIndex: 'NemsHDNBoxZIP', width: '10%' },
  { title: '加工贸易随附单据_发送文件', dataIndex: 'AcmpOutBox', width: '10%' },
  { title: '加工贸易随附单据_回执文件', dataIndex: 'AcmpInBox', width: '10%' },
  { title: '加工贸易随附单据_回执文件备份', dataIndex: 'AcmpHDNBox', width: '10%' },
  { title: '加工贸易随附单据_压缩回执文件备份', dataIndex: 'AcmpHDNBoxZIP', width: '10%' },
  { title: '随附单据_发送文件', dataIndex: 'Decedoc001OutBox', width: '10%' },
  { title: '随附单据_回执文件', dataIndex: 'Decedoc001InBox', width: '10%' },
  { title: '随附单据_回执文件备份', dataIndex: 'Decedoc001HDNBox', width: '10%' },
  { title: '随附单据_压缩回执文件备份', dataIndex: 'Decedoc001HDNBoxZIP', width: '10%' },
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
        .post('/Basic/tsinglewindowsetup/GetDataList', {
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
            thisObj.$http.post('/Basic/tsinglewindowsetup/DeleteData', ids).then(resJson => {
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