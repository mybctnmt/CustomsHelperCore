using Coldairarrow.Business.Remind;
using Coldairarrow.Entity.Remind;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Remind
{
    [Route("/Remind/[controller]/[action]")]
    public class treminderrecordController : BaseApiController
    {
        #region DI

        public treminderrecordController(ItreminderrecordBusiness treminderrecordBus)
        {
            _treminderrecordBus = treminderrecordBus;
        }

        ItreminderrecordBusiness _treminderrecordBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<treminderrecord>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _treminderrecordBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<treminderrecord> GetTheData(IdInputDTO input)
        {
            return await _treminderrecordBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(treminderrecord data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _treminderrecordBus.AddDataAsync(data);
            }
            else
            {
                await _treminderrecordBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _treminderrecordBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}