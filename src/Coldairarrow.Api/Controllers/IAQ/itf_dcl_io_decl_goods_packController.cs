using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_goods_packController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_goods_packController(Iitf_dcl_io_decl_goods_packBusiness itf_dcl_io_decl_goods_packBus)
        {
            _itf_dcl_io_decl_goods_packBus = itf_dcl_io_decl_goods_packBus;
        }

        Iitf_dcl_io_decl_goods_packBusiness _itf_dcl_io_decl_goods_packBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_goods_pack>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_goods_packBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_goods_pack> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_goods_packBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_goods_pack data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_goods_packBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_goods_packBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_goods_packBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}