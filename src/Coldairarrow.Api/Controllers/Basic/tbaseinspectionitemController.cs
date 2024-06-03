using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseinspectionitemController : BaseApiController
    {
        #region DI

        public tbaseinspectionitemController(ItbaseinspectionitemBusiness tbaseinspectionitemBus)
        {
            _tbaseinspectionitemBus = tbaseinspectionitemBus;
        }

        ItbaseinspectionitemBusiness _tbaseinspectionitemBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseinspectionitem>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseinspectionitemBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseinspectionitem> GetTheData(IdInputDTO input)
        {
            return await _tbaseinspectionitemBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseinspectionitem data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseinspectionitemBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseinspectionitemBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseinspectionitemBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}