using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasefeemarkController : BaseApiController
    {
        #region DI

        public tbasefeemarkController(ItbasefeemarkBusiness tbasefeemarkBus)
        {
            _tbasefeemarkBus = tbasefeemarkBus;
        }

        ItbasefeemarkBusiness _tbasefeemarkBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasefeemark>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasefeemarkBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasefeemark> GetTheData(IdInputDTO input)
        {
            return await _tbasefeemarkBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasefeemark data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasefeemarkBus.AddDataAsync(data);
            }
            else
            {
                await _tbasefeemarkBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasefeemarkBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}