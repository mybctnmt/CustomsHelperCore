using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasetransmodeController : BaseApiController
    {
        #region DI

        public tbasetransmodeController(ItbasetransmodeBusiness tbasetransmodeBus)
        {
            _tbasetransmodeBus = tbasetransmodeBus;
        }

        ItbasetransmodeBusiness _tbasetransmodeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasetransmode>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasetransmodeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasetransmode> GetTheData(IdInputDTO input)
        {
            return await _tbasetransmodeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasetransmode data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasetransmodeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasetransmodeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasetransmodeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}