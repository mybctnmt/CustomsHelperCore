using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_goods_limitController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_goods_limitController(Iitf_dcl_io_decl_goods_limitBusiness itf_dcl_io_decl_goods_limitBus)
        {
            _itf_dcl_io_decl_goods_limitBus = itf_dcl_io_decl_goods_limitBus;
        }

        Iitf_dcl_io_decl_goods_limitBusiness _itf_dcl_io_decl_goods_limitBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_goods_limit>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_goods_limitBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_goods_limit> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_goods_limitBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_goods_limit data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_goods_limitBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_goods_limitBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_goods_limitBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}