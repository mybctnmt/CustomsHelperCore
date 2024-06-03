using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdeccontainerController : BaseApiController
    {
        #region DI

        public tdeccontainerController(ItdeccontainerBusiness tdeccontainerBus)
        {
            _tdeccontainerBus = tdeccontainerBus;
        }

        ItdeccontainerBusiness _tdeccontainerBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdeccontainer>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdeccontainerBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdeccontainer> GetTheData(IdInputDTO input)
        {
            return await _tdeccontainerBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdeccontainer data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdeccontainerBus.AddDataAsync(data);
            }
            else
            {
                await _tdeccontainerBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdeccontainerBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}