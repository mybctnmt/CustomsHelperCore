using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecfreetxtController : BaseApiController
    {
        #region DI

        public tdecfreetxtController(ItdecfreetxtBusiness tdecfreetxtBus)
        {
            _tdecfreetxtBus = tdecfreetxtBus;
        }

        ItdecfreetxtBusiness _tdecfreetxtBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecfreetxt>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecfreetxtBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecfreetxt> GetTheData(IdInputDTO input)
        {
            return await _tdecfreetxtBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecfreetxt data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecfreetxtBus.AddDataAsync(data);
            }
            else
            {
                await _tdecfreetxtBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecfreetxtBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}