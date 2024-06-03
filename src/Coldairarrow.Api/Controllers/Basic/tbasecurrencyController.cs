﻿using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecurrencyController : BaseApiController
    {
        #region DI

        public tbasecurrencyController(ItbasecurrencyBusiness tbasecurrencyBus)
        {
            _tbasecurrencyBus = tbasecurrencyBus;
        }

        ItbasecurrencyBusiness _tbasecurrencyBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecurrency>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecurrencyBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecurrency> GetTheData(IdInputDTO input)
        {
            return await _tbasecurrencyBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasecurrency data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasecurrencyBus.AddDataAsync(data);
            }
            else
            {
                await _tbasecurrencyBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecurrencyBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}