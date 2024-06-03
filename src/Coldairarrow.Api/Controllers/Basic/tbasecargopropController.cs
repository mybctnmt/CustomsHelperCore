using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecargopropController : BaseApiController
    {
        #region DI

        public tbasecargopropController(ItbasecargopropBusiness tbasecargopropBus)
        {
            _tbasecargopropBus = tbasecargopropBus;
        }

        ItbasecargopropBusiness _tbasecargopropBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecargoprop>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecargopropBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecargoprop> GetTheData(IdInputDTO input)
        {
            return await _tbasecargopropBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecargoprop data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecargopropBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecargopropBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecargopropBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}