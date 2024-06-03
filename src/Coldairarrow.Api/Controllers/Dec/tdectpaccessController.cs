using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdectpaccessController : BaseApiController
    {
        #region DI

        public tdectpaccessController(ItdectpaccessBusiness tdectpaccessBus)
        {
            _tdectpaccessBus = tdectpaccessBus;
        }

        ItdectpaccessBusiness _tdectpaccessBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdectpaccess>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdectpaccessBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdectpaccess> GetTheData(IdInputDTO input)
        {
            return await _tdectpaccessBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdectpaccess data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdectpaccessBus.AddDataAsync(data);
            }
            else
            {
                await _tdectpaccessBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdectpaccessBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}