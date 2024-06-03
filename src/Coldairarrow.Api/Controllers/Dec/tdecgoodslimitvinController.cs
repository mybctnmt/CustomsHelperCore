using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecgoodslimitvinController : BaseApiController
    {
        #region DI

        public tdecgoodslimitvinController(ItdecgoodslimitvinBusiness tdecgoodslimitvinBus)
        {
            _tdecgoodslimitvinBus = tdecgoodslimitvinBus;
        }

        ItdecgoodslimitvinBusiness _tdecgoodslimitvinBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecgoodslimitvin>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecgoodslimitvinBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecgoodslimitvin> GetTheData(IdInputDTO input)
        {
            return await _tdecgoodslimitvinBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecgoodslimitvin data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecgoodslimitvinBus.AddDataAsync(data);
            }
            else
            {
                await _tdecgoodslimitvinBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecgoodslimitvinBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}