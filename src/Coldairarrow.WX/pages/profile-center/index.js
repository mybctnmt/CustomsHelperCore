import { accountBind, cancelBind } from "@services/api/twxuserinfo.js";
import { getOperatorInfo } from "@services/api/home.js";
const { globalData } = getApp();
Page({
  /**
   * 页面的初始数据
   */
  data: {
    dialogKey: '',
    showWithInput: false,
    showTextAndTitleWithInput: false,
    userInfo: null,
    username: '',
    password: '',
    name: '',
    bindingIf: false
  },

  closeDialog() {
    const { dialogKey } = this.data;
    this.setData({ [dialogKey]: false });
    wx.showTabBar();
  },

  async confirmDialog() {
    try {
      const openid = wx.getStorageSync('openid');
      const bindResult = await accountBind({
        username: this.data.username,
        password: this.data.password,
        openid
      })
      if (bindResult.Success) {
        wx.setStorageSync('token', bindResult.Data);
        await this.getOperatorInfo();
        wx.showToast({
          title: "绑定成功",
        })
        this.setData({ showWithInput: false });
        wx.showTabBar();
      } else {
        wx.showToast({
          title: bindResult.Msg,
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

  getInfo() {
    this.setData({
      userInfo: globalData.userInfo,
      bindingIf: globalData.bindingIf
    });
  },

  bindingClick(e) {
    const { key } = e.currentTarget.dataset;
    this.setData({ [key]: true, dialogKey: key });
    wx.hideTabBar();
  },

  async unBindingClick() {
    const openid = wx.getStorageSync('openid');
    try {
      const result = await cancelBind(openid);
      if (result.Success) {
        wx.removeStorageSync('token');
        this.setData({
          username: null,
          password: null,
          userInfo: null,
          bindingIf: false
        });
        globalData.userInfo = null;
        globalData.bindingIf = false;
        wx.showToast({
          title: "解绑成功"
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

  async getOperatorInfo() {
    try {
      const userResult = await getOperatorInfo();
      if (userResult.Success) {
        this.setData({
          userInfo: userResult.Data.UserInfo,
          bindingIf: true
        });
      } else {
        wx.showToast({
          title: userResult.Msg,
          icon: "none"
        });
      }
    } catch (error) {
      wx.showToast({
        title: error.errMsg,
        icon: "none"
      })
    }
  },

  /**
   * 生命周期函数--监听页面加载
   */
  async onLoad(options) {
    this.getInfo();
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