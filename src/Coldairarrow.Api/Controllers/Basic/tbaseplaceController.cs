using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseplaceController : BaseApiController
    {
        #region DI

        public tbaseplaceController(ItbaseplaceBusiness tbaseplaceBus)
        {
            _tbaseplaceBus = tbaseplaceBus;
        }

        ItbaseplaceBusiness _tbaseplaceBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseplace>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseplaceBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseplace> GetTheData(IdInputDTO input)
        {
            return await _tbaseplaceBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseplace data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseplaceBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseplaceBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseplaceBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}