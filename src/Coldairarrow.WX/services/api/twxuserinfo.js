import { request } from '@services/request.js';

export const getWXToken = (data) => request({
  url: "Basic/twxuserinfo/GetWXToken",
  data
});

export const accountBind = (data) => request({
  url: "Basic/twxuserinfo/AccountBind",
  method: "POST",
  data
});

export const cancelBind = (openid) => request({
  url: "Basic/twxuserinfo/CancelBind?openid=" + openid,
  method: "POST"
});