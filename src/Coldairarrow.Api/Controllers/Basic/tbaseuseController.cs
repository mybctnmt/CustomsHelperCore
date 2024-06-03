using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseuseController : BaseApiController
    {
        #region DI

        public tbaseuseController(ItbaseuseBusiness tbaseuseBus)
        {
            _tbaseuseBus = tbaseuseBus;
        }

        ItbaseuseBusiness _tbaseuseBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseuse>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseuseBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseuse> GetTheData(IdInputDTO input)
        {
            return await _tbaseuseBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseuse data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseuseBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseuseBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseuseBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}