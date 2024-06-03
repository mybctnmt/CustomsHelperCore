using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class ttrncontainerController : BaseApiController
    {
        #region DI

        public ttrncontainerController(IttrncontainerBusiness ttrncontainerBus)
        {
            _ttrncontainerBus = ttrncontainerBus;
        }

        IttrncontainerBusiness _ttrncontainerBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttrncontainer>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttrncontainerBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttrncontainer> GetTheData(IdInputDTO input)
        {
            return await _ttrncontainerBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttrncontainer data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttrncontainerBus.AddDataAsync(data);
            }
            else
            {
                await _ttrncontainerBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttrncontainerBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}