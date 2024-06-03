using Coldairarrow.Business.Fieldwork;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Fieldwork
{
    [Route("/Fieldwork/[controller]/[action]")]
    public class ttaskcostController : BaseApiController
    {
        #region DI

        public ttaskcostController(IQingdaoBusiness ttaskcostBus)
        {
            _ttaskcostBus = ttaskcostBus;
        }

        IQingdaoBusiness _ttaskcostBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttaskcost>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _ttaskcostBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttaskcost> GetTheData(IdInputDTO input)
        {
            return await _ttaskcostBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ttaskcost data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttaskcostBus.AddDataAsync(data);
            }
            else
            {
                await _ttaskcostBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttaskcostBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}