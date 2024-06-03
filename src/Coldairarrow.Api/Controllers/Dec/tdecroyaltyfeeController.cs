using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecroyaltyfeeController : BaseApiController
    {
        #region DI

        public tdecroyaltyfeeController(ItdecroyaltyfeeBusiness tdecroyaltyfeeBus)
        {
            _tdecroyaltyfeeBus = tdecroyaltyfeeBus;
        }

        ItdecroyaltyfeeBusiness _tdecroyaltyfeeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecroyaltyfee>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecroyaltyfeeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecroyaltyfee> GetTheData(IdInputDTO input)
        {
            return await _tdecroyaltyfeeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecroyaltyfee data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecroyaltyfeeBus.AddDataAsync(data);
            }
            else
            {
                await _tdecroyaltyfeeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecroyaltyfeeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}