using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasetradeController : BaseApiController
    {
        #region DI

        public tbasetradeController(ItbasetradeBusiness tbasetradeBus)
        {
            _tbasetradeBus = tbasetradeBus;
        }

        ItbasetradeBusiness _tbasetradeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasetrade>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasetradeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasetrade> GetTheData(IdInputDTO input)
        {
            return await _tbasetradeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasetrade data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasetradeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasetradeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasetradeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}