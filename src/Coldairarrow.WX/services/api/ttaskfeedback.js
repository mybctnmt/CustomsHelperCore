import { request } from '@services/request.js';

export const getDataList = (data) => request({
  url: "Fieldwork/ttaskfeedback/GetDataList",
  method: "POST",
  data
});

export const saveData = (data) => request({
  url: "Fieldwork/ttaskfeedback/SaveData",
  method: "POST",
  data
});

export const deleteData = (data) => request({
  url: "​Fieldwork/ttaskfeedback/DeleteData",
  method: "POST",
  data
});