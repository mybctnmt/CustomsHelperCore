using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class talarmconditionController : BaseApiController
    {
        #region DI

        public talarmconditionController(ItalarmconditionBusiness talarmconditionBus)
        {
            _talarmconditionBus = talarmconditionBus;
        }

        ItalarmconditionBusiness _talarmconditionBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<talarmcondition>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _talarmconditionBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<talarmcondition> GetTheData(IdInputDTO input)
        {
            return await _talarmconditionBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(talarmcondition data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _talarmconditionBus.AddDataAsync(data);
            }
            else
            {
                await _talarmconditionBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _talarmconditionBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}