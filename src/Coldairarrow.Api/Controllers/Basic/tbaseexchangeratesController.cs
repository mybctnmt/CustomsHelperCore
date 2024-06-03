using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseexchangeratesController : BaseApiController
    {
        #region DI

        public tbaseexchangeratesController(ItbaseexchangeratesBusiness tbaseexchangeratesBus)
        {
            _tbaseexchangeratesBus = tbaseexchangeratesBus;
        }

        ItbaseexchangeratesBusiness _tbaseexchangeratesBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseexchangerates>> GetDataList(PageInput<List<ConditionDTO>> input)
        {
            return await _tbaseexchangeratesBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseexchangerates> GetTheData(IdInputDTO input)
        {
            return await _tbaseexchangeratesBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseexchangerates data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseexchangeratesBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseexchangeratesBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseexchangeratesBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}