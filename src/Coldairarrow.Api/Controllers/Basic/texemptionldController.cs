using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class texemptionldController : BaseApiController
    {
        #region DI

        public texemptionldController(ItexemptionldBusiness texemptionldBus)
        {
            _texemptionldBus = texemptionldBus;
        }

        ItexemptionldBusiness _texemptionldBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<texemptionld>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _texemptionldBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<texemptionld> GetTheData(IdInputDTO input)
        {
            return await _texemptionldBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(texemptionld data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _texemptionldBus.AddDataAsync(data);
            }
            else
            {
                await _texemptionldBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _texemptionldBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}