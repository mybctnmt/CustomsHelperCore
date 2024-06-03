using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class ciq_retController : BaseApiController
    {
        #region DI

        public ciq_retController(Iciq_retBusiness ciq_retBus)
        {
            _ciq_retBus = ciq_retBus;
        }

        Iciq_retBusiness _ciq_retBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ciq_ret>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ciq_retBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ciq_ret> GetTheData(IdInputDTO input)
        {
            return await _ciq_retBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ciq_ret data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ciq_retBus.AddDataAsync(data);
            }
            else
            {
                await _ciq_retBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ciq_retBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}