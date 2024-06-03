using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tsddtaxlistsController : BaseApiController
    {
        #region DI

        public tsddtaxlistsController(ItsddtaxlistsBusiness tsddtaxlistsBus)
        {
            _tsddtaxlistsBus = tsddtaxlistsBus;
        }

        ItsddtaxlistsBusiness _tsddtaxlistsBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tsddtaxlists>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tsddtaxlistsBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tsddtaxlists> GetTheData(IdInputDTO input)
        {
            return await _tsddtaxlistsBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tsddtaxlists data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tsddtaxlistsBus.AddDataAsync(data);
            }
            else
            {
                await _tsddtaxlistsBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tsddtaxlistsBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}