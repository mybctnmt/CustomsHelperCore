using Coldairarrow.Business.Nems;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Nems
{
    [Route("/Nems/[controller]/[action]")]
    public class tnemsacmprlmessageController : BaseApiController
    {
        #region DI

        public tnemsacmprlmessageController(ItnemsacmprlmessageBusiness tnemsacmprlmessageBus)
        {
            _tnemsacmprlmessageBus = tnemsacmprlmessageBus;
        }

        ItnemsacmprlmessageBusiness _tnemsacmprlmessageBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tnemsacmprlmessage>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tnemsacmprlmessageBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tnemsacmprlmessage> GetTheData(IdInputDTO input)
        {
            return await _tnemsacmprlmessageBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tnemsacmprlmessage data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tnemsacmprlmessageBus.AddDataAsync(data);
            }
            else
            {
                await _tnemsacmprlmessageBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tnemsacmprlmessageBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}