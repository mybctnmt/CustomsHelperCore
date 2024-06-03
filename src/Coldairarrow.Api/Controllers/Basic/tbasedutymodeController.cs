using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasedutymodeController : BaseApiController
    {
        #region DI

        public tbasedutymodeController(ItbasedutymodeBusiness tbasedutymodeBus)
        {
            _tbasedutymodeBus = tbasedutymodeBus;
        }

        ItbasedutymodeBusiness _tbasedutymodeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasedutymode>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasedutymodeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasedutymode> GetTheData(IdInputDTO input)
        {
            return await _tbasedutymodeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasedutymode data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasedutymodeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasedutymodeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasedutymodeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}