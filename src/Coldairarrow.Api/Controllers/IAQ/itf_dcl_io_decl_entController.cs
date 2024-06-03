using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_entController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_entController(Iitf_dcl_io_decl_entBusiness itf_dcl_io_decl_entBus)
        {
            _itf_dcl_io_decl_entBus = itf_dcl_io_decl_entBus;
        }

        Iitf_dcl_io_decl_entBusiness _itf_dcl_io_decl_entBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_ent>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_entBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_ent> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_entBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_ent data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_entBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_entBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_entBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}