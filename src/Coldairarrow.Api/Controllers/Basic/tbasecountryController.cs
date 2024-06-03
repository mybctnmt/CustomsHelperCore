using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecountryController : BaseApiController
    {
        #region DI

        public tbasecountryController(ItbasecountryBusiness tbasecountryBus)
        {
            _tbasecountryBus = tbasecountryBus;
        }

        ItbasecountryBusiness _tbasecountryBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecountry>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecountryBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecountry> GetTheData(IdInputDTO input)
        {
            return await _tbasecountryBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecountry data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecountryBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecountryBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecountryBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}