import { saveData } from "@services/api/ttaskhead";
import { formatTime } from "@utils/util";
import { getDataListjoinHeadWhere } from "@services/api/temailorder";
const { globalData } = getApp();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    taskName: "",
    taskContent: "",
    isUrgent: false,
    keyword: '',
    emailOrderIndex: -1,
    emailOrders: [],
    emailOrder: {},
    billNo: "",
    image: "/assets/images/empty.png",
    orderPlaceholder: "请输入订单号",
    order: {
      value: 'OrderNo',
      options: [
        {
          value: 'OrderNo',
          label: '订单号',
        },
        {
          value: 'BillNo',
          label: '提单号',
        },
        {
          value: 'SeqNo',
          label: '统一号',
        },
        {
          value: 'EntryId',
          label: '海关号',
        },
      ],
    },
  },
  onOrderChange(e) {
    const { order } = this.data;
    this.setData({
      'order.value': e.detail.value,
      orderPlaceholder: `请输入${order.options.filter(item => e.detail.value == item.value)[0].label}`
    });
  },
  async postTask() {
    const { taskName, taskContent, isUrgent, emailOrder, billNo } = this.data;
    if (!taskName) {
      wx.showToast({
        title: "任务名称不能为空！",
        icon: "none"
      });
    }
    if (!taskContent) {
      wx.showToast({
        title: "任务内容不能为空！",
        icon: "none"
      });
    }
    const ttaskhead = {};
    ttaskhead.TaskName = taskName;
    ttaskhead.TaskContent = taskContent;
    ttaskhead.IsUrgent = isUrgent;
    ttaskhead.OperatorId = globalData.userInfo.Id;
    ttaskhead.OperatorName = globalData.userInfo.RealName;
    ttaskhead.OperateTime = formatTime(new Date());
    ttaskhead.ReceiverId = globalData.userInfo.Id;
    ttaskhead.ReceiverName = globalData.userInfo.RealName;
    ttaskhead.ReceiveTime = formatTime(new Date());
    ttaskhead.OrderNo = emailOrder?.OrderNo;
    ttaskhead.BillNo = emailOrder?.BillNo;
    ttaskhead.TrafName = emailOrder?.TrafName;
    ttaskhead.CusVoyageNo = emailOrder?.CusVoyageNo;
    ttaskhead.TradeCountry = emailOrder?.TradeCountry;
    ttaskhead.CodeTS = emailOrder?.CodeTS;
    ttaskhead.GName = emailOrder?.GName;
    ttaskhead.OwnerCode = emailOrder?.OwnerCode;
    ttaskhead.OwnerName = emailOrder?.OwnerName;
    ttaskhead.CodeTS = emailOrder?.CodeTS;
    ttaskhead.GName = emailOrder?.GName;
    if (!ttaskhead.OrderNo) {
      ttaskhead.BillNo = billNo;
    }
    try {
      const result = await saveData(ttaskhead);
      if (result.Success) {
        wx.showToast({
          title: "发布成功！",
          icon: "none"
        });
        this.setData({
          taskName: "",
          taskContent: "",
          isUrgent: false,
          orderNo: '',
          emailOrderIndex: -1,
          emailOrders: [],
          emailOrder: {},
          billNo: ""
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

  selectOrder() {
    // wx.navigateTo({
    //   url: '/pages/my-task/subpage/select-order/index'
    // });
    
    this.setData({ visible: true });
  },

  onVisibleChange(e) {
    this.setData({
      visible: e.detail.visible,
    });
  },

  cancel() {
    this.setData({ visible: false });
  },
  
  confirm() {
    const { emailOrderIndex, emailOrders } = this.data;
    this.setData({ visible: false, emailOrder: emailOrders.length > 0 ? emailOrderIndex !== -1 ? emailOrders[emailOrderIndex] : {} : {} });
  },

  async search() {
    const { keyword, order } = this.data;
    try {
      const result = await getDataListjoinHeadWhere({
        Search: [{
          Condition: order.value,
          Keyword: keyword
        }]
      });
      if (result.Success) {
        this.setData({
          emailOrders: result.Data
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

  onChange(e) {
    const { emailOrderIndex } = this.data;
    this.setData({ emailOrderIndex: emailOrderIndex === e.detail.value ? -1 : e.detail.value });
  },

  handleChange(e) {
    this.setData({
      isUrgent: e.detail.value,
    });
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad(options) {

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