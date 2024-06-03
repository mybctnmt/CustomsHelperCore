using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tsddtaxdetailsController : BaseApiController
    {
        #region DI

        public tsddtaxdetailsController(ItsddtaxdetailsBusiness tsddtaxdetailsBus)
        {
            _tsddtaxdetailsBus = tsddtaxdetailsBus;
        }

        ItsddtaxdetailsBusiness _tsddtaxdetailsBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tsddtaxdetails>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tsddtaxdetailsBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tsddtaxdetails> GetTheData(IdInputDTO input)
        {
            return await _tsddtaxdetailsBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tsddtaxdetails data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tsddtaxdetailsBus.AddDataAsync(data);
            }
            else
            {
                await _tsddtaxdetailsBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tsddtaxdetailsBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}