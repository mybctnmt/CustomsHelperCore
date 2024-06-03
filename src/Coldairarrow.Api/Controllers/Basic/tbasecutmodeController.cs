using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecutmodeController : BaseApiController
    {
        #region DI

        public tbasecutmodeController(ItbasecutmodeBusiness tbasecutmodeBus)
        {
            _tbasecutmodeBus = tbasecutmodeBus;
        }

        ItbasecutmodeBusiness _tbasecutmodeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecutmode>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecutmodeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecutmode> GetTheData(IdInputDTO input)
        {
            return await _tbasecutmodeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecutmode data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecutmodeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecutmodeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecutmodeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}