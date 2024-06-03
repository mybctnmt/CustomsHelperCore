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
                <a-select-option key="PricePreDeterminNo">价格预裁定编号</a-select-option>
                <a-select-option key="TaxRoyaltyDeclType">应税特许权使用费申报情形</a-select-option>
                <a-select-option key="ContractNo">合同/协议号</a-select-option>
                <a-select-option key="Authorizer">授权方</a-select-option>
                <a-select-option key="AuthorizedPerson">被授权方</a-select-option>
                <a-select-option key="PayType">支付方式</a-select-option>
                <a-select-option key="PayTime">支付时间</a-select-option>
                <a-select-option key="EffectiveDateTime">合同/协议起始执行时间</a-select-option>
                <a-select-option key="ExpirationDateTime">合同协议终止时间</a-select-option>
                <a-select-option key="Curr">币制</a-select-option>
                <a-select-option key="RoyaltyFeeType">特许权使用费类型</a-select-option>
                <a-select-option key="EdocType">随附材料清单类型</a-select-option>
                <a-select-option key="Statment">说明</a-select-option>
                <a-select-option key="IsSecret">是否保密</a-select-option>
                <a-select-option key="IsCusAudit">是否经过海关审核认定</a-select-option>
                <a-select-option key="IsCusPricePreDetermin">是否经过海关价格预裁定</a-select-option>
                <a-select-option key="IssueDateTime">合同/协议签约时间</a-select-option>
                <a-select-option key="PeriodStartDate">本次支付对应的计提周期起始时间</a-select-option>
                <a-select-option key="PeriodEndDate">本次支付对应的计提周期终止时间</a-select-option>
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
  { title: '价格预裁定编号', dataIndex: 'PricePreDeterminNo', width: '10%' },
  { title: '应税特许权使用费申报情形', dataIndex: 'TaxRoyaltyDeclType', width: '10%' },
  { title: '合同/协议号', dataIndex: 'ContractNo', width: '10%' },
  { title: '授权方', dataIndex: 'Authorizer', width: '10%' },
  { title: '被授权方', dataIndex: 'AuthorizedPerson', width: '10%' },
  { title: '支付方式', dataIndex: 'PayType', width: '10%' },
  { title: '支付时间', dataIndex: 'PayTime', width: '10%' },
  { title: '支付计提周期', dataIndex: 'PayPeriod', width: '10%' },
  { title: '合同/协议起始执行时间', dataIndex: 'EffectiveDateTime', width: '10%' },
  { title: '合同协议终止时间', dataIndex: 'ExpirationDateTime', width: '10%' },
  { title: '特许权使用费金额', dataIndex: 'RoyaltyAmount', width: '10%' },
  { title: '币制', dataIndex: 'Curr', width: '10%' },
  { title: '特许权使用费类型', dataIndex: 'RoyaltyFeeType', width: '10%' },
  { title: '随附材料清单类型', dataIndex: 'EdocType', width: '10%' },
  { title: '说明', dataIndex: 'Statment', width: '10%' },
  { title: '是否保密', dataIndex: 'IsSecret', width: '10%' },
  { title: '是否经过海关审核认定', dataIndex: 'IsCusAudit', width: '10%' },
  { title: '是否经过海关价格预裁定', dataIndex: 'IsCusPricePreDetermin', width: '10%' },
  { title: '合同/协议签约时间', dataIndex: 'IssueDateTime', width: '10%' },
  { title: '本次支付对应的计提周期起始时间', dataIndex: 'PeriodStartDate', width: '10%' },
  { title: '本次支付对应的计提周期终止时间', dataIndex: 'PeriodEndDate', width: '10%' },
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
        .post('/Dec/tdecroyaltyfee/GetDataList', {
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
            thisObj.$http.post('/Dec/tdecroyaltyfee/DeleteData', ids).then(resJson => {
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