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
                <a-select-option key="CusCiqNo">关检关联号</a-select-option>
                <a-select-option key="BillNo">提/运单号</a-select-option>
                <a-select-option key="CiqDestCode">目的地代码</a-select-option>
                <a-select-option key="CiqTrafMode">运输方式代码</a-select-option>
                <a-select-option key="TrafName">运输工具名称</a-select-option>
                <a-select-option key="CusVoyageNo">运输工具号码</a-select-option>
                <a-select-option key="CiqTradeCountryCode">贸易国别代码</a-select-option>
                <a-select-option key="CiqDespCtryCode">启运国家代码</a-select-option>
                <a-select-option key="CiqEntyPortCode">入境口岸代码</a-select-option>
                <a-select-option key="ContractNo">合同号</a-select-option>
                <a-select-option key="EntUuid">企业UUID</a-select-option>
                <a-select-option key="ConsignorCode">发货人代码</a-select-option>
                <a-select-option key="ConsignorCname">发货人名称（中文）</a-select-option>
                <a-select-option key="ConsignorEname">发货人名称（外文）</a-select-option>
                <a-select-option key="ConsignorAddr">发货人地址</a-select-option>
                <a-select-option key="ConsigneeCode">收货人代码</a-select-option>
                <a-select-option key="ConsigneeCname">收货人名称（中文）</a-select-option>
                <a-select-option key="ConsigneeEname">收货人名称（外文）</a-select-option>
                <a-select-option key="ConsigneeAddr">收货人地址</a-select-option>
                <a-select-option key="TradeModeCode">贸易方式代码</a-select-option>
                <a-select-option key="MarkNo">标记及号码</a-select-option>
                <a-select-option key="DespPortCode">启运口岸代码</a-select-option>
                <a-select-option key="PortStopCode">经停口岸代码</a-select-option>
                <a-select-option key="GoodsPlace">存放地点</a-select-option>
                <a-select-option key="DeliveryOrder">提货单号</a-select-option>
                <a-select-option key="InspOrgCode">口岸机构</a-select-option>
                <a-select-option key="InspPlaceCode">施检地代码</a-select-option>
                <a-select-option key="SpecDeclFlag">特种业务标识, 1表示勾选. 进出境都是传递4位（0或者1组成），第一位：国际赛事，第二位：特殊进出军工物资，第三位：国际援助物资，第四位：国际会议</a-select-option>
                <a-select-option key="PurpOrgCode">目的机构代码</a-select-option>
                <a-select-option key="DeclPersnCertNo">检验检疫申请员证号</a-select-option>
                <a-select-option key="DeclPersonName">检验检疫申请员姓名</a-select-option>
                <a-select-option key="Contactperson">检验检疫申请单位联系人</a-select-option>
                <a-select-option key="ContTel">检验检疫申请联系人电话</a-select-option>
                <a-select-option key="DeclCode">检验检疫申请类别代码</a-select-option>
                <a-select-option key="SpecPassFlag">特殊通关模式, 1表示勾选. 入境：直通放行 外交礼遇 转关（需要传递4位字符串，第一位：直通放行，第二位：0，第三位：外交礼遇，第四位：转关） 出境：直通放行 绿色通道 外交礼遇（需要传递3位字符串，第一位：直通放行，第二位：绿色通道，第三位：外交礼遇）</a-select-option>
                <a-select-option key="AttaCollectName">随附单据名称串</a-select-option>
                <a-select-option key="ContCancelFlag">集装箱适载核销状态</a-select-option>
                <a-select-option key="AppCertName">申请单证名称</a-select-option>
                <a-select-option key="DeclRegName">检验检疫申请单位名称</a-select-option>
                <a-select-option key="CorrelationDeclNo">关联检验检疫申请号</a-select-option>
                <a-select-option key="CorrelationReasonFlag">关联理由</a-select-option>
                <a-select-option key="SpeclInspQuraRe">特殊检验检疫要求</a-select-option>
                <a-select-option key="ArrivPortCode">到达口岸代码</a-select-option>
                <a-select-option key="SplitBillLadNo">分运单号</a-select-option>
                <a-select-option key="OrgCode">检验检疫申请地</a-select-option>
                <a-select-option key="VsaOrgCode">领证地</a-select-option>
                <a-select-option key="OrigBoxFlag">入境原集装箱装载直接到目的机构，【1：是；0：否】</a-select-option>
                <a-select-option key="CiqIEFlag">入出境标识（检验检疫）I:进境，E：出境</a-select-option>
                <a-select-option key="CopNo">企业内部编号</a-select-option>
                <a-select-option key="CustomMaster">报关海关</a-select-option>
                <a-select-option key="CustmRegNo">海关注册号</a-select-option>
                <a-select-option key="IsCopPromise">是否勾选企业承诺; 如勾选需要企业资质中增加证明或声明材料。 0：未勾选；1：勾选。</a-select-option>
                <a-select-option key="DeclareFlag">属地查检标识：5-属地查检</a-select-option>
                <a-select-option key="Unumber">Unumber</a-select-option>
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
  { title: '关检关联号', dataIndex: 'CusCiqNo', width: '10%' },
  { title: '提/运单号', dataIndex: 'BillNo', width: '10%' },
  { title: '目的地代码', dataIndex: 'CiqDestCode', width: '10%' },
  { title: '运输方式代码', dataIndex: 'CiqTrafMode', width: '10%' },
  { title: '运输工具名称', dataIndex: 'TrafName', width: '10%' },
  { title: '运输工具号码', dataIndex: 'CusVoyageNo', width: '10%' },
  { title: '贸易国别代码', dataIndex: 'CiqTradeCountryCode', width: '10%' },
  { title: '启运国家代码', dataIndex: 'CiqDespCtryCode', width: '10%' },
  { title: '入境口岸代码', dataIndex: 'CiqEntyPortCode', width: '10%' },
  { title: '合同号', dataIndex: 'ContractNo', width: '10%' },
  { title: '企业UUID', dataIndex: 'EntUuid', width: '10%' },
  { title: '发货人代码', dataIndex: 'ConsignorCode', width: '10%' },
  { title: '发货人名称（中文）', dataIndex: 'ConsignorCname', width: '10%' },
  { title: '发货人名称（外文）', dataIndex: 'ConsignorEname', width: '10%' },
  { title: '发货人地址', dataIndex: 'ConsignorAddr', width: '10%' },
  { title: '收货人代码', dataIndex: 'ConsigneeCode', width: '10%' },
  { title: '收货人名称（中文）', dataIndex: 'ConsigneeCname', width: '10%' },
  { title: '收货人名称（外文）', dataIndex: 'ConsigneeEname', width: '10%' },
  { title: '收货人地址', dataIndex: 'ConsigneeAddr', width: '10%' },
  { title: '贸易方式代码', dataIndex: 'TradeModeCode', width: '10%' },
  { title: '标记及号码', dataIndex: 'MarkNo', width: '10%' },
  { title: '启运口岸代码', dataIndex: 'DespPortCode', width: '10%' },
  { title: '经停口岸代码', dataIndex: 'PortStopCode', width: '10%' },
  { title: '存放地点', dataIndex: 'GoodsPlace', width: '10%' },
  { title: '索赔截止日期', dataIndex: 'CounterClaim', width: '10%' },
  { title: '提货单号', dataIndex: 'DeliveryOrder', width: '10%' },
  { title: '口岸机构', dataIndex: 'InspOrgCode', width: '10%' },
  { title: '施检地代码', dataIndex: 'InspPlaceCode', width: '10%' },
  { title: '特种业务标识, 1表示勾选. 进出境都是传递4位（0或者1组成），第一位：国际赛事，第二位：特殊进出军工物资，第三位：国际援助物资，第四位：国际会议', dataIndex: 'SpecDeclFlag', width: '10%' },
  { title: '目的机构代码', dataIndex: 'PurpOrgCode', width: '10%' },
  { title: '检验检疫申请员证号', dataIndex: 'DeclPersnCertNo', width: '10%' },
  { title: '检验检疫申请员姓名', dataIndex: 'DeclPersonName', width: '10%' },
  { title: '检验检疫申请单位联系人', dataIndex: 'Contactperson', width: '10%' },
  { title: '检验检疫申请联系人电话', dataIndex: 'ContTel', width: '10%' },
  { title: '检验检疫申请类别代码', dataIndex: 'DeclCode', width: '10%' },
  { title: '检验检疫申请申报日期', dataIndex: 'DeclDate', width: '10%' },
  { title: '到货日期', dataIndex: 'GdsArvlDate', width: '10%' },
  { title: '特殊通关模式, 1表示勾选. 入境：直通放行 外交礼遇 转关（需要传递4位字符串，第一位：直通放行，第二位：0，第三位：外交礼遇，第四位：转关） 出境：直通放行 绿色通道 外交礼遇（需要传递3位字符串，第一位：直通放行，第二位：绿色通道，第三位：外交礼遇）', dataIndex: 'SpecPassFlag', width: '10%' },
  { title: '入境：启运日期 出境：发货日期', dataIndex: 'DespDate', width: '10%' },
  { title: '随附单据名称串', dataIndex: 'AttaCollectName', width: '10%' },
  { title: '货物总值（美元） 申报货物为“0001”或“0002”品目的木质包装或集装箱除外的其他所有货物。', dataIndex: 'TotalValUsD', width: '10%' },
  { title: '货物总值（人民币） 申报货物为“0001”或“0002”品目的木质包装或集装箱除外的其他所有货物。', dataIndex: 'TotalValCn', width: '10%' },
  { title: '集装箱适载核销状态', dataIndex: 'ContCancelFlag', width: '10%' },
  { title: '申请单证名称', dataIndex: 'AppCertName', width: '10%' },
  { title: '检验检疫申请单位代码', dataIndex: 'DeclRegNo', width: '10%' },
  { title: '检验检疫申请单位名称', dataIndex: 'DeclRegName', width: '10%' },
  { title: '卸毕日期', dataIndex: 'CmplDschrgDt', width: '10%' },
  { title: '关联检验检疫申请号', dataIndex: 'CorrelationDeclNo', width: '10%' },
  { title: '关联理由', dataIndex: 'CorrelationReasonFlag', width: '10%' },
  { title: '特殊检验检疫要求', dataIndex: 'SpeclInspQuraRe', width: '10%' },
  { title: '到达口岸代码', dataIndex: 'ArrivPortCode', width: '10%' },
  { title: '分运单号', dataIndex: 'SplitBillLadNo', width: '10%' },
  { title: '检验检疫申请地', dataIndex: 'OrgCode', width: '10%' },
  { title: '领证地', dataIndex: 'VsaOrgCode', width: '10%' },
  { title: '入境原集装箱装载直接到目的机构，【1：是；0：否】', dataIndex: 'OrigBoxFlag', width: '10%' },
  { title: '入出境标识（检验检疫）I:进境，E：出境', dataIndex: 'CiqIEFlag', width: '10%' },
  { title: '企业内部编号', dataIndex: 'CopNo', width: '10%' },
  { title: '报关海关', dataIndex: 'CustomMaster', width: '10%' },
  { title: '海关注册号', dataIndex: 'CustmRegNo', width: '10%' },
  { title: '是否勾选企业承诺; 如勾选需要企业资质中增加证明或声明材料。 0：未勾选；1：勾选。', dataIndex: 'IsCopPromise', width: '10%' },
  { title: '属地查检标识：5-属地查检', dataIndex: 'DeclareFlag', width: '10%' },
  { title: 'Unumber', dataIndex: 'Unumber', width: '10%' },
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
        .post('/IAQ/itf_dcl_io_decl/GetDataList', {
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
            thisObj.$http.post('/IAQ/itf_dcl_io_decl/DeleteData', ids).then(resJson => {
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