using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasesetupController : BaseApiController
    {
        #region DI

        public tbasesetupController(ItbasesetupBusiness tbasesetupBus)
        {
            _tbasesetupBus = tbasesetupBus;
        }

        ItbasesetupBusiness _tbasesetupBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasesetup>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasesetupBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasesetup> GetTheData(IdInputDTO input)
        {
            return await _tbasesetupBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasesetup data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasesetupBus.AddDataAsync(data);
            }
            else
            {
                await _tbasesetupBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasesetupBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}