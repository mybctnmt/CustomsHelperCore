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
                <a-select-option key="id">id</a-select-option>
                <a-select-option key="catalog_id">catalog_id</a-select-option>
                <a-select-option key="chapter_id">chapter_id</a-select-option>
                <a-select-option key="code">code</a-select-option>
                <a-select-option key="name">name</a-select-option>
                <a-select-option key="criteria">criteria</a-select-option>
                <a-select-option key="legal_unit1">legal_unit1</a-select-option>
                <a-select-option key="legal_unit2">legal_unit2</a-select-option>
                <a-select-option key="import_tariff_conv">import_tariff_conv</a-select-option>
                <a-select-option key="import_tariff_norm">import_tariff_norm</a-select-option>
                <a-select-option key="import_tariff_temp">import_tariff_temp</a-select-option>
                <a-select-option key="consumption_rate">consumption_rate</a-select-option>
                <a-select-option key="export_tariff">export_tariff</a-select-option>
                <a-select-option key="export_tariff_temp">export_tariff_temp</a-select-option>
                <a-select-option key="export_rebate_rate">export_rebate_rate</a-select-option>
                <a-select-option key="VAT">VAT</a-select-option>
                <a-select-option key="cust_supervision_cond">cust_supervision_cond</a-select-option>
                <a-select-option key="ins_quaran_type">ins_quaran_type</a-select-option>
                <a-select-option key="desc">desc</a-select-option>
                <a-select-option key="desc_en">desc_en</a-select-option>
                <a-select-option key="catalog_title">catalog_title</a-select-option>
                <a-select-option key="chapter_title">chapter_title</a-select-option>
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
  { title: 'id', dataIndex: 'id', width: '10%' },
  { title: 'catalog_id', dataIndex: 'catalog_id', width: '10%' },
  { title: 'chapter_id', dataIndex: 'chapter_id', width: '10%' },
  { title: 'code', dataIndex: 'code', width: '10%' },
  { title: 'name', dataIndex: 'name', width: '10%' },
  { title: 'criteria', dataIndex: 'criteria', width: '10%' },
  { title: 'legal_unit1', dataIndex: 'legal_unit1', width: '10%' },
  { title: 'legal_unit2', dataIndex: 'legal_unit2', width: '10%' },
  { title: 'import_tariff_conv', dataIndex: 'import_tariff_conv', width: '10%' },
  { title: 'import_tariff_norm', dataIndex: 'import_tariff_norm', width: '10%' },
  { title: 'import_tariff_temp', dataIndex: 'import_tariff_temp', width: '10%' },
  { title: 'consumption_rate', dataIndex: 'consumption_rate', width: '10%' },
  { title: 'export_tariff', dataIndex: 'export_tariff', width: '10%' },
  { title: 'export_tariff_temp', dataIndex: 'export_tariff_temp', width: '10%' },
  { title: 'export_rebate_rate', dataIndex: 'export_rebate_rate', width: '10%' },
  { title: 'VAT', dataIndex: 'VAT', width: '10%' },
  { title: 'cust_supervision_cond', dataIndex: 'cust_supervision_cond', width: '10%' },
  { title: 'ins_quaran_type', dataIndex: 'ins_quaran_type', width: '10%' },
  { title: 'desc', dataIndex: 'desc', width: '10%' },
  { title: 'desc_en', dataIndex: 'desc_en', width: '10%' },
  { title: 'catalog_title', dataIndex: 'catalog_title', width: '10%' },
  { title: 'chapter_title', dataIndex: 'chapter_title', width: '10%' },
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
        .post('/Basic/thscodedesc/GetDataList', {
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
            thisObj.$http.post('/Basic/thscodedesc/DeleteData', ids).then(resJson => {
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