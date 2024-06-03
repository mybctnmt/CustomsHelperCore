using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaselicense_eController : BaseApiController
    {
        #region DI

        public tbaselicense_eController(Itbaselicense_eBusiness tbaselicense_eBus)
        {
            _tbaselicense_eBus = tbaselicense_eBus;
        }

        Itbaselicense_eBusiness _tbaselicense_eBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaselicense_e>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaselicense_eBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaselicense_e> GetTheData(IdInputDTO input)
        {
            return await _tbaselicense_eBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaselicense_e data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaselicense_eBus.AddDataAsync(data);
            }
            else
            {
                await _tbaselicense_eBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaselicense_eBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}