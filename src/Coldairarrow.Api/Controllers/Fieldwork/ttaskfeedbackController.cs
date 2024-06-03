using Coldairarrow.Business.Fieldwork;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Fieldwork
{
    [Route("/Fieldwork/[controller]/[action]")]
    public class ttaskfeedbackController : BaseApiController
    {
        #region DI

        public ttaskfeedbackController(IttaskfeedbackBusiness ttaskfeedbackBus)
        {
            _ttaskfeedbackBus = ttaskfeedbackBus;
        }

        IttaskfeedbackBusiness _ttaskfeedbackBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttaskfeedback>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttaskfeedbackBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttaskfeedback> GetTheData(IdInputDTO input)
        {
            return await _ttaskfeedbackBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttaskfeedback data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttaskfeedbackBus.AddDataAsync(data);
            }
            else
            {
                await _ttaskfeedbackBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttaskfeedbackBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}