using Coldairarrow.Entity.IAQ;
using Coldairarrow.IBusiness;
using Coldairarrow.IBusiness.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class iaqinfoController : BaseApiController
    {
        #region DI

        public iaqinfoController(IiaqinfoBusiness iaqinfoBus)
        {
            _iaqinfoBus = iaqinfoBus;
        }

        IiaqinfoBusiness _iaqinfoBus { get; }

        #endregion

        #region 获取

        [HttpGet]
        public async Task<iaqinfo> GetIaqInfo(string Unumber)
        {
            return await _iaqinfoBus.GetIaqInfo(Unumber);
        }




        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveIaqInfo(iaqinfo iaqinfo)
        {
            if (iaqinfo.Unumber.IsNullOrEmpty())
            {
                throw new BusException("Unumber不允许为空！");
            }
            await _iaqinfoBus.SaveIaqInfoAsync(iaqinfo);
        }

        


        #endregion
    }
}
