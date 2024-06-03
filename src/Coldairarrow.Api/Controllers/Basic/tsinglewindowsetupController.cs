using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tsinglewindowsetupController : BaseApiController
    {
        #region DI

        public tsinglewindowsetupController(ItsinglewindowsetupBusiness tsinglewindowsetupBus)
        {
            _tsinglewindowsetupBus = tsinglewindowsetupBus;
        }

        ItsinglewindowsetupBusiness _tsinglewindowsetupBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tsinglewindowsetup>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tsinglewindowsetupBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tsinglewindowsetup> GetTheData(IdInputDTO input)
        {
            return await _tsinglewindowsetupBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tsinglewindowsetup data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tsinglewindowsetupBus.AddDataAsync(data);
            }
            else
            {
                await _tsinglewindowsetupBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tsinglewindowsetupBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}