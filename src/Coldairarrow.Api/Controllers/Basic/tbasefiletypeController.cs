using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasefiletypeController : BaseApiController
    {
        #region DI

        public tbasefiletypeController(ItbasefiletypeBusiness tbasefiletypeBus)
        {
            _tbasefiletypeBus = tbasefiletypeBus;
        }

        ItbasefiletypeBusiness _tbasefiletypeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasefiletype>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasefiletypeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasefiletype> GetTheData(IdInputDTO input)
        {
            return await _tbasefiletypeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasefiletype data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbasefiletypeBus.AddDataAsync(data);
            }
            else
            {
                await _tbasefiletypeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasefiletypeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}