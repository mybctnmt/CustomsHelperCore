using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdeccoppromiseController : BaseApiController
    {
        #region DI

        public tdeccoppromiseController(ItdeccoppromiseBusiness tdeccoppromiseBus)
        {
            _tdeccoppromiseBus = tdeccoppromiseBus;
        }

        ItdeccoppromiseBusiness _tdeccoppromiseBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdeccoppromise>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdeccoppromiseBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdeccoppromise> GetTheData(IdInputDTO input)
        {
            return await _tdeccoppromiseBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdeccoppromise data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdeccoppromiseBus.AddDataAsync(data);
            }
            else
            {
                await _tdeccoppromiseBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdeccoppromiseBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}