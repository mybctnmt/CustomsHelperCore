using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecrequestcertController : BaseApiController
    {
        #region DI

        public tdecrequestcertController(ItdecrequestcertBusiness tdecrequestcertBus)
        {
            _tdecrequestcertBus = tdecrequestcertBus;
        }

        ItdecrequestcertBusiness _tdecrequestcertBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecrequestcert>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecrequestcertBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecrequestcert> GetTheData(IdInputDTO input)
        {
            return await _tdecrequestcertBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecrequestcert data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecrequestcertBus.AddDataAsync(data);
            }
            else
            {
                await _tdecrequestcertBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecrequestcertBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}