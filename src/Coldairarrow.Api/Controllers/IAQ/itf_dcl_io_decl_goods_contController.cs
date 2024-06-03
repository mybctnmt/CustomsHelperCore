using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_goods_contController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_goods_contController(Iitf_dcl_io_decl_goods_contBusiness itf_dcl_io_decl_goods_contBus)
        {
            _itf_dcl_io_decl_goods_contBus = itf_dcl_io_decl_goods_contBus;
        }

        Iitf_dcl_io_decl_goods_contBusiness _itf_dcl_io_decl_goods_contBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_goods_cont>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_goods_contBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_goods_cont> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_goods_contBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_goods_cont data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_goods_contBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_goods_contBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_goods_contBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}