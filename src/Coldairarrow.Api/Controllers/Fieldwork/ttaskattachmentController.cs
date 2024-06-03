using Coldairarrow.Business.Fieldwork;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Fieldwork
{
    [Route("/Fieldwork/[controller]/[action]")]
    public class ttaskattachmentController : BaseApiController
    {
        #region DI

        public ttaskattachmentController(IttaskattachmentBusiness ttaskattachmentBus)
        {
            _ttaskattachmentBus = ttaskattachmentBus;
        }

        IttaskattachmentBusiness _ttaskattachmentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttaskattachment>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttaskattachmentBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttaskattachment> GetTheData(IdInputDTO input)
        {
            return await _ttaskattachmentBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttaskattachment data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttaskattachmentBus.AddDataAsync(data);
            }
            else
            {
                await _ttaskattachmentBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttaskattachmentBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}