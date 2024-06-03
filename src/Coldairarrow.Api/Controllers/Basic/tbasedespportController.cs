using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasedespportController : BaseApiController
    {
        #region DI

        public tbasedespportController(ItbasedespportBusiness tbasedespportBus)
        {
            _tbasedespportBus = tbasedespportBus;
        }

        ItbasedespportBusiness _tbasedespportBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasedespport>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasedespportBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasedespport> GetTheData(IdInputDTO input)
        {
            return await _tbasedespportBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasedespport data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasedespportBus.AddDataAsync(data);
            }
            else
            {
                await _tbasedespportBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasedespportBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}