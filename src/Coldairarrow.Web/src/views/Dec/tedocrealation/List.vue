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
                <a-select-option key="EdocID">文件名、随附单据编号（文件名命名规则是：申报口岸+随附单据类别代码+IM+18位流水号+.pdf）</a-select-option>
                <a-select-option key="EdocCode">随附单证类别</a-select-option>
                <a-select-option key="EdocFomatType">随附单据格式类型</a-select-option>
                <a-select-option key="OpNote">操作说明（重传原因）</a-select-option>
                <a-select-option key="EdocCopId">随附单据文件企业名</a-select-option>
                <a-select-option key="EdocOwnerCode">所属单位海关编号</a-select-option>
                <a-select-option key="SignUnit">签名单位代码</a-select-option>
                <a-select-option key="SignTime">签名时间</a-select-option>
                <a-select-option key="EdocOwnerName">所属单位名称</a-select-option>
                <a-select-option key="EdocSize">随附单据文件大小</a-select-option>
                <a-select-option key="GNoStr">商品项号关系</a-select-option>
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
  { title: '文件名、随附单据编号（文件名命名规则是：申报口岸+随附单据类别代码+IM+18位流水号+.pdf）', dataIndex: 'EdocID', width: '10%' },
  { title: '随附单证类别', dataIndex: 'EdocCode', width: '10%' },
  { title: '随附单据格式类型', dataIndex: 'EdocFomatType', width: '10%' },
  { title: '操作说明（重传原因）', dataIndex: 'OpNote', width: '10%' },
  { title: '随附单据文件企业名', dataIndex: 'EdocCopId', width: '10%' },
  { title: '所属单位海关编号', dataIndex: 'EdocOwnerCode', width: '10%' },
  { title: '签名单位代码', dataIndex: 'SignUnit', width: '10%' },
  { title: '签名时间', dataIndex: 'SignTime', width: '10%' },
  { title: '所属单位名称', dataIndex: 'EdocOwnerName', width: '10%' },
  { title: '随附单据文件大小', dataIndex: 'EdocSize', width: '10%' },
  { title: '商品项号关系', dataIndex: 'GNoStr', width: '10%' },
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
        .post('/Dec/tedocrealation/GetDataList', {
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
            thisObj.$http.post('/Dec/tedocrealation/DeleteData', ids).then(resJson => {
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