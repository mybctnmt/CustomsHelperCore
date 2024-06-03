using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_sub_signed_infoController : BaseApiController
    {
        #region DI

        public itf_sub_signed_infoController(Iitf_sub_signed_infoBusiness itf_sub_signed_infoBus)
        {
            _itf_sub_signed_infoBus = itf_sub_signed_infoBus;
        }

        Iitf_sub_signed_infoBusiness _itf_sub_signed_infoBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_sub_signed_info>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_sub_signed_infoBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_sub_signed_info> GetTheData(IdInputDTO input)
        {
            return await _itf_sub_signed_infoBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_sub_signed_info data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_sub_signed_infoBus.AddDataAsync(data);
            }
            else
            {
                await _itf_sub_signed_infoBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_sub_signed_infoBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}