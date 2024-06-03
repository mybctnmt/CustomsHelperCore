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
        <a-form-model-item label="codets" prop="codets">
          <a-input v-model="entity.codets" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="controlMark" prop="controlMark">
          <a-input v-model="entity.controlMark" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="unitFlag" prop="unitFlag">
          <a-input v-model="entity.unitFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ciqWtMeasUnit" prop="ciqWtMeasUnit">
          <a-input v-model="entity.ciqWtMeasUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ciqWtMeasUnitName" prop="ciqWtMeasUnitName">
          <a-input v-model="entity.ciqWtMeasUnitName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="gname" prop="gname">
          <a-input v-model="entity.gname" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="unit1" prop="unit1">
          <a-input v-model="entity.unit1" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="dangerFlag" prop="dangerFlag">
          <a-input v-model="entity.dangerFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="unit1Name" prop="unit1Name">
          <a-input v-model="entity.unit1Name" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="unit2" prop="unit2">
          <a-input v-model="entity.unit2" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="outDutyTypeFlag" prop="outDutyTypeFlag">
          <a-input v-model="entity.outDutyTypeFlag" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="inspMonitorCond" prop="inspMonitorCond">
          <a-input v-model="entity.inspMonitorCond" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ciqQtyMeasUnitName" prop="ciqQtyMeasUnitName">
          <a-input v-model="entity.ciqQtyMeasUnitName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="ciqQtyMeasUnit" prop="ciqQtyMeasUnit">
          <a-input v-model="entity.ciqQtyMeasUnit" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="noteS" prop="noteS">
          <a-input v-model="entity.noteS" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="unit2Name" prop="unit2Name">
          <a-input v-model="entity.unit2Name" autocomplete="off" />
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
        this.$http.post('/Basic/tbasehscodeinfo/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/Basic/tbasehscodeinfo/SaveData', this.entity).then(resJson => {
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
