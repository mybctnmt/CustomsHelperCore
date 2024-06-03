using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class ttrnheadController : BaseApiController
    {
        #region DI

        public ttrnheadController(IttrnheadBusiness ttrnheadBus)
        {
            _ttrnheadBus = ttrnheadBus;
        }

        IttrnheadBusiness _ttrnheadBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttrnhead>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttrnheadBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttrnhead> GetTheData(IdInputDTO input)
        {
            return await _ttrnheadBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttrnhead data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttrnheadBus.AddDataAsync(data);
            }
            else
            {
                await _ttrnheadBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttrnheadBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}