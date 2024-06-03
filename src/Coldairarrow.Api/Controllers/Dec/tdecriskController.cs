using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecriskController : BaseApiController
    {
        #region DI

        public tdecriskController(ItdecriskBusiness tdecriskBus)
        {
            _tdecriskBus = tdecriskBus;
        }

        ItdecriskBusiness _tdecriskBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecrisk>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecriskBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecrisk> GetTheData(IdInputDTO input)
        {
            return await _tdecriskBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecrisk data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecriskBus.AddDataAsync(data);
            }
            else
            {
                await _tdecriskBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecriskBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}