using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecustomerrelationController : BaseApiController
    {
        #region DI

        public tbasecustomerrelationController(ItbasecustomerrelationBusiness tbasecustomerrelationBus)
        {
            _tbasecustomerrelationBus = tbasecustomerrelationBus;
        }

        ItbasecustomerrelationBusiness _tbasecustomerrelationBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecustomerrelation>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecustomerrelationBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecustomerrelation> GetTheData(IdInputDTO input)
        {
            return await _tbasecustomerrelationBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecustomerrelation data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecustomerrelationBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecustomerrelationBus.UpdateDataAsync(data);
            }
        }


        [HttpPost]
        public async Task SaveDatas([FromQuery]string cid, List<tbasecustomerrelation> datalist)
        {
            foreach (var item in datalist)
            {
                InitEntity(item);
            }
            await _tbasecustomerrelationBus.SaveDatas(cid, datalist);
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecustomerrelationBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}