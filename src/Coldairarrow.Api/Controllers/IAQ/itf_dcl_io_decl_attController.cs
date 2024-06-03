using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_attController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_attController(Iitf_dcl_io_decl_attBusiness itf_dcl_io_decl_attBus)
        {
            _itf_dcl_io_decl_attBus = itf_dcl_io_decl_attBus;
        }

        Iitf_dcl_io_decl_attBusiness _itf_dcl_io_decl_attBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_att>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_attBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_att> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_attBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_att data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_attBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_attBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_attBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}