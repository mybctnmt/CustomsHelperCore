using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasetransportController : BaseApiController
    {
        #region DI

        public tbasetransportController(ItbasetransportBusiness tbasetransportBus)
        {
            _tbasetransportBus = tbasetransportBus;
        }

        ItbasetransportBusiness _tbasetransportBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasetransport>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasetransportBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasetransport> GetTheData(IdInputDTO input)
        {
            return await _tbasetransportBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasetransport data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasetransportBus.AddDataAsync(data);
            }
            else
            {
                await _tbasetransportBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasetransportBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}