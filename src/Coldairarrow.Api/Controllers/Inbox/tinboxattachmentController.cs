using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Inbox
{
    [Route("/Inbox/[controller]/[action]")]
    public class tinboxattachmentController : BaseApiController
    {
        #region DI

        public tinboxattachmentController(ItinboxattachmentBusiness tinboxattachmentBus)
        {
            _tinboxattachmentBus = tinboxattachmentBus;
        }

        ItinboxattachmentBusiness _tinboxattachmentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tinboxattachment>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tinboxattachmentBus.GetDataListAsync(input);
        }
        [HttpPost]
        public async Task<List<tinboxattachment>> GetIDSDataList(List<string> ids)
        {
            return await _tinboxattachmentBus.GetDataListIDSAsync(ids);
        }
        [HttpGet]
        public async Task<List<tinboxattachment>> GetAttachmentList(string orderNo)
        {
            return await _tinboxattachmentBus.GetAttachmentList(orderNo);
        }
        [HttpPost]
        public async Task<tinboxattachment> GetTheData(IdInputDTO input)
        {
            return await _tinboxattachmentBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tinboxattachment data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tinboxattachmentBus.AddDataAsync(data);
            }
            else
            {
                await _tinboxattachmentBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tinboxattachmentBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}