using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdeccoplimitController : BaseApiController
    {
        #region DI

        public tdeccoplimitController(ItdeccoplimitBusiness tdeccoplimitBus)
        {
            _tdeccoplimitBus = tdeccoplimitBus;
        }

        ItdeccoplimitBusiness _tdeccoplimitBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdeccoplimit>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdeccoplimitBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdeccoplimit> GetTheData(IdInputDTO input)
        {
            return await _tdeccoplimitBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdeccoplimit data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdeccoplimitBus.AddDataAsync(data);
            }
            else
            {
                await _tdeccoplimitBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdeccoplimitBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}