using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecsignController : BaseApiController
    {
        #region DI

        public tdecsignController(ItdecsignBusiness tdecsignBus)
        {
            _tdecsignBus = tdecsignBus;
        }

        ItdecsignBusiness _tdecsignBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecsign>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecsignBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecsign> GetTheData(IdInputDTO input)
        {
            return await _tdecsignBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecsign data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecsignBus.AddDataAsync(data);
            }
            else
            {
                await _tdecsignBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecsignBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}