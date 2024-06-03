import { request } from '@services/request.js';

export const getOpenId = (data) => request({
  url: `Base_Manage/Home/GetOpenId`,
  data
});

export const getOperatorInfo = () => request({
  url: "Base_Manage/Home/GetOperatorInfo",
  method: "POST"
});