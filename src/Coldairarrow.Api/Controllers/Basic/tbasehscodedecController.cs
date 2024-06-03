using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasehscodedecController : BaseApiController
    {
        #region DI

        public tbasehscodedecController(ItbasehscodedecBusiness tbasehscodedecBus)
        {
            _tbasehscodedecBus = tbasehscodedecBus;
        }

        ItbasehscodedecBusiness _tbasehscodedecBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasehscodedec>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasehscodedecBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasehscodedec> GetTheData(IdInputDTO input)
        {
            return await _tbasehscodedecBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasehscodedec data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasehscodedecBus.AddDataAsync(data);
            }
            else
            {
                await _tbasehscodedecBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasehscodedecBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}