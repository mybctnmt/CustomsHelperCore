import { request } from '@services/request.js';

export const getDataListjoinHeadWhere = (data) => request({
  url: "Inbox/temailorder/GetDataListjoinHeadWhere",
  method: "POST",
  data: {
    PageIndex: 1,
    PageRows: 50,
    SortField: "SendTime",
    SortType: "Desc",
    ...data
  }
});