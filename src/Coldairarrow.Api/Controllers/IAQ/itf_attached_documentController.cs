using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_attached_documentController : BaseApiController
    {
        #region DI

        public itf_attached_documentController(Iitf_attached_documentBusiness itf_attached_documentBus)
        {
            _itf_attached_documentBus = itf_attached_documentBus;
        }

        Iitf_attached_documentBusiness _itf_attached_documentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_attached_document>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_attached_documentBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_attached_document> GetTheData(IdInputDTO input)
        {
            return await _itf_attached_documentBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_attached_document data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_attached_documentBus.AddDataAsync(data);
            }
            else
            {
                await _itf_attached_documentBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_attached_documentBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}