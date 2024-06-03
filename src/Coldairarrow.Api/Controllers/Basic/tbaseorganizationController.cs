using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseorganizationController : BaseApiController
    {
        #region DI

        public tbaseorganizationController(ItbaseorganizationBusiness tbaseorganizationBus)
        {
            _tbaseorganizationBus = tbaseorganizationBus;
        }

        ItbaseorganizationBusiness _tbaseorganizationBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseorganization>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseorganizationBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseorganization> GetTheData(IdInputDTO input)
        {
            return await _tbaseorganizationBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseorganization data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseorganizationBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseorganizationBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseorganizationBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}