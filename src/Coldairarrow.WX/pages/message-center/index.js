import { getDataList } from "@services/api/user.js";
import pinyin from "wl-pinyin"
Page({
  /**
   * 页面的初始数据
   */
  data: {
    value: '',
    indexList: [],
    users: [],
    list: []
  },

  onSelect(e) {
    const { index } = e.detail;
    console.log(index);
  },

  async getDataList() {
    try {
      const dataList = await getDataList({
        "PageIndex": 1,
        "PageRows": 100000
      });
      if (dataList.Success) {
        let users = dataList.Data;
        let names = users.map(user => user.RealName);
        // 对names数组进行排序
        names.sort((a, b) => a.localeCompare(b, 'zh'));
        let result = names.reduce((acc, name) => {
          let firstLetter = pinyin.getPinyin(name[0])[0].toUpperCase();
          let index = acc.findIndex(item => item.index === firstLetter);
          if (index === -1) {
            acc.push({
              index: firstLetter,
              children: [name]
            });
          } else {
            acc[index].children.push(name);
          }
          return acc;
        }, []);
        this.setData({
          users: users,
          list: result,
          indexList: result.map((item) => item.index),
        })
      } else {
        wx.showToast({
          title: dataList.Msg,
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
    this.getDataList();
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