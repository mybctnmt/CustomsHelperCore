using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecgoodslimitController : BaseApiController
    {
        #region DI

        public tdecgoodslimitController(ItdecgoodslimitBusiness tdecgoodslimitBus)
        {
            _tdecgoodslimitBus = tdecgoodslimitBus;
        }

        ItdecgoodslimitBusiness _tdecgoodslimitBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecgoodslimit>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecgoodslimitBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecgoodslimit> GetTheData(IdInputDTO input)
        {
            return await _tdecgoodslimitBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecgoodslimit data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecgoodslimitBus.AddDataAsync(data);
            }
            else
            {
                await _tdecgoodslimitBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecgoodslimitBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}