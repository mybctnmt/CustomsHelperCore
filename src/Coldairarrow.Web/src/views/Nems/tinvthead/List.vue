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
                <a-select-option key="BondInvtNo">清单编号</a-select-option>
                <a-select-option key="SeqNo">清单预录入统一编号</a-select-option>
                <a-select-option key="PutrecNo">备案编号</a-select-option>
                <a-select-option key="EtpsInnerInvtNo">企业内部清单编号</a-select-option>
                <a-select-option key="BizopEtpsSccd">经营企业社会信用代码</a-select-option>
                <a-select-option key="BizopEtpsNo">经营企业编号</a-select-option>
                <a-select-option key="BizopEtpsNm">经营企业名称</a-select-option>
                <a-select-option key="RcvgdEtpsNo">收货企业编号</a-select-option>
                <a-select-option key="RvsngdEtpsSccd">收发货企业社会信用代码</a-select-option>
                <a-select-option key="RcvgdEtpsNm">收货企业名称</a-select-option>
                <a-select-option key="DclEtpsSccd">申报企业社会信用代码</a-select-option>
                <a-select-option key="DclEtpsNo">申报企业编号</a-select-option>
                <a-select-option key="DclEtpsNm">申报企业名称</a-select-option>
                <a-select-option key="InvtDclTime">清单申报时间</a-select-option>
                <a-select-option key="EntryDclTime">报关单申报日期</a-select-option>
                <a-select-option key="EntryNo">对应报关单编号</a-select-option>
                <a-select-option key="RltInvtNo">关联清单编号</a-select-option>
                <a-select-option key="RltPutrecNo">关联手（账）册备案编号</a-select-option>
                <a-select-option key="RltEntryNo">关联报关单编号</a-select-option>
                <a-select-option key="RltEntryBizopEtpsSccd">关联报关单境内收发货人社会信用代码</a-select-option>
                <a-select-option key="RltEntryBizopEtpsNo">关联报关单境内收发货人编号</a-select-option>
                <a-select-option key="RltEntryBizopEtpsNm">关联报关单境内收发货人名称</a-select-option>
                <a-select-option key="RltEntryRvsngdEtpsSccd">关联报关单生产销售(消费使用)单位社会统一信用代码</a-select-option>
                <a-select-option key="RltEntryRcvgdEtpsNo">关联报关单生产销售(消费使用)单位编码</a-select-option>
                <a-select-option key="RltEntryRcvgdEtpsNm">关联报关单生产销售(消费使用)单位名称</a-select-option>
                <a-select-option key="RltEntryDclEtpsSccd">关联报关单申报单位社会统一信用代码</a-select-option>
                <a-select-option key="RltEntryDclEtpsNo">关联报关单海关申报单位编码</a-select-option>
                <a-select-option key="RltEntryDclEtpsNm">关联报关单申报单位名称</a-select-option>
                <a-select-option key="ImpExpPortcd">进出境关别</a-select-option>
                <a-select-option key="DclPlcCuscd">申报地关区代码</a-select-option>
                <a-select-option key="ImpExpMarkcd">进出口标记代码</a-select-option>
                <a-select-option key="MtpckEndprdMarkcd">料件成品标记代码</a-select-option>
                <a-select-option key="SupvModecd">监管方式代码</a-select-option>
                <a-select-option key="TrspModecd">运输方式代码</a-select-option>
                <a-select-option key="DclCusFlag">是否报关标志</a-select-option>
                <a-select-option key="DclCusTypecd">报关类型代码</a-select-option>
                <a-select-option key="VrfdedMarkcd">核扣标记代码</a-select-option>
                <a-select-option key="InvtIochkptStucd">清单进出卡口状态代码</a-select-option>
                <a-select-option key="PrevdTime">预核扣时间</a-select-option>
                <a-select-option key="FormalVrfdedTime">正式核扣时间</a-select-option>
                <a-select-option key="ApplyNo">申请表编号</a-select-option>
                <a-select-option key="ListType">流转类型</a-select-option>
                <a-select-option key="InputCode">录入企业编号</a-select-option>
                <a-select-option key="InputCreditCode">录入企业社会信用代码</a-select-option>
                <a-select-option key="InputName">录入单位名称</a-select-option>
                <a-select-option key="IcCardNo">申报人IC卡号</a-select-option>
                <a-select-option key="InputTime">录入日期</a-select-option>
                <a-select-option key="ListStat">清单状态</a-select-option>
                <a-select-option key="CorrentryDclEtpssccd">对应报关单申报单位社会统一信用代码</a-select-option>
                <a-select-option key="CorrentryDclEtpsno">对应报关单申报单位代码</a-select-option>
                <a-select-option key="CorrentryDclEtpsnm">对应报关单申报单位名称</a-select-option>
                <a-select-option key="DecType">报关单类型</a-select-option>
                <a-select-option key="StshipTrsarvNatcd">起运/运抵国(地区）</a-select-option>
                <a-select-option key="InvtType">清单类型</a-select-option>
                <a-select-option key="EntryStucd">报关状态</a-select-option>
                <a-select-option key="PassPortUsedTypecd">核放单生成标志代码</a-select-option>
                <a-select-option key="DclTypecd">申报类型</a-select-option>
                <a-select-option key="NeedEntryModified">报关单同步修改标志</a-select-option>
                <a-select-option key="LevyBlAmt">计征金额</a-select-option>
                <a-select-option key="Rmk">备注</a-select-option>
                <a-select-option key="GenDecFlag">是否生成报关单</a-select-option>
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
  { title: '清单编号', dataIndex: 'BondInvtNo', width: '10%' },
  { title: '清单预录入统一编号', dataIndex: 'SeqNo', width: '10%' },
  { title: '备案编号', dataIndex: 'PutrecNo', width: '10%' },
  { title: '企业内部清单编号', dataIndex: 'EtpsInnerInvtNo', width: '10%' },
  { title: '经营企业社会信用代码', dataIndex: 'BizopEtpsSccd', width: '10%' },
  { title: '经营企业编号', dataIndex: 'BizopEtpsNo', width: '10%' },
  { title: '经营企业名称', dataIndex: 'BizopEtpsNm', width: '10%' },
  { title: '收货企业编号', dataIndex: 'RcvgdEtpsNo', width: '10%' },
  { title: '收发货企业社会信用代码', dataIndex: 'RvsngdEtpsSccd', width: '10%' },
  { title: '收货企业名称', dataIndex: 'RcvgdEtpsNm', width: '10%' },
  { title: '申报企业社会信用代码', dataIndex: 'DclEtpsSccd', width: '10%' },
  { title: '申报企业编号', dataIndex: 'DclEtpsNo', width: '10%' },
  { title: '申报企业名称', dataIndex: 'DclEtpsNm', width: '10%' },
  { title: '清单申报时间', dataIndex: 'InvtDclTime', width: '10%' },
  { title: '报关单申报日期', dataIndex: 'EntryDclTime', width: '10%' },
  { title: '对应报关单编号', dataIndex: 'EntryNo', width: '10%' },
  { title: '关联清单编号', dataIndex: 'RltInvtNo', width: '10%' },
  { title: '关联手（账）册备案编号', dataIndex: 'RltPutrecNo', width: '10%' },
  { title: '关联报关单编号', dataIndex: 'RltEntryNo', width: '10%' },
  { title: '关联报关单境内收发货人社会信用代码', dataIndex: 'RltEntryBizopEtpsSccd', width: '10%' },
  { title: '关联报关单境内收发货人编号', dataIndex: 'RltEntryBizopEtpsNo', width: '10%' },
  { title: '关联报关单境内收发货人名称', dataIndex: 'RltEntryBizopEtpsNm', width: '10%' },
  { title: '关联报关单生产销售(消费使用)单位社会统一信用代码', dataIndex: 'RltEntryRvsngdEtpsSccd', width: '10%' },
  { title: '关联报关单生产销售(消费使用)单位编码', dataIndex: 'RltEntryRcvgdEtpsNo', width: '10%' },
  { title: '关联报关单生产销售(消费使用)单位名称', dataIndex: 'RltEntryRcvgdEtpsNm', width: '10%' },
  { title: '关联报关单申报单位社会统一信用代码', dataIndex: 'RltEntryDclEtpsSccd', width: '10%' },
  { title: '关联报关单海关申报单位编码', dataIndex: 'RltEntryDclEtpsNo', width: '10%' },
  { title: '关联报关单申报单位名称', dataIndex: 'RltEntryDclEtpsNm', width: '10%' },
  { title: '进出境关别', dataIndex: 'ImpExpPortcd', width: '10%' },
  { title: '申报地关区代码', dataIndex: 'DclPlcCuscd', width: '10%' },
  { title: '进出口标记代码', dataIndex: 'ImpExpMarkcd', width: '10%' },
  { title: '料件成品标记代码', dataIndex: 'MtpckEndprdMarkcd', width: '10%' },
  { title: '监管方式代码', dataIndex: 'SupvModecd', width: '10%' },
  { title: '运输方式代码', dataIndex: 'TrspModecd', width: '10%' },
  { title: '是否报关标志', dataIndex: 'DclCusFlag', width: '10%' },
  { title: '报关类型代码', dataIndex: 'DclCusTypecd', width: '10%' },
  { title: '核扣标记代码', dataIndex: 'VrfdedMarkcd', width: '10%' },
  { title: '清单进出卡口状态代码', dataIndex: 'InvtIochkptStucd', width: '10%' },
  { title: '预核扣时间', dataIndex: 'PrevdTime', width: '10%' },
  { title: '正式核扣时间', dataIndex: 'FormalVrfdedTime', width: '10%' },
  { title: '申请表编号', dataIndex: 'ApplyNo', width: '10%' },
  { title: '流转类型', dataIndex: 'ListType', width: '10%' },
  { title: '录入企业编号', dataIndex: 'InputCode', width: '10%' },
  { title: '录入企业社会信用代码', dataIndex: 'InputCreditCode', width: '10%' },
  { title: '录入单位名称', dataIndex: 'InputName', width: '10%' },
  { title: '申报人IC卡号', dataIndex: 'IcCardNo', width: '10%' },
  { title: '录入日期', dataIndex: 'InputTime', width: '10%' },
  { title: '清单状态', dataIndex: 'ListStat', width: '10%' },
  { title: '对应报关单申报单位社会统一信用代码', dataIndex: 'CorrentryDclEtpssccd', width: '10%' },
  { title: '对应报关单申报单位代码', dataIndex: 'CorrentryDclEtpsno', width: '10%' },
  { title: '对应报关单申报单位名称', dataIndex: 'CorrentryDclEtpsnm', width: '10%' },
  { title: '报关单类型', dataIndex: 'DecType', width: '10%' },
  { title: '变更次数', dataIndex: 'ChgTmsCnt', width: '10%' },
  { title: '起运/运抵国(地区）', dataIndex: 'StshipTrsarvNatcd', width: '10%' },
  { title: '清单类型', dataIndex: 'InvtType', width: '10%' },
  { title: '报关状态', dataIndex: 'EntryStucd', width: '10%' },
  { title: '核放单生成标志代码', dataIndex: 'PassPortUsedTypecd', width: '10%' },
  { title: '申报类型', dataIndex: 'DclTypecd', width: '10%' },
  { title: '报关单同步修改标志', dataIndex: 'NeedEntryModified', width: '10%' },
  { title: '计征金额', dataIndex: 'LevyBlAmt', width: '10%' },
  { title: '备注', dataIndex: 'Rmk', width: '10%' },
  { title: '是否生成报关单', dataIndex: 'GenDecFlag', width: '10%' },
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
        .post('/Nems/tinvthead/GetDataList', {
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
            thisObj.$http.post('/Nems/tinvthead/DeleteData', ids).then(resJson => {
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