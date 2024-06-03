using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class opertypeController : BaseApiController
    {
        #region DI

        public opertypeController(IopertypeBusiness opertypeBus)
        {
            _opertypeBus = opertypeBus;
        }

        IopertypeBusiness _opertypeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<opertype>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _opertypeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<opertype> GetTheData(IdInputDTO input)
        {
            return await _opertypeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(opertype data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _opertypeBus.AddDataAsync(data);
            }
            else
            {
                await _opertypeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _opertypeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}