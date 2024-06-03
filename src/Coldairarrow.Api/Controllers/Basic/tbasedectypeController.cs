using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasedectypeController : BaseApiController
    {
        #region DI

        public tbasedectypeController(ItbasedectypeBusiness tbasedectypeBus)
        {
            _tbasedectypeBus = tbasedectypeBus;
        }

        ItbasedectypeBusiness _tbasedectypeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasedectype>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasedectypeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasedectype> GetTheData(IdInputDTO input)
        {
            return await _tbasedectypeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasedectype data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasedectypeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasedectypeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasedectypeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}