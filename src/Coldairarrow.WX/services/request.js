import { BASE_URL } from "@services/global.js";

/**
 * @name: 用户请求方法,使用promise实现
 * @author: 李李
 */
const request = ({isLoading = true, ...args}) =>  {
  const token = wx.getStorageSync('token');
  if (isLoading) {
    wx.showLoading({
      title: '加载中...',
      mask: true
    })
  }
  return new Promise((resolve, reject) => {
    wx.request({
      timeout: 30000,
      ...args,
      url: `${BASE_URL}${args.url}`,
      header: {
        ...{
          'Content-Type': 'application/json',
          'Authorization': `${token ? 'Bearer ' + token : ''}`
        },
        ...args.header
      },
      success(result) {
        if (result.statusCode === 200) {
          resolve(result.data);
        } else if (result.statusCode === 401) {
          console.log(result.statusCode === 401);
          wx.switchTab({
            url: '/pages/profile-center/index'
          });
          resolve(result);
        } else {
          reject(result);
        }
        if (isLoading) {
          wx.hideLoading();
        }
      },
      fail(error) {
        reject(error);
        if (isLoading) {
          wx.hideLoading();
        }
      }
    })
  })
}

/**
 * @name: 上传文件, 使用promise实现
 * @author: 李李
 */
const upload = ({isLoading = true, ...args}) => {
  const token = wx.getStorageSync('token');
  if (isLoading) {
    wx.showLoading({
      title: '加载中...',
      mask: true
    })
  }
  return new Promise((resolve, reject) => {
    wx.uploadFile({
      timeout: 10000,
      ...args,
      url: `${BASE_URL}${args.url}`,
      header: {
        ...{
          'Content-Type': 'application/json',
          'Authorization': `${token ? 'Bearer ' + token : ''}`
        },
        ...args.header
      },
      success(result) {
        if (result.statusCode === 200) {
          resolve(JSON.parse(result.data));
        } else if (result.statusCode === 401) {
          wx.switchTab({
            url: '/pages/profile-center/index',
          });
          resolve(result);
        } else {
          reject(result);
        }
        if (isLoading) {
          wx.hideLoading();
        }
      },
      fail(error) {
        reject(error);
        if (isLoading) {
          wx.hideLoading();
        }
      }
    });
  });
};

/**
 * @name: 下载文件, 使用promise实现
 * @author: 李李
 */
const download = ({isLoading = true, ...args}) => {
  const token = wx.getStorageSync('token');
  if (isLoading) {
    wx.showLoading({
      title: '加载中...',
      mask: true
    })
  }
  return new Promise((resolve, reject) => {
    wx.downloadFile({
      timeout: 10000,
      ...args,
      url: `${BASE_URL}${args.url}`,
      header: {
        ...{
          'Content-Type': 'application/json',
          'Authorization': `${token ? 'Bearer ' + token : ''}`
        },
        ...args.header
      },
      success(result) {
        if (result.statusCode === 200) {
          resolve(result);
        } else if (result.statusCode === 401) {
          wx.switchTab({
            url: '/pages/profile-center/index',
          });
          resolve(result);
        } else {
          reject(result);
        }
        if (isLoading) {
          wx.hideLoading();
        }
      },
      fail(error) {
        reject(error);
        if (isLoading) {
          wx.hideLoading();
        }
      }
    });
  });
};

export {
  request,
  upload,
  download
};