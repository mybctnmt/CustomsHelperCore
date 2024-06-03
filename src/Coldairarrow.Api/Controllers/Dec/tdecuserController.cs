using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecuserController : BaseApiController
    {
        #region DI

        public tdecuserController(ItdecuserBusiness tdecuserBus)
        {
            _tdecuserBus = tdecuserBus;
        }

        ItdecuserBusiness _tdecuserBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecuser>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecuserBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecuser> GetTheData(IdInputDTO input)
        {
            return await _tdecuserBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecuser data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecuserBus.AddDataAsync(data);
            }
            else
            {
                await _tdecuserBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecuserBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}