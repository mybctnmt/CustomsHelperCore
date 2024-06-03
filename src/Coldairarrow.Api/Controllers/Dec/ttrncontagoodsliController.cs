using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class ttrncontagoodsliController : BaseApiController
    {
        #region DI

        public ttrncontagoodsliController(IttrncontagoodsliBusiness ttrncontagoodsliBus)
        {
            _ttrncontagoodsliBus = ttrncontagoodsliBus;
        }

        IttrncontagoodsliBusiness _ttrncontagoodsliBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttrncontagoodsli>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttrncontagoodsliBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttrncontagoodsli> GetTheData(IdInputDTO input)
        {
            return await _ttrncontagoodsliBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttrncontagoodsli data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttrncontagoodsliBus.AddDataAsync(data);
            }
            else
            {
                await _ttrncontagoodsliBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttrncontagoodsliBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}