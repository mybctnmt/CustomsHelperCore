using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class ttrnlistController : BaseApiController
    {
        #region DI

        public ttrnlistController(IttrnlistBusiness ttrnlistBus)
        {
            _ttrnlistBus = ttrnlistBus;
        }

        IttrnlistBusiness _ttrnlistBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttrnlist>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttrnlistBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttrnlist> GetTheData(IdInputDTO input)
        {
            return await _ttrnlistBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttrnlist data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttrnlistBus.AddDataAsync(data);
            }
            else
            {
                await _ttrnlistBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttrnlistBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}