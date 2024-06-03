using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseacmpformController : BaseApiController
    {
        #region DI

        public tbaseacmpformController(ItbaseacmpformBusiness tbaseacmpformBus)
        {
            _tbaseacmpformBus = tbaseacmpformBus;
        }

        ItbaseacmpformBusiness _tbaseacmpformBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseacmpform>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseacmpformBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseacmpform> GetTheData(IdInputDTO input)
        {
            return await _tbaseacmpformBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseacmpform data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseacmpformBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseacmpformBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseacmpformBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}