import { request } from '@services/request.js';

export const getDataList = (data) => request({
  url: `Base_Manage/Base_User/GetDataList`,
  method: "POST",
  data
});