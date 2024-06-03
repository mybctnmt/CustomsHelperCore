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
                <a-select-option key="codets">codets</a-select-option>
                <a-select-option key="controlMark">controlMark</a-select-option>
                <a-select-option key="unitFlag">unitFlag</a-select-option>
                <a-select-option key="ciqWtMeasUnit">ciqWtMeasUnit</a-select-option>
                <a-select-option key="ciqWtMeasUnitName">ciqWtMeasUnitName</a-select-option>
                <a-select-option key="gname">gname</a-select-option>
                <a-select-option key="unit1">unit1</a-select-option>
                <a-select-option key="dangerFlag">dangerFlag</a-select-option>
                <a-select-option key="unit1Name">unit1Name</a-select-option>
                <a-select-option key="unit2">unit2</a-select-option>
                <a-select-option key="outDutyTypeFlag">outDutyTypeFlag</a-select-option>
                <a-select-option key="inspMonitorCond">inspMonitorCond</a-select-option>
                <a-select-option key="ciqQtyMeasUnitName">ciqQtyMeasUnitName</a-select-option>
                <a-select-option key="ciqQtyMeasUnit">ciqQtyMeasUnit</a-select-option>
                <a-select-option key="noteS">noteS</a-select-option>
                <a-select-option key="unit2Name">unit2Name</a-select-option>
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
  { title: 'codets', dataIndex: 'codets', width: '10%' },
  { title: 'controlMark', dataIndex: 'controlMark', width: '10%' },
  { title: 'unitFlag', dataIndex: 'unitFlag', width: '10%' },
  { title: 'ciqWtMeasUnit', dataIndex: 'ciqWtMeasUnit', width: '10%' },
  { title: 'ciqWtMeasUnitName', dataIndex: 'ciqWtMeasUnitName', width: '10%' },
  { title: 'gname', dataIndex: 'gname', width: '10%' },
  { title: 'unit1', dataIndex: 'unit1', width: '10%' },
  { title: 'dangerFlag', dataIndex: 'dangerFlag', width: '10%' },
  { title: 'unit1Name', dataIndex: 'unit1Name', width: '10%' },
  { title: 'unit2', dataIndex: 'unit2', width: '10%' },
  { title: 'outDutyTypeFlag', dataIndex: 'outDutyTypeFlag', width: '10%' },
  { title: 'inspMonitorCond', dataIndex: 'inspMonitorCond', width: '10%' },
  { title: 'ciqQtyMeasUnitName', dataIndex: 'ciqQtyMeasUnitName', width: '10%' },
  { title: 'ciqQtyMeasUnit', dataIndex: 'ciqQtyMeasUnit', width: '10%' },
  { title: 'noteS', dataIndex: 'noteS', width: '10%' },
  { title: 'unit2Name', dataIndex: 'unit2Name', width: '10%' },
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
        .post('/Basic/tbasehscodeinfo/GetDataList', {
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
            thisObj.$http.post('/Basic/tbasehscodeinfo/DeleteData', ids).then(resJson => {
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