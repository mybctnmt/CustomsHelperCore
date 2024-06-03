using Coldairarrow.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    [Route("/Base_Manage/[controller]/[action]")]
    [OpenApiTag("上传")]
    public class DownloadController : BaseApiController
    {
        readonly IConfiguration _configuration;
        public DownloadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult DownloadDecFile(string filePath)
        {
            // 检查文件是否存在
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            // 设置响应头以指示文件下载
            var fileName = Path.GetFileName(filePath);
            var encodedFileName = WebUtility.UrlEncode(fileName);
            Response.Headers.Add("Content-Disposition", $"attachment; filename={encodedFileName}");

            // 读取文件并将其作为响应内容发送
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/octet-stream", fileName);
        }
    }
}
