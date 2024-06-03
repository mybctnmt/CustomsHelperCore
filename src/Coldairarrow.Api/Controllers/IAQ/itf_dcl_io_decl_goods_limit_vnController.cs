using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_goods_limit_vnController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_goods_limit_vnController(Iitf_dcl_io_decl_goods_limit_vnBusiness itf_dcl_io_decl_goods_limit_vnBus)
        {
            _itf_dcl_io_decl_goods_limit_vnBus = itf_dcl_io_decl_goods_limit_vnBus;
        }

        Iitf_dcl_io_decl_goods_limit_vnBusiness _itf_dcl_io_decl_goods_limit_vnBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_goods_limit_vn>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_goods_limit_vnBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_goods_limit_vn> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_goods_limit_vnBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_goods_limit_vn data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_goods_limit_vnBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_goods_limit_vnBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_goods_limit_vnBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}