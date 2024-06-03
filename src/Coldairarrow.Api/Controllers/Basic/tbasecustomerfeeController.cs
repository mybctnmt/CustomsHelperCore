using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecustomerfeeController : BaseApiController
    {
        #region DI

        public tbasecustomerfeeController(ItbasecustomerfeeBusiness tbasecustomerfeeBus)
        {
            _tbasecustomerfeeBus = tbasecustomerfeeBus;
        }

        ItbasecustomerfeeBusiness _tbasecustomerfeeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecustomerfee>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecustomerfeeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecustomerfee> GetTheData(IdInputDTO input)
        {
            return await _tbasecustomerfeeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task<string> SaveData(tbasecustomerfee data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                return await _tbasecustomerfeeBus.AddDataAsync(data);
            }
            else
            {
                return await _tbasecustomerfeeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task SaveDatas([FromQuery] string cid, List<tbasecustomerfee> datalist)
        {
            foreach (var item in datalist)
            {
                InitEntity(item);
            }
            await _tbasecustomerfeeBus.SaveDatas(cid, datalist);
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecustomerfeeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}