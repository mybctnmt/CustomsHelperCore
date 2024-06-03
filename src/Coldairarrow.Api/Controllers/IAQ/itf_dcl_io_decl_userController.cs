using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_userController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_userController(Iitf_dcl_io_decl_userBusiness itf_dcl_io_decl_userBus)
        {
            _itf_dcl_io_decl_userBus = itf_dcl_io_decl_userBus;
        }

        Iitf_dcl_io_decl_userBusiness _itf_dcl_io_decl_userBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_user>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_userBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_user> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_userBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_user data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_userBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_userBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_userBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}