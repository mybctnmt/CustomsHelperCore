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
                <a-select-option key="FileName">文件名称</a-select-option>
                <a-select-option key="SeqNo">与录入号</a-select-option>
                <a-select-option key="IEFlag">进出口标志</a-select-option>
                <a-select-option key="DeclPort">申报口岸</a-select-option>
                <a-select-option key="DDate">预计申报日期</a-select-option>
                <a-select-option key="TradeCo">境内收发货人编号</a-select-option>
                <a-select-option key="TradeName">境内收发货人名称</a-select-option>
                <a-select-option key="TradeMode">监管方式</a-select-option>
                <a-select-option key="CutMode">征免性质分类</a-select-option>
                <a-select-option key="TransMode">成交方式</a-select-option>
                <a-select-option key="FeeMark">运费标记</a-select-option>
                <a-select-option key="FeeCurr">运费币制</a-select-option>
                <a-select-option key="InsurMark">保险费标记</a-select-option>
                <a-select-option key="InsurCurr">保险费币制</a-select-option>
                <a-select-option key="OtherMark">杂费标记</a-select-option>
                <a-select-option key="OtherCurr">杂费币制</a-select-option>
                <a-select-option key="ManualNo">备案号</a-select-option>
                <a-select-option key="TradeCoScc">境内收发货人统一代码</a-select-option>
                <a-select-option key="NoteS">备注</a-select-option>
                <a-select-option key="LegalLiability">法律责任</a-select-option>
                <a-select-option key="Sign">数字签名信息</a-select-option>
                <a-select-option key="MessId">签名消息号</a-select-option>
                <a-select-option key="CertSeqNo">签名证书号</a-select-option>
                <a-select-option key="Status">状态</a-select-option>
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
  { title: '文件名称', dataIndex: 'FileName', width: '10%' },
  { title: '与录入号', dataIndex: 'SeqNo', width: '10%' },
  { title: '进出口标志', dataIndex: 'IEFlag', width: '10%' },
  { title: '申报口岸', dataIndex: 'DeclPort', width: '10%' },
  { title: '预计申报日期', dataIndex: 'DDate', width: '10%' },
  { title: '境内收发货人编号', dataIndex: 'TradeCo', width: '10%' },
  { title: '境内收发货人名称', dataIndex: 'TradeName', width: '10%' },
  { title: '内销比率', dataIndex: 'InRatio', width: '10%' },
  { title: '监管方式', dataIndex: 'TradeMode', width: '10%' },
  { title: '征免性质分类', dataIndex: 'CutMode', width: '10%' },
  { title: '成交方式', dataIndex: 'TransMode', width: '10%' },
  { title: '运费标记', dataIndex: 'FeeMark', width: '10%' },
  { title: '运费币制', dataIndex: 'FeeCurr', width: '10%' },
  { title: '运费／率', dataIndex: 'FeeRate', width: '10%' },
  { title: '保险费标记', dataIndex: 'InsurMark', width: '10%' },
  { title: '保险费币制', dataIndex: 'InsurCurr', width: '10%' },
  { title: '保险费／率', dataIndex: 'InsurRate', width: '10%' },
  { title: '杂费标记', dataIndex: 'OtherMark', width: '10%' },
  { title: '杂费币制', dataIndex: 'OtherCurr', width: '10%' },
  { title: '杂费／率', dataIndex: 'OtherRate', width: '10%' },
  { title: '备案号', dataIndex: 'ManualNo', width: '10%' },
  { title: '境内收发货人统一代码', dataIndex: 'TradeCoScc', width: '10%' },
  { title: '毛重', dataIndex: 'GrossWt', width: '10%' },
  { title: '备注', dataIndex: 'NoteS', width: '10%' },
  { title: '法律责任', dataIndex: 'LegalLiability', width: '10%' },
  { title: '数字签名信息', dataIndex: 'Sign', width: '10%' },
  { title: '签名消息号', dataIndex: 'MessId', width: '10%' },
  { title: '签名证书号', dataIndex: 'CertSeqNo', width: '10%' },
  { title: '状态', dataIndex: 'Status', width: '10%' },
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
        .post('/Dec/tsddtaxhead/GetDataList', {
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
            thisObj.$http.post('/Dec/tsddtaxhead/DeleteData', ids).then(resJson => {
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