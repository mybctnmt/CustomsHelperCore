import { download } from '@services/request.js';

export const downloadDecFile = (filePath) => download({
  url: `Base_Manage/Download/DownloadDecFile?filePath=${filePath}`,
});
