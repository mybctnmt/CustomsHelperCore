using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecustomerbankController : BaseApiController
    {
        #region DI

        public tbasecustomerbankController(ItbasecustomerbankBusiness tbasecustomerbankBus)
        {
            _tbasecustomerbankBus = tbasecustomerbankBus;
        }

        ItbasecustomerbankBusiness _tbasecustomerbankBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecustomerbank>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecustomerbankBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecustomerbank> GetTheData(IdInputDTO input)
        {
            return await _tbasecustomerbankBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task<string> SaveData(tbasecustomerbank data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                return await _tbasecustomerbankBus.AddDataAsync(data);
            }
            else
            {
                return await _tbasecustomerbankBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task SaveDatas([FromQuery] string cid, List<tbasecustomerbank> datalist)
        {
            foreach (var item in datalist)
            {
                InitEntity(item);
            }
            await _tbasecustomerbankBus.SaveDatas(cid, datalist);
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecustomerbankBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}