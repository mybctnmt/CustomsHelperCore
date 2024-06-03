<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="提醒名称" prop="UserTag">
          <a-input v-model="entity.UserTag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="类型1-节点2-条件" prop="Type">
          <a-input v-model="entity.Type" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否启用1-是0-否" prop="IsEnable">
          <a-input v-model="entity.IsEnable" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提醒级别" prop="ReminderLevel">
          <a-input v-model="entity.ReminderLevel" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="提醒方式" prop="ReminderMethod">
          <a-input v-model="entity.ReminderMethod" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检查类型" prop="ExamType">
          <a-input v-model="entity.ExamType" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="检查项Id" prop="InspectionItemId">
          <a-input v-model="entity.InspectionItemId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="时间条件" prop="TimeNode">
          <a-input v-model="entity.TimeNode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="前-后" prop="PriorDate">
          <a-input v-model="entity.PriorDate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="时间值-天-小时" prop="TimeValue">
          <a-input v-model="entity.TimeValue" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="天-小时" prop="TimeType">
          <a-input v-model="entity.TimeType" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/Basic/talarmcondition/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/Basic/talarmcondition/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
