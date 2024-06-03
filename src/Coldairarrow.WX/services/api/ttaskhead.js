import { request } from '@services/request.js';

export const getDataList = (data) => request({
  url: "Fieldwork/ttaskhead/GetDataList",
  method: "POST",
  data ,
  isLoading: false
});

export const saveData = (data) => request({
  url: "Fieldwork/ttaskhead/SaveData",
  method: "POST",
  data
});

export const deleteData = (data) => request({
  url: "Fieldwork/ttaskhead/DeleteData",
  method: "POST",
  data
});

export const getTaskInfo = (id) => request({
  url: "Fieldwork/ttaskhead/GetTaskInfo?id=" + id,
});

export const acceptTask = (id) => request({
  url: "Fieldwork/ttaskhead/AcceptTask?id=" + id,
  method: "POST"
});


export const saveTaskInfo = (data) => request({
  url: "Fieldwork/ttaskhead/SaveTaskInfo",
  method: "POST",
  data
});