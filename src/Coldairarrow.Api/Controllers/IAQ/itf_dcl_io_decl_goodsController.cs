using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_goodsController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_goodsController(Iitf_dcl_io_decl_goodsBusiness itf_dcl_io_decl_goodsBus)
        {
            _itf_dcl_io_decl_goodsBus = itf_dcl_io_decl_goodsBus;
        }

        Iitf_dcl_io_decl_goodsBusiness _itf_dcl_io_decl_goodsBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_goods>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_goodsBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_goods> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_goodsBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_goods data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_goodsBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_goodsBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_goodsBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}