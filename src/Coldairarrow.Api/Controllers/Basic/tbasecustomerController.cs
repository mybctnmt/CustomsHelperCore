using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecustomerController : BaseApiController
    {
        #region DI

        public tbasecustomerController(ItbasecustomerBusiness tbasecustomerBus)
        {
            _tbasecustomerBus = tbasecustomerBus;
        }

        ItbasecustomerBusiness _tbasecustomerBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecustomer>> GetDataList(PageInput<List<ConditionDTO>> input)
        {
            return await _tbasecustomerBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecustomer> GetTheData(IdInputDTO input)
        {
            return await _tbasecustomerBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task<string> SaveData(tbasecustomer data)
        {
            bool isRepeat = await _tbasecustomerBus.CheckRepeat(data);
            if (isRepeat)
            {
                throw new BusException("已经有此简称或全称的数据");
            }
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);
                return  await _tbasecustomerBus.AddDataAsync(data);
            }
            else
            {
                return await _tbasecustomerBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecustomerBus.DeleteDataAsync(ids);
        }

        #endregion

        #region 删除  审核  取消审核
        [HttpPost]
        public async Task Delete(IdInputDTO input)
        {
            await _tbasecustomerBus.DeleteData(input.id);
        }


        [HttpGet]
        public async Task Check(string id,string type)
        {
            await _tbasecustomerBus.Check(id,type);
        }
        #endregion

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task Import(DataTable dataTable)
        {
            await _tbasecustomerBus.Import(dataTable);
        }
    }
}