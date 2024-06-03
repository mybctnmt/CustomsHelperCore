using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecustommasterController : BaseApiController
    {
        #region DI

        public tbasecustommasterController(ItbasecustommasterBusiness tbasecustommasterBus)
        {
            _tbasecustommasterBus = tbasecustommasterBus;
        }

        ItbasecustommasterBusiness _tbasecustommasterBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecustommaster>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecustommasterBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecustommaster> GetTheData(IdInputDTO input)
        {
            return await _tbasecustommasterBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecustommaster data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecustommasterBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecustommasterBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecustommasterBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}