using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasedocreqController : BaseApiController
    {
        #region DI

        public tbasedocreqController(ItbasedocreqBusiness tbasedocreqBus)
        {
            _tbasedocreqBus = tbasedocreqBus;
        }

        ItbasedocreqBusiness _tbasedocreqBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasedocreq>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasedocreqBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasedocreq> GetTheData(IdInputDTO input)
        {
            return await _tbasedocreqBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasedocreq data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasedocreqBus.AddDataAsync(data);
            }
            else
            {
                await _tbasedocreqBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasedocreqBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}