using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseentrytypeController : BaseApiController
    {
        #region DI

        public tbaseentrytypeController(ItbaseentrytypeBusiness tbaseentrytypeBus)
        {
            _tbaseentrytypeBus = tbaseentrytypeBus;
        }

        ItbaseentrytypeBusiness _tbaseentrytypeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseentrytype>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseentrytypeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseentrytype> GetTheData(IdInputDTO input)
        {
            return await _tbaseentrytypeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseentrytype data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseentrytypeBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseentrytypeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseentrytypeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}