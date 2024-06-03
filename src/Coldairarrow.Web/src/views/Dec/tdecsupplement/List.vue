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
                <a-select-option key="SupType">补充申报单类型</a-select-option>
                <a-select-option key="BrandCN">品牌中文</a-select-option>
                <a-select-option key="BrandEN">品牌英文</a-select-option>
                <a-select-option key="Buyer">买方名称</a-select-option>
                <a-select-option key="BuyerContact">买方联系人</a-select-option>
                <a-select-option key="BuyerAddr">买方地址</a-select-option>
                <a-select-option key="BuyerTel">买方电话</a-select-option>
                <a-select-option key="Seller">卖方名称</a-select-option>
                <a-select-option key="SellerContact">卖方联系人</a-select-option>
                <a-select-option key="SellerAddr">卖方地址</a-select-option>
                <a-select-option key="SellerTel">卖方电话</a-select-option>
                <a-select-option key="Factory">生产厂商名称</a-select-option>
                <a-select-option key="FactoryContact">生产厂商联系人</a-select-option>
                <a-select-option key="FactoryAddr">生产厂商地址</a-select-option>
                <a-select-option key="FactoryTel">生产厂商电话</a-select-option>
                <a-select-option key="ContrNo">合同协议号</a-select-option>
                <a-select-option key="ContrDate">签约日期</a-select-option>
                <a-select-option key="InvoiceNo">发票编号</a-select-option>
                <a-select-option key="InvoiceDate">发票日期</a-select-option>
                <a-select-option key="I_BabRel">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_PriceEffect">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_PriceClose">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_OtherLimited">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_OtherEffect">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_Note1">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_IsUsefee">价格申报项，进口货物申报项。</a-select-option>
                <a-select-option key="I_IsProfit">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="I_Note2">价格申报项，进口货物申报项</a-select-option>
                <a-select-option key="Curr">价格申报项，币制</a-select-option>
                <a-select-option key="InvoiceNote">价格申报项，发票价格备注</a-select-option>
                <a-select-option key="GoodsNote">价格申报项，间接支付/收取的货款备注，进口是间接支付，出口是间接收取</a-select-option>
                <a-select-option key="I_CommissionNote">价格申报项，进口货物除购货佣金以外的佣金和经纪费备注</a-select-option>
                <a-select-option key="I_ContainerNote">价格申报项，与该进口货物视为一体的容器费用备注</a-select-option>
                <a-select-option key="I_PackNote">价格申报项，进口货物包装材料和包装劳务费用备注</a-select-option>
                <a-select-option key="I_PartNote">价格申报项，进口货物包含的材料、部件、零件和类似货物备注</a-select-option>
                <a-select-option key="I_ToolNote">价格申报项，在生产进口货物过程中使用的工具、模具和类似货物备注</a-select-option>
                <a-select-option key="I_LossNote">价格申报项，在生产进口货物过程中消耗的材料备注</a-select-option>
                <a-select-option key="I_DesignNote">价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务备注</a-select-option>
                <a-select-option key="I_UsefeeNote">价格申报项，特许权使用费备注</a-select-option>
                <a-select-option key="I_ProfitNote">价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益备注</a-select-option>
                <a-select-option key="I_FeeNote">价格申报项，进口货物运输费用备注</a-select-option>
                <a-select-option key="I_OtherNote">价格申报项，进口货物运输相关费用备注</a-select-option>
                <a-select-option key="I_InsurNote">价格申报项，进口货物保险费备注</a-select-option>
                <a-select-option key="E_IsDutyDel">价格申报项，出口关税是否已经从申报价格中扣除</a-select-option>
                <a-select-option key="GNameOther">归类申报项，商品其他名称</a-select-option>
                <a-select-option key="CodeTsOther">归类申报项，进/出口国地区海关商品编码</a-select-option>
                <a-select-option key="IsClassDecision">归类申报项</a-select-option>
                <a-select-option key="DecisionNO">归类申报项，预归类决定书编号</a-select-option>
                <a-select-option key="CodeTsDecision">归类申报项，预归类决定书商品编码</a-select-option>
                <a-select-option key="DecisionCus">归类申报项，作出预归类决定的直属海关</a-select-option>
                <a-select-option key="IsSampleTest">归类申报项，该商品是否曾被海关取样化验</a-select-option>
                <a-select-option key="GOptions">GOptions</a-select-option>
                <a-select-option key="TrafMode">运输方式</a-select-option>
                <a-select-option key="IsDirectTraf">原产地申报项，是否直接运输</a-select-option>
                <a-select-option key="TransitCountry">原产地申报项，中转国地区，如果选择非直接运输，必填</a-select-option>
                <a-select-option key="DestPort">原产地申报项，到货口岸</a-select-option>
                <a-select-option key="DeclPort">原产地申报项，申报口岸</a-select-option>
                <a-select-option key="BillNo">原产地申报项，提单编号</a-select-option>
                <a-select-option key="OriginCountry">原产地申报项</a-select-option>
                <a-select-option key="OriginMark">原产地申报项，原产国地区标记的位置</a-select-option>
                <a-select-option key="CertCountry">原产地申报项，原产地证书签发机构及所在国家地区，非参数选项，可录入汉字或字母</a-select-option>
                <a-select-option key="CertNO">原产地申报项，原产地证书编号</a-select-option>
                <a-select-option key="CertStandard">原产地申报项，适用的原产地标准</a-select-option>
                <a-select-option key="OtherNote">公共申报项，其他需要说明的情况</a-select-option>
                <a-select-option key="IsSecret">对以上申报内容是否需要海关予以保密</a-select-option>
                <a-select-option key="AgentType">申报单位类型</a-select-option>
                <a-select-option key="DeclAddr">申报人单位地址</a-select-option>
                <a-select-option key="DeclPost">申报人邮编</a-select-option>
                <a-select-option key="DeclTel">申报人电话</a-select-option>
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
  { title: '补充申报单商品序号', dataIndex: 'GNo', width: '10%' },
  { title: '补充申报单类型', dataIndex: 'SupType', width: '10%' },
  { title: '品牌中文', dataIndex: 'BrandCN', width: '10%' },
  { title: '品牌英文', dataIndex: 'BrandEN', width: '10%' },
  { title: '买方名称', dataIndex: 'Buyer', width: '10%' },
  { title: '买方联系人', dataIndex: 'BuyerContact', width: '10%' },
  { title: '买方地址', dataIndex: 'BuyerAddr', width: '10%' },
  { title: '买方电话', dataIndex: 'BuyerTel', width: '10%' },
  { title: '卖方名称', dataIndex: 'Seller', width: '10%' },
  { title: '卖方联系人', dataIndex: 'SellerContact', width: '10%' },
  { title: '卖方地址', dataIndex: 'SellerAddr', width: '10%' },
  { title: '卖方电话', dataIndex: 'SellerTel', width: '10%' },
  { title: '生产厂商名称', dataIndex: 'Factory', width: '10%' },
  { title: '生产厂商联系人', dataIndex: 'FactoryContact', width: '10%' },
  { title: '生产厂商地址', dataIndex: 'FactoryAddr', width: '10%' },
  { title: '生产厂商电话', dataIndex: 'FactoryTel', width: '10%' },
  { title: '合同协议号', dataIndex: 'ContrNo', width: '10%' },
  { title: '签约日期', dataIndex: 'ContrDate', width: '10%' },
  { title: '发票编号', dataIndex: 'InvoiceNo', width: '10%' },
  { title: '发票日期', dataIndex: 'InvoiceDate', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_BabRel', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_PriceEffect', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_PriceClose', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_OtherLimited', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_OtherEffect', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_Note1', width: '10%' },
  { title: '价格申报项，进口货物申报项。', dataIndex: 'I_IsUsefee', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_IsProfit', width: '10%' },
  { title: '价格申报项，进口货物申报项', dataIndex: 'I_Note2', width: '10%' },
  { title: '价格申报项，币制', dataIndex: 'Curr', width: '10%' },
  { title: '价格申报项，发票价格单位金额', dataIndex: 'InvoicePrice', width: '10%' },
  { title: '价格申报项，发票价格总金额', dataIndex: 'InvoiceAmount', width: '10%' },
  { title: '价格申报项，发票价格备注', dataIndex: 'InvoiceNote', width: '10%' },
  { title: '价格申报项，间接支付/收取的货款单位金额，进口是间接支付，出口是间接收取', dataIndex: 'GoodsPrice', width: '10%' },
  { title: '价格申报项，间接支付/收取的货款总金额，进口是间接支付，出口是间接收取', dataIndex: 'GoodsAmount', width: '10%' },
  { title: '价格申报项，间接支付/收取的货款备注，进口是间接支付，出口是间接收取', dataIndex: 'GoodsNote', width: '10%' },
  { title: '价格申报项，进口货物除购货佣金以外的佣金和经纪费单位金额', dataIndex: 'I_CommissionPrice', width: '10%' },
  { title: '价格申报项，进口货物除购货佣金以外的佣金和经纪费总金额', dataIndex: 'I_CommissionAmount', width: '10%' },
  { title: '价格申报项，进口货物除购货佣金以外的佣金和经纪费备注', dataIndex: 'I_CommissionNote', width: '10%' },
  { title: '价格申报项，与该进口货物视为一体的容器费用单位金额', dataIndex: 'I_ContainerPrice', width: '10%' },
  { title: '价格申报项，与该进口货物视为一体的容器费用总金额', dataIndex: 'I_ContainerAmount', width: '10%' },
  { title: '价格申报项，与该进口货物视为一体的容器费用备注', dataIndex: 'I_ContainerNote', width: '10%' },
  { title: '价格申报项，进口货物包装材料和包装劳务费用单位金额', dataIndex: 'I_PackPrice', width: '10%' },
  { title: '价格申报项，进口货物包装材料和包装劳务费用总金额', dataIndex: 'I_PackAmount', width: '10%' },
  { title: '价格申报项，进口货物包装材料和包装劳务费用备注', dataIndex: 'I_PackNote', width: '10%' },
  { title: '价格申报项，进口货物包含的材料、部件、零件和类似货物单位金额', dataIndex: 'I_PartPrice', width: '10%' },
  { title: '价格申报项，进口货物包含的材料、部件、零件和类似货物总金额', dataIndex: 'I_PartAmount', width: '10%' },
  { title: '价格申报项，进口货物包含的材料、部件、零件和类似货物备注', dataIndex: 'I_PartNote', width: '10%' },
  { title: '价格申报项，在生产进口货物过程中使用的工具、模具和类似货物单位金额', dataIndex: 'I_ToolPrice', width: '10%' },
  { title: '价格申报项，在生产进口货物过程中使用的工具、模具和类似货物总金额', dataIndex: 'I_ToolAmount', width: '10%' },
  { title: '价格申报项，在生产进口货物过程中使用的工具、模具和类似货物备注', dataIndex: 'I_ToolNote', width: '10%' },
  { title: '价格申报项，在生产进口货物过程中消耗的材料单位金额', dataIndex: 'I_LossPrice', width: '10%' },
  { title: '价格申报项，在生产进口货物过程中消耗的材料总金额', dataIndex: 'I_LossAmount', width: '10%' },
  { title: '价格申报项，在生产进口货物过程中消耗的材料备注', dataIndex: 'I_LossNote', width: '10%' },
  { title: '价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务单位金额', dataIndex: 'I_DesignPrice', width: '10%' },
  { title: '价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务总金额', dataIndex: 'I_DesignAmount', width: '10%' },
  { title: '价格申报项，进口货物在境外进行的为生产进口货物所需的工程设计、技术研发、工艺及制图等相关服务备注', dataIndex: 'I_DesignNote', width: '10%' },
  { title: '价格申报项，特许权使用费单位金额', dataIndex: 'I_UsefeePrice', width: '10%' },
  { title: '价格申报项，特许权使用费总金额', dataIndex: 'I_UsefeeAmount', width: '10%' },
  { title: '价格申报项，特许权使用费备注', dataIndex: 'I_UsefeeNote', width: '10%' },
  { title: '价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益单位金额', dataIndex: 'I_ProfitPrice', width: '10%' },
  { title: '价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益总金额', dataIndex: 'I_ProfitAmount', width: '10%' },
  { title: '价格申报项，卖方直接或间接从买方对货物进口后转售、处置或使用所得中获得的收益备注', dataIndex: 'I_ProfitNote', width: '10%' },
  { title: '价格申报项，进口货物运输费用单位金额', dataIndex: 'I_FeePrice', width: '10%' },
  { title: '价格申报项，进口货物运输费用总金额', dataIndex: 'I_FeeAmount', width: '10%' },
  { title: '价格申报项，进口货物运输费用备注', dataIndex: 'I_FeeNote', width: '10%' },
  { title: '价格申报项，进口货物运输相关费用单位金额', dataIndex: 'I_OtherPrice', width: '10%' },
  { title: '价格申报项，进口货物运输相关费用总金额', dataIndex: 'I_OtherAmount', width: '10%' },
  { title: '价格申报项，进口货物运输相关费用备注', dataIndex: 'I_OtherNote', width: '10%' },
  { title: '价格申报项，进口货物保险费单位金额', dataIndex: 'I_InsurPrice', width: '10%' },
  { title: '价格申报项，进口货物保险费总金额', dataIndex: 'I_InsurAmount', width: '10%' },
  { title: '价格申报项，进口货物保险费备注', dataIndex: 'I_InsurNote', width: '10%' },
  { title: '价格申报项，出口关税是否已经从申报价格中扣除', dataIndex: 'E_IsDutyDel', width: '10%' },
  { title: '归类申报项，商品其他名称', dataIndex: 'GNameOther', width: '10%' },
  { title: '归类申报项，进/出口国地区海关商品编码', dataIndex: 'CodeTsOther', width: '10%' },
  { title: '归类申报项', dataIndex: 'IsClassDecision', width: '10%' },
  { title: '归类申报项，预归类决定书编号', dataIndex: 'DecisionNO', width: '10%' },
  { title: '归类申报项，预归类决定书商品编码', dataIndex: 'CodeTsDecision', width: '10%' },
  { title: '归类申报项，作出预归类决定的直属海关', dataIndex: 'DecisionCus', width: '10%' },
  { title: '归类申报项，该商品是否曾被海关取样化验', dataIndex: 'IsSampleTest', width: '10%' },
  { title: 'GOptions', dataIndex: 'GOptions', width: '10%' },
  { title: '运输方式', dataIndex: 'TrafMode', width: '10%' },
  { title: '原产地申报项，是否直接运输', dataIndex: 'IsDirectTraf', width: '10%' },
  { title: '原产地申报项，中转国地区，如果选择非直接运输，必填', dataIndex: 'TransitCountry', width: '10%' },
  { title: '原产地申报项，到货口岸', dataIndex: 'DestPort', width: '10%' },
  { title: '原产地申报项，申报口岸', dataIndex: 'DeclPort', width: '10%' },
  { title: '原产地申报项，提单编号', dataIndex: 'BillNo', width: '10%' },
  { title: '原产地申报项', dataIndex: 'OriginCountry', width: '10%' },
  { title: '原产地申报项，原产国地区标记的位置', dataIndex: 'OriginMark', width: '10%' },
  { title: '原产地申报项，原产地证书签发机构及所在国家地区，非参数选项，可录入汉字或字母', dataIndex: 'CertCountry', width: '10%' },
  { title: '原产地申报项，原产地证书编号', dataIndex: 'CertNO', width: '10%' },
  { title: '原产地申报项，适用的原产地标准', dataIndex: 'CertStandard', width: '10%' },
  { title: '公共申报项，其他需要说明的情况', dataIndex: 'OtherNote', width: '10%' },
  { title: '对以上申报内容是否需要海关予以保密', dataIndex: 'IsSecret', width: '10%' },
  { title: '申报单位类型', dataIndex: 'AgentType', width: '10%' },
  { title: '申报人单位地址', dataIndex: 'DeclAddr', width: '10%' },
  { title: '申报人邮编', dataIndex: 'DeclPost', width: '10%' },
  { title: '申报人电话', dataIndex: 'DeclTel', width: '10%' },
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
        .post('/Dec/tdecsupplement/GetDataList', {
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
            thisObj.$http.post('/Dec/tdecsupplement/DeleteData', ids).then(resJson => {
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