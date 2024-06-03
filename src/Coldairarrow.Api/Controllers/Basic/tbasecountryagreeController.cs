using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecountryagreeController : BaseApiController
    {
        #region DI

        public tbasecountryagreeController(ItbasecountryagreeBusiness tbasecountryagreeBus)
        {
            _tbasecountryagreeBus = tbasecountryagreeBus;
        }

        ItbasecountryagreeBusiness _tbasecountryagreeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecountryagree>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecountryagreeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecountryagree> GetTheData(IdInputDTO input)
        {
            return await _tbasecountryagreeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecountryagree data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecountryagreeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecountryagreeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecountryagreeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}