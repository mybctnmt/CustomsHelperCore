using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_mark_lobController : BaseApiController
    {
        #region DI

        public itf_dcl_mark_lobController(Iitf_dcl_mark_lobBusiness itf_dcl_mark_lobBus)
        {
            _itf_dcl_mark_lobBus = itf_dcl_mark_lobBus;
        }

        Iitf_dcl_mark_lobBusiness _itf_dcl_mark_lobBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_mark_lob>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_mark_lobBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_mark_lob> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_mark_lobBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_mark_lob data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_mark_lobBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_mark_lobBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_mark_lobBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}