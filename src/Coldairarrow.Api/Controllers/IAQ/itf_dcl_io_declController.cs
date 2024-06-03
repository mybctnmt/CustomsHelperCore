using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_declController : BaseApiController
    {
        #region DI

        public itf_dcl_io_declController(Iitf_dcl_io_declBusiness itf_dcl_io_declBus)
        {
            _itf_dcl_io_declBus = itf_dcl_io_declBus;
        }

        Iitf_dcl_io_declBusiness _itf_dcl_io_declBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_declBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_declBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_declBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_declBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_declBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}