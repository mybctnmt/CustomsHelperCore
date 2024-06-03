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
                <a-select-option key="AgentCode">申报单位代码</a-select-option>
                <a-select-option key="AgentName">申报单位名称</a-select-option>
                <a-select-option key="ApprNo">批准文号</a-select-option>
                <a-select-option key="BillNo">提单号</a-select-option>
                <a-select-option key="ContrNo">合同号</a-select-option>
                <a-select-option key="CopCode">录入单位代码</a-select-option>
                <a-select-option key="CopName">录入单位名称</a-select-option>
                <a-select-option key="CustomMaster">主管海关（申报地海关）</a-select-option>
                <a-select-option key="CutMode">征免性质</a-select-option>
                <a-select-option key="DataSource">扩展字段</a-select-option>
                <a-select-option key="DeclTrnRel">报关/转关关系标志</a-select-option>
                <a-select-option key="DistinatePort">经停港/指运港</a-select-option>
                <a-select-option key="EdiId">报关标志</a-select-option>
                <a-select-option key="EntryId">海关编号</a-select-option>
                <a-select-option key="EntryType">报关单类型</a-select-option>
                <a-select-option key="FeeCurr">运费币制</a-select-option>
                <a-select-option key="FeeMark">运费标记</a-select-option>
                <a-select-option key="IEDate">进出口日期</a-select-option>
                <a-select-option key="IEFlag">进出口标志</a-select-option>
                <a-select-option key="IEPort">进出境关别</a-select-option>
                <a-select-option key="InputerName">录入员名称</a-select-option>
                <a-select-option key="InsurCurr">保险费币制</a-select-option>
                <a-select-option key="InsurMark">保险费标记</a-select-option>
                <a-select-option key="LicenseNo">许可证编号</a-select-option>
                <a-select-option key="ManualNo">备案号</a-select-option>
                <a-select-option key="NoteS">备注</a-select-option>
                <a-select-option key="OtherCurr">杂费币制</a-select-option>
                <a-select-option key="OtherMark">杂费标志</a-select-option>
                <a-select-option key="OwnerCode">消费使用/生产销售单位代码</a-select-option>
                <a-select-option key="OwnerName">消费使用/生产销售单位名称</a-select-option>
                <a-select-option key="PartenerID">申报人标识</a-select-option>
                <a-select-option key="PDate">打印日期</a-select-option>
                <a-select-option key="PreEntryId">预录入编号</a-select-option>
                <a-select-option key="Risk">风险评估参数</a-select-option>
                <a-select-option key="SeqNo">数据中心统一编号</a-select-option>
                <a-select-option key="TgdNo">关联单据号</a-select-option>
                <a-select-option key="TradeCountry">启运国/运抵国</a-select-option>
                <a-select-option key="TradeMode">监管方式</a-select-option>
                <a-select-option key="TradeCode">境内收发货人编号</a-select-option>
                <a-select-option key="TrafMode">运输方式代码</a-select-option>
                <a-select-option key="TrafName">运输工具代码及名称</a-select-option>
                <a-select-option key="TradeName">境内收发货人名称</a-select-option>
                <a-select-option key="TransMode">成交方式</a-select-option>
                <a-select-option key="Type">单据类型</a-select-option>
                <a-select-option key="TypistNo">录入员IC卡号</a-select-option>
                <a-select-option key="WrapType">包装种类</a-select-option>
                <a-select-option key="ChkSurety">担保验放标志</a-select-option>
                <a-select-option key="BillType">备案清单类型</a-select-option>
                <a-select-option key="CopCodeScc">录入单位统一编码</a-select-option>
                <a-select-option key="TradeCoScc">收发货人统一编码</a-select-option>
                <a-select-option key="AgentCodeScc">申报代码统一编码</a-select-option>
                <a-select-option key="OwnerCodeScc">消费使用/生产销售单位单位统一编码</a-select-option>
                <a-select-option key="PromiseItmes">价格说明</a-select-option>
                <a-select-option key="TradeAreaCode">贸易国别</a-select-option>
                <a-select-option key="CheckFlow">查验分流</a-select-option>
                <a-select-option key="TaxAaminMark">税收征管标记</a-select-option>
                <a-select-option key="MarkNo">标记唛码</a-select-option>
                <a-select-option key="DespPortCode">启运港代码</a-select-option>
                <a-select-option key="EntyPortCode">入境口岸代码</a-select-option>
                <a-select-option key="GoodsPlace">存放地点</a-select-option>
                <a-select-option key="BLNo">B/L号</a-select-option>
                <a-select-option key="InspOrgCode">口岸检验检疫机关</a-select-option>
                <a-select-option key="SpecDeclFlag">特种业务标识</a-select-option>
                <a-select-option key="PurpOrgCode">目的地检验检疫机关</a-select-option>
                <a-select-option key="DespDate">启运日期</a-select-option>
                <a-select-option key="CmplDschrgDt">卸毕日期</a-select-option>
                <a-select-option key="CorrelationReasonFlag">关联理由</a-select-option>
                <a-select-option key="VsaOrgCode">领证机关</a-select-option>
                <a-select-option key="OrigBoxFlag">原集装箱标识</a-select-option>
                <a-select-option key="DeclareName">申报人员姓名</a-select-option>
                <a-select-option key="NoOtherPack">无其他包装</a-select-option>
                <a-select-option key="OrgCode">检验检疫受理机关</a-select-option>
                <a-select-option key="OverseasConsignorCode">境外发货人代码</a-select-option>
                <a-select-option key="OverseasConsignorCname">境外收发货人名称</a-select-option>
                <a-select-option key="OverseasConsignorEname">境外发货人名称（外文）</a-select-option>
                <a-select-option key="OverseasConsignorAddr">境外收发货人地址</a-select-option>
                <a-select-option key="OverseasConsigneeCode">境外收货人编码</a-select-option>
                <a-select-option key="OverseasConsigneeEname">境外收货人名称(外文)</a-select-option>
                <a-select-option key="DomesticConsigneeEname">境内收发货人名称（外文）</a-select-option>
                <a-select-option key="CorrelationNo">关联号码</a-select-option>
                <a-select-option key="EdiRemark">EDI申报备注</a-select-option>
                <a-select-option key="EdiRemark2">EDI申报备注2</a-select-option>
                <a-select-option key="TradeCiqCode">境内收发货人检验检疫编码</a-select-option>
                <a-select-option key="OwnerCiqCode">消费使用/生产销售单位检验检疫编码</a-select-option>
                <a-select-option key="DeclCiqCode">申报单位检验检疫编码</a-select-option>
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
  { title: '申报单位代码', dataIndex: 'AgentCode', width: '10%' },
  { title: '申报单位名称', dataIndex: 'AgentName', width: '10%' },
  { title: '批准文号', dataIndex: 'ApprNo', width: '10%' },
  { title: '提单号', dataIndex: 'BillNo', width: '10%' },
  { title: '合同号', dataIndex: 'ContrNo', width: '10%' },
  { title: '录入单位代码', dataIndex: 'CopCode', width: '10%' },
  { title: '录入单位名称', dataIndex: 'CopName', width: '10%' },
  { title: '主管海关（申报地海关）', dataIndex: 'CustomMaster', width: '10%' },
  { title: '征免性质', dataIndex: 'CutMode', width: '10%' },
  { title: '扩展字段', dataIndex: 'DataSource', width: '10%' },
  { title: '报关/转关关系标志', dataIndex: 'DeclTrnRel', width: '10%' },
  { title: '经停港/指运港', dataIndex: 'DistinatePort', width: '10%' },
  { title: '报关标志', dataIndex: 'EdiId', width: '10%' },
  { title: '海关编号', dataIndex: 'EntryId', width: '10%' },
  { title: '报关单类型', dataIndex: 'EntryType', width: '10%' },
  { title: '运费币制', dataIndex: 'FeeCurr', width: '10%' },
  { title: '运费标记', dataIndex: 'FeeMark', width: '10%' },
  { title: '运费／率', dataIndex: 'FeeRate', width: '10%' },
  { title: '毛重', dataIndex: 'GrossWet', width: '10%' },
  { title: '进出口日期', dataIndex: 'IEDate', width: '10%' },
  { title: '进出口标志', dataIndex: 'IEFlag', width: '10%' },
  { title: '进出境关别', dataIndex: 'IEPort', width: '10%' },
  { title: '录入员名称', dataIndex: 'InputerName', width: '10%' },
  { title: '保险费币制', dataIndex: 'InsurCurr', width: '10%' },
  { title: '保险费标记', dataIndex: 'InsurMark', width: '10%' },
  { title: '保险费／率', dataIndex: 'InsurRate', width: '10%' },
  { title: '许可证编号', dataIndex: 'LicenseNo', width: '10%' },
  { title: '备案号', dataIndex: 'ManualNo', width: '10%' },
  { title: '净重', dataIndex: 'NetWt', width: '10%' },
  { title: '备注', dataIndex: 'NoteS', width: '10%' },
  { title: '杂费币制', dataIndex: 'OtherCurr', width: '10%' },
  { title: '杂费标志', dataIndex: 'OtherMark', width: '10%' },
  { title: '杂费／率', dataIndex: 'OtherRate', width: '10%' },
  { title: '消费使用/生产销售单位代码', dataIndex: 'OwnerCode', width: '10%' },
  { title: '消费使用/生产销售单位名称', dataIndex: 'OwnerName', width: '10%' },
  { title: '件数', dataIndex: 'PackNo', width: '10%' },
  { title: '申报人标识', dataIndex: 'PartenerID', width: '10%' },
  { title: '打印日期', dataIndex: 'PDate', width: '10%' },
  { title: '预录入编号', dataIndex: 'PreEntryId', width: '10%' },
  { title: '风险评估参数', dataIndex: 'Risk', width: '10%' },
  { title: '数据中心统一编号', dataIndex: 'SeqNo', width: '10%' },
  { title: '关联单据号', dataIndex: 'TgdNo', width: '10%' },
  { title: '启运国/运抵国', dataIndex: 'TradeCountry', width: '10%' },
  { title: '监管方式', dataIndex: 'TradeMode', width: '10%' },
  { title: '境内收发货人编号', dataIndex: 'TradeCode', width: '10%' },
  { title: '运输方式代码', dataIndex: 'TrafMode', width: '10%' },
  { title: '运输工具代码及名称', dataIndex: 'TrafName', width: '10%' },
  { title: '境内收发货人名称', dataIndex: 'TradeName', width: '10%' },
  { title: '成交方式', dataIndex: 'TransMode', width: '10%' },
  { title: '单据类型', dataIndex: 'Type', width: '10%' },
  { title: '录入员IC卡号', dataIndex: 'TypistNo', width: '10%' },
  { title: '包装种类', dataIndex: 'WrapType', width: '10%' },
  { title: '担保验放标志', dataIndex: 'ChkSurety', width: '10%' },
  { title: '备案清单类型', dataIndex: 'BillType', width: '10%' },
  { title: '录入单位统一编码', dataIndex: 'CopCodeScc', width: '10%' },
  { title: '收发货人统一编码', dataIndex: 'TradeCoScc', width: '10%' },
  { title: '申报代码统一编码', dataIndex: 'AgentCodeScc', width: '10%' },
  { title: '消费使用/生产销售单位单位统一编码', dataIndex: 'OwnerCodeScc', width: '10%' },
  { title: '价格说明', dataIndex: 'PromiseItmes', width: '10%' },
  { title: '贸易国别', dataIndex: 'TradeAreaCode', width: '10%' },
  { title: '查验分流', dataIndex: 'CheckFlow', width: '10%' },
  { title: '税收征管标记', dataIndex: 'TaxAaminMark', width: '10%' },
  { title: '标记唛码', dataIndex: 'MarkNo', width: '10%' },
  { title: '启运港代码', dataIndex: 'DespPortCode', width: '10%' },
  { title: '入境口岸代码', dataIndex: 'EntyPortCode', width: '10%' },
  { title: '存放地点', dataIndex: 'GoodsPlace', width: '10%' },
  { title: 'B/L号', dataIndex: 'BLNo', width: '10%' },
  { title: '口岸检验检疫机关', dataIndex: 'InspOrgCode', width: '10%' },
  { title: '特种业务标识', dataIndex: 'SpecDeclFlag', width: '10%' },
  { title: '目的地检验检疫机关', dataIndex: 'PurpOrgCode', width: '10%' },
  { title: '启运日期', dataIndex: 'DespDate', width: '10%' },
  { title: '卸毕日期', dataIndex: 'CmplDschrgDt', width: '10%' },
  { title: '关联理由', dataIndex: 'CorrelationReasonFlag', width: '10%' },
  { title: '领证机关', dataIndex: 'VsaOrgCode', width: '10%' },
  { title: '原集装箱标识', dataIndex: 'OrigBoxFlag', width: '10%' },
  { title: '申报人员姓名', dataIndex: 'DeclareName', width: '10%' },
  { title: '无其他包装', dataIndex: 'NoOtherPack', width: '10%' },
  { title: '检验检疫受理机关', dataIndex: 'OrgCode', width: '10%' },
  { title: '境外发货人代码', dataIndex: 'OverseasConsignorCode', width: '10%' },
  { title: '境外收发货人名称', dataIndex: 'OverseasConsignorCname', width: '10%' },
  { title: '境外发货人名称（外文）', dataIndex: 'OverseasConsignorEname', width: '10%' },
  { title: '境外收发货人地址', dataIndex: 'OverseasConsignorAddr', width: '10%' },
  { title: '境外收货人编码', dataIndex: 'OverseasConsigneeCode', width: '10%' },
  { title: '境外收货人名称(外文)', dataIndex: 'OverseasConsigneeEname', width: '10%' },
  { title: '境内收发货人名称（外文）', dataIndex: 'DomesticConsigneeEname', width: '10%' },
  { title: '关联号码', dataIndex: 'CorrelationNo', width: '10%' },
  { title: 'EDI申报备注', dataIndex: 'EdiRemark', width: '10%' },
  { title: 'EDI申报备注2', dataIndex: 'EdiRemark2', width: '10%' },
  { title: '境内收发货人检验检疫编码', dataIndex: 'TradeCiqCode', width: '10%' },
  { title: '消费使用/生产销售单位检验检疫编码', dataIndex: 'OwnerCiqCode', width: '10%' },
  { title: '申报单位检验检疫编码', dataIndex: 'DeclCiqCode', width: '10%' },
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
        .post('/Dec/tdechead/GetDataList', {
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
            thisObj.$http.post('/Dec/tdechead/DeleteData', ids).then(resJson => {
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