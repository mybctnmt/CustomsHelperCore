using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaselicenseiController : BaseApiController
    {
        #region DI

        public tbaselicenseiController(ItbaselicenseiBusiness tbaselicenseiBus)
        {
            _tbaselicenseiBus = tbaselicenseiBus;
        }

        ItbaselicenseiBusiness _tbaselicenseiBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaselicensei>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaselicenseiBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaselicensei> GetTheData(IdInputDTO input)
        {
            return await _tbaselicenseiBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaselicensei data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaselicenseiBus.AddDataAsync(data);
            }
            else
            {
                await _tbaselicenseiBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaselicenseiBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}