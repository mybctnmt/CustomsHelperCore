using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasedestController : BaseApiController
    {
        #region DI

        
        public tbasedestController(ItbasedestBusiness tbasedestBus)
        {
            _tbasedestBus = tbasedestBus;
        }

        ItbasedestBusiness _tbasedestBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasedest>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasedestBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasedest> GetTheData(IdInputDTO input)
        {
            return await _tbasedestBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasedest data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasedestBus.AddDataAsync(data);
            }
            else
            {
                await _tbasedestBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasedestBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}