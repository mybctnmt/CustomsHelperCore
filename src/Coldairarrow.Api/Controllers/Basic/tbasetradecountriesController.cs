using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasetradecountriesController : BaseApiController
    {
        #region DI

        public tbasetradecountriesController(ItbasetradecountriesBusiness tradecountriesBus)
        {
            _tradecountriesBus = tradecountriesBus;
        }

        ItbasetradecountriesBusiness _tradecountriesBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasetradecountries>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tradecountriesBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasetradecountries> GetTheData(IdInputDTO input)
        {
            return await _tradecountriesBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasetradecountries data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tradecountriesBus.AddDataAsync(data);
            }
            else
            {
                await _tradecountriesBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tradecountriesBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}