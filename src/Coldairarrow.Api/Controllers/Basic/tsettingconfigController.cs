using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tsettingconfigController : BaseApiController
    {
        #region DI

        public tsettingconfigController(ItsettingconfigBusiness tsettingconfigBus)
        {
            _tsettingconfigBus = tsettingconfigBus;
        }

        ItsettingconfigBusiness _tsettingconfigBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tsettingconfig>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tsettingconfigBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tsettingconfig> GetTheData(IdInputDTO input)
        {
            return await _tsettingconfigBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tsettingconfig data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tsettingconfigBus.AddDataAsync(data);
            }
            else
            {
                await _tsettingconfigBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tsettingconfigBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}