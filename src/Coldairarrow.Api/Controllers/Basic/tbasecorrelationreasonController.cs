using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecorrelationreasonController : BaseApiController
    {
        #region DI

        public tbasecorrelationreasonController(ItbasecorrelationreasonBusiness tbasecorrelationreasonBus)
        {
            _tbasecorrelationreasonBus = tbasecorrelationreasonBus;
        }

        ItbasecorrelationreasonBusiness _tbasecorrelationreasonBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecorrelationreason>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecorrelationreasonBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecorrelationreason> GetTheData(IdInputDTO input)
        {
            return await _tbasecorrelationreasonBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecorrelationreason data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecorrelationreasonBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecorrelationreasonBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecorrelationreasonBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}