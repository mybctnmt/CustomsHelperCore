using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasepackagekindController : BaseApiController
    {
        #region DI

        public tbasepackagekindController(ItbasepackagekindBusiness tbasepackagekindBus)
        {
            _tbasepackagekindBus = tbasepackagekindBus;
        }

        ItbasepackagekindBusiness _tbasepackagekindBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasepackagekind>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasepackagekindBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasepackagekind> GetTheData(IdInputDTO input)
        {
            return await _tbasepackagekindBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasepackagekind data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasepackagekindBus.AddDataAsync(data);
            }
            else
            {
                await _tbasepackagekindBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasepackagekindBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}