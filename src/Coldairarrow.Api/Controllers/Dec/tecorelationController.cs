using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tecorelationController : BaseApiController
    {
        #region DI

        public tecorelationController(ItecorelationBusiness tecorelationBus)
        {
            _tecorelationBus = tecorelationBus;
        }

        ItecorelationBusiness _tecorelationBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tecorelation>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tecorelationBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tecorelation> GetTheData(IdInputDTO input)
        {
            return await _tecorelationBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tecorelation data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tecorelationBus.AddDataAsync(data);
            }
            else
            {
                await _tecorelationBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tecorelationBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}