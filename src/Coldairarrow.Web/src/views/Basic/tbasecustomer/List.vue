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
                <a-select-option key="CustomerName">客户全称</a-select-option>
                <a-select-option key="CustomerShortName">客户简称</a-select-option>
                <a-select-option key="CustomerCode">客户代码</a-select-option>
                <a-select-option key="ForeignTrade">外贸</a-select-option>
                <a-select-option key="FreightForwarder">货代</a-select-option>
                <a-select-option key="EntrustUnit">委托单位</a-select-option>
                <a-select-option key="BusinessUnit">经营单位</a-select-option>
                <a-select-option key="Consignor">发货人</a-select-option>
                <a-select-option key="Consignee">收货人</a-select-option>
                <a-select-option key="Notifier">通知人</a-select-option>
                <a-select-option key="ShippingCompany">船公司</a-select-option>
                <a-select-option key="CustomsBroker">报关行</a-select-option>
                <a-select-option key="Station">场站</a-select-option>
                <a-select-option key="Airline">航空公司</a-select-option>
                <a-select-option key="ExpressCompany">快递公司</a-select-option>
                <a-select-option key="Motorcade">车队</a-select-option>
                <a-select-option key="Other">其他</a-select-option>
                <a-select-option key="CustomsCode">海关编码</a-select-option>
                <a-select-option key="BusinessCode">业务代码</a-select-option>
                <a-select-option key="Collector">揽货人员</a-select-option>
                <a-select-option key="CustomerService">客服人员</a-select-option>
                <a-select-option key="Telephone">电话</a-select-option>
                <a-select-option key="Fax">传真</a-select-option>
                <a-select-option key="Website">网站</a-select-option>
                <a-select-option key="Address">地址</a-select-option>
                <a-select-option key="Email">邮箱</a-select-option>
                <a-select-option key="Remark">备注</a-select-option>
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
  { title: '客户全称', dataIndex: 'CustomerName', width: '10%' },
  { title: '客户简称', dataIndex: 'CustomerShortName', width: '10%' },
  { title: '客户代码', dataIndex: 'CustomerCode', width: '10%' },
  { title: '外贸', dataIndex: 'ForeignTrade', width: '10%' },
  { title: '货代', dataIndex: 'FreightForwarder', width: '10%' },
  { title: '委托单位', dataIndex: 'EntrustUnit', width: '10%' },
  { title: '经营单位', dataIndex: 'BusinessUnit', width: '10%' },
  { title: '发货人', dataIndex: 'Consignor', width: '10%' },
  { title: '收货人', dataIndex: 'Consignee', width: '10%' },
  { title: '通知人', dataIndex: 'Notifier', width: '10%' },
  { title: '船公司', dataIndex: 'ShippingCompany', width: '10%' },
  { title: '报关行', dataIndex: 'CustomsBroker', width: '10%' },
  { title: '场站', dataIndex: 'Station', width: '10%' },
  { title: '航空公司', dataIndex: 'Airline', width: '10%' },
  { title: '快递公司', dataIndex: 'ExpressCompany', width: '10%' },
  { title: '车队', dataIndex: 'Motorcade', width: '10%' },
  { title: '其他', dataIndex: 'Other', width: '10%' },
  { title: '海关编码', dataIndex: 'CustomsCode', width: '10%' },
  { title: '业务代码', dataIndex: 'BusinessCode', width: '10%' },
  { title: '揽货人员', dataIndex: 'Collector', width: '10%' },
  { title: '客服人员', dataIndex: 'CustomerService', width: '10%' },
  { title: '电话', dataIndex: 'Telephone', width: '10%' },
  { title: '传真', dataIndex: 'Fax', width: '10%' },
  { title: '网站', dataIndex: 'Website', width: '10%' },
  { title: '地址', dataIndex: 'Address', width: '10%' },
  { title: '邮箱', dataIndex: 'Email', width: '10%' },
  { title: '备注', dataIndex: 'Remark', width: '10%' },
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
        .post('/Basic/tbasecustomer/GetDataList', {
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
            thisObj.$http.post('/Basic/tbasecustomer/DeleteData', ids).then(resJson => {
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