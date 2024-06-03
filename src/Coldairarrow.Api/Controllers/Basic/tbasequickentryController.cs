using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasequickentryController : BaseApiController
    {
        #region DI

        public tbasequickentryController(ItbasequickentryBusiness tbasequickentryBus)
        {
            _tbasequickentryBus = tbasequickentryBus;
        }

        ItbasequickentryBusiness _tbasequickentryBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasequickentry>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasequickentryBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasequickentry> GetTheData(IdInputDTO input)
        {
            return await _tbasequickentryBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasequickentry data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasequickentryBus.AddDataAsync(data);
            }
            else
            {
                await _tbasequickentryBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasequickentryBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}