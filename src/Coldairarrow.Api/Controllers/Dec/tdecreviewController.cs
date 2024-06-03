using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecreviewController : BaseApiController
    {
        #region DI

        public tdecreviewController(ItdecreviewBusiness tdecreviewBus)
        {
            _tdecreviewBus = tdecreviewBus;
        }

        ItdecreviewBusiness _tdecreviewBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecreview>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecreviewBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecreview> GetTheData(IdInputDTO input)
        {
            return await _tdecreviewBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecreview data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecreviewBus.AddDataAsync(data);
            }
            else
            {
                await _tdecreviewBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecreviewBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}