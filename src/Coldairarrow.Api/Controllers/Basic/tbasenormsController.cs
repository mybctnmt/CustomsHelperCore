using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasenormsController : BaseApiController
    {
        #region DI

        public tbasenormsController(ItbasenormsBusiness tbasenormsBus)
        {
            _tbasenormsBus = tbasenormsBus;
        }

        ItbasenormsBusiness _tbasenormsBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasenorms>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasenormsBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasenorms> GetTheData(IdInputDTO input)
        {
            return await _tbasenormsBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasenorms data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasenormsBus.AddDataAsync(data);
            }
            else
            {
                await _tbasenormsBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasenormsBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}