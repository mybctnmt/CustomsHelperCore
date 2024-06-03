using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecsupplementController : BaseApiController
    {
        #region DI

        public tdecsupplementController(ItdecsupplementBusiness tdecsupplementBus)
        {
            _tdecsupplementBus = tdecsupplementBus;
        }

        ItdecsupplementBusiness _tdecsupplementBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecsupplement>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecsupplementBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecsupplement> GetTheData(IdInputDTO input)
        {
            return await _tdecsupplementBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecsupplement data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecsupplementBus.AddDataAsync(data);
            }
            else
            {
                await _tdecsupplementBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecsupplementBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}