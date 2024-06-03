using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseportController : BaseApiController
    {
        #region DI

        public tbaseportController(ItbaseportBusiness tbaseportBus)
        {
            _tbaseportBus = tbaseportBus;
        }

        ItbaseportBusiness _tbaseportBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseport>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseportBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseport> GetTheData(IdInputDTO input)
        {
            return await _tbaseportBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseport data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseportBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseportBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseportBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}