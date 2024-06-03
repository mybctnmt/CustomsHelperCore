import { upload } from '@services/request.js';

export const uploadDecFile = (filePath, fileName, folder) => upload({
  url: `Base_Manage/Upload/UploadDecFile?fileName=${fileName}&folder=${folder}`,
  filePath: filePath,
  name: 'formFile'
});

