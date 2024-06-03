using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Inbox
{
    [Route("/Inbox/[controller]/[action]")]
    public class tinboxconfigController : BaseApiController
    {
        #region DI

        public tinboxconfigController(ItinboxconfigBusiness tinboxconfigBus)
        {
            _tinboxconfigBus = tinboxconfigBus;
        }

        ItinboxconfigBusiness _tinboxconfigBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tinboxconfig>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tinboxconfigBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tinboxconfig> GetTheData(IdInputDTO input)
        {
            return await _tinboxconfigBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tinboxconfig data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tinboxconfigBus.AddDataAsync(data);
            }
            else
            {
                await _tinboxconfigBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tinboxconfigBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}