﻿<template>
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
        <a-form-model-item label="Unumber" prop="Unumber">
          <a-input v-model="entity.Unumber" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="关检关联号" prop="CusCiqNo">
          <a-input v-model="entity.CusCiqNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="报检号" prop="EntDealNo">
          <a-input v-model="entity.EntDealNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="通关单号" prop="CIBINo">
          <a-input v-model="entity.CIBINo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="操作时间" prop="OperTime">
          <a-input v-model="entity.OperTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="回执代码" prop="RspCodes">
          <a-input v-model="entity.RspCodes" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="回执信息" prop="RspInfo">
          <a-input v-model="entity.RspInfo" autocomplete="off" />
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
        this.$http.post('/IAQ/ciq_ret/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/IAQ/ciq_ret/SaveData', this.entity).then(resJson => {
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
