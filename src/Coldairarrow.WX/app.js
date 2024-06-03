import { getOpenId, getOperatorInfo } from "@services/api/home.js";
import { getWXToken } from "@services/api/twxuserinfo.js";
import weappJwt from "@utils/weapp-jwt.js";
App({
  onLaunch() {
    const token = wx.getStorageSync('token');
    try {
      let res = weappJwt(token);
      console.log(res);
    } catch (err) {
      wx.setStorageSync('token', null);
    }
    // wx.getSystemInfo({
    //   success: function(res) {
    //     wx.showModal({
    //       title: '',
    //       content: JSON.stringify(res),
    //       complete: (res) => {
    //         if (res.cancel) {
              
    //         }
        
    //         if (res.confirm) {
              
    //         }
    //       }
    //     })
    //   }
    // })
    wx.login({
      success: async (res) => {
        if (res.code) {
          try {
            const wxLoginResult = await getOpenId({ code: res.code });
            if (wxLoginResult.Success) {
              wx.setStorageSync('openid', wxLoginResult.Data.openid);
              const wxTokenResult = await getWXToken({ openid: wxLoginResult.Data.openid });
              if (wxTokenResult.Success) {
                wx.setStorageSync('token', wxTokenResult.Data);
                this.getOperatorInfo();
                this.tokenCallback();
              } else {
                wx.switchTab({
                  url: '/pages/profile-center/index',
                })
              }
            } else {
              wx.showToast({
                title: wxLoginResult.Msg,
                icon: "none"
              })
            }
          } catch (error) {
            wx.showToast({
              title: error.errMsg,
              icon: "none"
            })
          }
        }
      }
    })
  },
  async getOperatorInfo() {
    try {
      const userResult = await getOperatorInfo();
      if (userResult.Success) {
        this.globalData.userInfo = userResult.Data.UserInfo;
        this.globalData.bindingIf = true;
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
  globalData: {
    userInfo: null,
    bindingIf: false
  }
})
