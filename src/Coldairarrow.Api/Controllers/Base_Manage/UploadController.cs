using Coldairarrow.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    [Route("/Base_Manage/[controller]/[action]")]
    [OpenApiTag("上传")]
    public class UploadController : BaseApiController
    {
        readonly IConfiguration _configuration;
        public UploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        //[AllowAnonymous]
        public IActionResult UploadFileByForm(IFormFile formFile)
        {
            var file = formFile;
            if (file == null)
                return JsonContent(new { status = "error" }.ToJson());

            string path = $"/Upload/{Guid.NewGuid().ToString("N")}/{file.FileName}";
            string physicPath = GetAbsolutePath($"~{path}");
            string dir = Path.GetDirectoryName(physicPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            using (FileStream fs = new FileStream(physicPath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            string url = $"{_configuration["WebRootUrl"]}{path}";
            var res = new
            {
                name = file.FileName,
                status = "done",
                thumbUrl = url,
                url = url
            };

            return JsonContent(res.ToJson());
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<string> UploadDecFile(IFormFile formFile, string fileName, string folder)
        {
            var file = formFile;
            if (file == null)
                throw new BusException("文件不能为空！");

            string path = $"~/{folder}/{DateTime.Now.ToString("yyyyMMdd")}/{fileName}";
            string rootPath = _configuration["WebRootPath"];
            path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            path = path.Remove(0, 2);
            string physicPath = Path.Combine(rootPath, $"{path}");
            string dir = Path.GetDirectoryName(physicPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            using (FileStream fs = new FileStream(physicPath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return physicPath;
        }
    }
}
