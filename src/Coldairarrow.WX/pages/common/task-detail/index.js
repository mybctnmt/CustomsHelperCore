import { getTaskInfo, acceptTask, saveTaskInfo } from "@services/api/ttaskhead.js";
import { getDataList } from "@services/api/tbasefee.js";
import { uploadDecFile } from "@services/api/upload.js";
import { downloadDecFile } from "@services/api/download.js";
import { getGuid } from "@utils/util";
Page({

  /**
   * 页面的初始数据
   */
  data: {
    id: null,
    taskInfo: {},
    feeId: "",
    feeNameCn: "",
    costAmount: "",
    ttaskcost: {
      FeeId: "",
      FeeNameCn: "",
      CostName: "",
      CostAmount: "",
      CostType: "应收"
    },
    completedContent: "",
    files: [],
    gridConfig: {
      column: 4,
      width: 160,
      height: 160,
    },
    config: {
      count: 10
    },
    extensions: ['jpg', 'jpeg', 'png', "pdf"],
    visible: false,
    fees: [],
    oldFees: [],
    feeValue: ""
  },

  getCurrentValue(e){
    const feeValue = e.detail.value;
    const { oldFees } = this.data;
    console.log(feeValue);
    this.setData({
      fees: feeValue ? oldFees.filter(item => item.FeeNameCn.includes(feeValue) || item.FeeCode.includes(feeValue)) : oldFees,
      feeValue
    });
  },

  async getTaskInfo(id) {
    try {
      const result = await getTaskInfo(id);
      if (result.Success) {
        const taskInfo = result.Data;
        const files = [];
        for (let ttaskattachment of taskInfo.ttaskattachments) {
          const file = await downloadDecFile(ttaskattachment.AttachmentUrl);
          const temp = {};
          temp.name = ttaskattachment.AttachmentName;
          temp.percent = 0;
          temp.size = ttaskattachment.AttachmentSize;
          temp.time = Math.floor(new Date().getTime() / 1000);
          temp.type = ttaskattachment.AttachmentType;
          temp.url = file.tempFilePath;
          files.push(temp);
        }
        this.setData({
          files,
          taskInfo,
          completedContent: taskInfo.ttaskfeedback?.CompletedContent
        });
      } else {
        wx.showToast({
          title: result.Msg,
          icon: "none"
        });
      }
    } catch (error) {
      wx.showToast({
        title: error.errMsg,
        icon: "none"
      });
    }
  },

  async acceptTask() {
    const { id } = this.data;
    try {
      const result = await acceptTask(id);
      if (result.Success) {
        await this.getTaskInfo(id);
        wx.showToast({
          title: "接受成功!",
          icon: "none"
        });
      } else {
        wx.showToast({
          title: result.Msg,
          icon: "none"
        });
      }
    } catch (error) {
      wx.showToast({
        title: error.errMsg,
        icon: "none"
      });
    }
  },
  handleSuccess(e) {
    const { files } = e.detail;
    this.setData({
      files,
    });
  },
  handleRemove(e) {
    const { index } = e.detail;
    const { files } = this.data;
    files.splice(index, 1);
    this.setData({
      files,
    });
  },
  async submitTask() {
    const { files, taskInfo, completedContent, id } = this.data;
    const ttaskattachments = [];
    for (const file of files) {
      let url = file.url;
      const result = await uploadDecFile(url, file.name, "Task");
      if (result.Success) {
        const ttaskattachment = {};
        ttaskattachment.TaskId = taskInfo.ttaskhead.Id;
        ttaskattachment.AttachmentName = file.name;
        ttaskattachment.AttachmentUrl = result.Data;
        ttaskattachment.AttachmentSize = file.size;
        ttaskattachment.AttachmentType = file.type;
        ttaskattachments.push(ttaskattachment);
      }
    }
    const ttaskfeedback = {};
    ttaskfeedback.TaskId = taskInfo.ttaskhead.Id;
    ttaskfeedback.CompletedContent = completedContent;
    taskInfo.ttaskfeedback = ttaskfeedback;
    taskInfo.ttaskattachments = ttaskattachments;
    try {
      const result = await saveTaskInfo(taskInfo);
      if (result.Success) {
        await this.getTaskInfo(id);
        wx.showToast({
          title: result.Msg,
          icon: "none"
        });
      } else {
        wx.showToast({
          title: result.Msg,
          icon: "none"
        });
      }
    } catch (error) {
      wx.showToast({
        title: error.errMsg,
        icon: "none"
      });
    }
  },

  costTypeTap(e) {
    this.setData({ visible: true });
  },

  onVisibleChange(e) {
    this.setData({
      visible: e.detail.visible,
    });
  },

  onChange(e) {
    this.setData({  feeId: e.detail.value });
  },

  cancel() {
    this.setData({
      visible: false
    });
  },

  confirm() {
    const { feeId, fees } = this.data;
    const fee = fees.filter(item => item.Id == feeId);
    console.log(fee);
    this.setData({
      'ttaskcost.FeeId': feeId,
      'ttaskcost.FeeNameCn': fee.length > 0 ? fee[0].FeeNameCn : "",
      feeNameCn: fee.length > 0 ? fee[0].FeeNameCn : "",
      visible: false
    });
  },

  addTap() {
    this.setData({
      feeId: "",
      feeNameCn: "",
      costAmount: "",
      ttaskcost: {
        FeeId: "",
        FeeNameCn: "",
        CostName: "",
        CostAmount: "",
        CostType: "应收"
      }
    })
  },

  saveTap() {
    const { ttaskcost, taskInfo, costAmount } = this.data;
    ttaskcost.Id = getGuid();
    ttaskcost.CostAmount = parseFloat(costAmount);
    ttaskcost.OrderNo = taskInfo.ttaskhead.OrderNo;
    ttaskcost.TaskId = taskInfo.ttaskhead.Id;
    this.setData({
      'taskInfo.ttaskcosts': [...taskInfo.ttaskcosts, ttaskcost],
      feeId: "",
      feeNameCn: "",
      costAmount: "",
      ttaskcost: {
        FeeId: "",
        FeeNameCn: "",
        CostName: "",
        CostAmount: "",
        CostType: "应收"
      }
    });
  },

  delTap(e) {
    const { taskInfo } = this.data;
    const idx = e.target.dataset.index;
    this.setData({
      'taskInfo.ttaskcosts': taskInfo.ttaskcosts.filter((item, index) => index !== idx)
    });
  },

  async initData() {
    try {
      let result = await getDataList({
        PageIndex: 1,
        PageRows: 10000
      });
      if (result.Success) {
        this.setData({
          fees: result.Data,
          oldFees: result.Data
        });
      } else {
        wx.showToast({
          title: result.Msg,
          icon: "none"
        });
      }
    } catch (error) {
      wx.showToast({
        title: error.errMsg,
        icon: "none"
      });
    }
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad(options) {
    const id = options.id;
    this.setData({ id });
    this.initData();
    this.getTaskInfo(id);
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady() {
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow() {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload() {
    const { taskInfo } = this.data;
    const eventChannel = this.getOpenerEventChannel()
    eventChannel?.emit("unload", taskInfo);
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage() {

  }
})