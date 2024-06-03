using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tsddtaxheadController : BaseApiController
    {
        #region DI

        public tsddtaxheadController(ItsddtaxheadBusiness tsddtaxheadBus)
        {
            _tsddtaxheadBus = tsddtaxheadBus;
        }

        ItsddtaxheadBusiness _tsddtaxheadBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tsddtaxhead>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tsddtaxheadBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tsddtaxhead> GetTheData(IdInputDTO input)
        {
            return await _tsddtaxheadBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tsddtaxhead data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tsddtaxheadBus.AddDataAsync(data);
            }
            else
            {
                await _tsddtaxheadBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tsddtaxheadBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}