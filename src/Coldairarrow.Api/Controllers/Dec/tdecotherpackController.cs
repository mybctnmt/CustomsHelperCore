using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecotherpackController : BaseApiController
    {
        #region DI

        public tdecotherpackController(ItdecotherpackBusiness tdecotherpackBus)
        {
            _tdecotherpackBus = tdecotherpackBus;
        }

        ItdecotherpackBusiness _tdecotherpackBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecotherpack>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecotherpackBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecotherpack> GetTheData(IdInputDTO input)
        {
            return await _tdecotherpackBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecotherpack data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecotherpackBus.AddDataAsync(data);
            }
            else
            {
                await _tdecotherpackBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecotherpackBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}