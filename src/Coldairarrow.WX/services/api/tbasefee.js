import { request } from '@services/request.js';

export const getDataList = (data) => request({
  url: "Basic/tbasefee/GetDataList",
  method: "POST",
  data
});