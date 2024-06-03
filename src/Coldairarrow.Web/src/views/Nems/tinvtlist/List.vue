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
                <a-select-option key="SeqNo">中心统一编号</a-select-option>
                <a-select-option key="GdsMtno">商品料号</a-select-option>
                <a-select-option key="Gdecd">商品编码</a-select-option>
                <a-select-option key="GdsNm">商品名称</a-select-option>
                <a-select-option key="GdsSpcfModelDesc">商品规格型号</a-select-option>
                <a-select-option key="DclUnitcd">申报计量单位</a-select-option>
                <a-select-option key="LawfUnitcd">法定计量单位</a-select-option>
                <a-select-option key="SecdLawfUnitcd">法定第二计量</a-select-option>
                <a-select-option key="Natcd">原产国(地区)</a-select-option>
                <a-select-option key="DclCurrcd">币制</a-select-option>
                <a-select-option key="UseCd">用途代码</a-select-option>
                <a-select-option key="LvyrlfModecd">征免方式</a-select-option>
                <a-select-option key="UcnsVerno">单耗版本号</a-select-option>
                <a-select-option key="ClyMarkcd">归类标志</a-select-option>
                <a-select-option key="DestinationNatcd">最终目的国(地区)</a-select-option>
                <a-select-option key="ModfMarkcd">修改标志</a-select-option>
                <a-select-option key="Rmk">备注</a-select-option>
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
  { title: '中心统一编号', dataIndex: 'SeqNo', width: '10%' },
  { title: '商品序号', dataIndex: 'GdsSeqNo', width: '10%' },
  { title: '备案序号(对应底账序号）', dataIndex: 'PutrecSeqNo', width: '10%' },
  { title: '商品料号', dataIndex: 'GdsMtno', width: '10%' },
  { title: '商品编码', dataIndex: 'Gdecd', width: '10%' },
  { title: '商品名称', dataIndex: 'GdsNm', width: '10%' },
  { title: '商品规格型号', dataIndex: 'GdsSpcfModelDesc', width: '10%' },
  { title: '申报计量单位', dataIndex: 'DclUnitcd', width: '10%' },
  { title: '法定计量单位', dataIndex: 'LawfUnitcd', width: '10%' },
  { title: '法定第二计量', dataIndex: 'SecdLawfUnitcd', width: '10%' },
  { title: '原产国(地区)', dataIndex: 'Natcd', width: '10%' },
  { title: '企业申报单价', dataIndex: 'DclUprcAmt', width: '10%' },
  { title: '企业申报总价', dataIndex: 'DclTotalAmt', width: '10%' },
  { title: '美元统计总金额', dataIndex: 'UsdStatTotalAmt', width: '10%' },
  { title: '币制', dataIndex: 'DclCurrcd', width: '10%' },
  { title: '法定数量', dataIndex: 'LawfQty', width: '10%' },
  { title: '第二法定数量', dataIndex: 'SecdLawfQty', width: '10%' },
  { title: '重量比例因子', dataIndex: 'WtSfval', width: '10%' },
  { title: '第一比例因子', dataIndex: 'FstSfval', width: '10%' },
  { title: '第二比例因子', dataIndex: 'SecdSfval', width: '10%' },
  { title: '申报数量', dataIndex: 'DclQty', width: '10%' },
  { title: '毛重', dataIndex: 'GrossWt', width: '10%' },
  { title: '净重', dataIndex: 'NetWt', width: '10%' },
  { title: '用途代码', dataIndex: 'UseCd', width: '10%' },
  { title: '征免方式', dataIndex: 'LvyrlfModecd', width: '10%' },
  { title: '单耗版本号', dataIndex: 'UcnsVerno', width: '10%' },
  { title: '报关单商品序号', dataIndex: 'EntryGdsSeqno', width: '10%' },
  { title: '归类标志', dataIndex: 'ClyMarkcd', width: '10%' },
  { title: '流转申报表序号', dataIndex: 'ApplyTbSeqno', width: '10%' },
  { title: '最终目的国(地区)', dataIndex: 'DestinationNatcd', width: '10%' },
  { title: '修改标志', dataIndex: 'ModfMarkcd', width: '10%' },
  { title: '备注', dataIndex: 'Rmk', width: '10%' },
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
        .post('/Nems/tinvtlist/GetDataList', {
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
            thisObj.$http.post('/Nems/tinvtlist/DeleteData', ids).then(resJson => {
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