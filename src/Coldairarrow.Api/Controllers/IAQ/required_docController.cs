using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class required_docController : BaseApiController
    {
        #region DI

        public required_docController(Irequired_docBusiness required_docBus)
        {
            _required_docBus = required_docBus;
        }

        Irequired_docBusiness _required_docBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<required_doc>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _required_docBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<required_doc> GetTheData(IdInputDTO input)
        {
            return await _required_docBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(required_doc data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _required_docBus.AddDataAsync(data);
            }
            else
            {
                await _required_docBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _required_docBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}