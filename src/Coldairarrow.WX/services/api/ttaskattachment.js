import { request } from '@services/request.js';

export const getDataList = (data) => request({
  url: "Fieldwork/ttaskattachment/GetDataList",
  method: "POST",
  data
});

export const saveData = (data) => request({
  url: "Fieldwork/ttaskattachment/SaveData",
  method: "POST",
  data
});

export const deleteData = (data) => request({
  url: "Fieldwork/ttaskattachment/DeleteData",
  method: "POST",
  data
});