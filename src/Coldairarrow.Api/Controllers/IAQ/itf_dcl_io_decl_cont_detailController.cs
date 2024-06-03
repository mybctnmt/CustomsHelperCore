using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dcl_io_decl_cont_detailController : BaseApiController
    {
        #region DI

        public itf_dcl_io_decl_cont_detailController(Iitf_dcl_io_decl_cont_detailBusiness itf_dcl_io_decl_cont_detailBus)
        {
            _itf_dcl_io_decl_cont_detailBus = itf_dcl_io_decl_cont_detailBus;
        }

        Iitf_dcl_io_decl_cont_detailBusiness _itf_dcl_io_decl_cont_detailBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dcl_io_decl_cont_detail>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dcl_io_decl_cont_detailBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dcl_io_decl_cont_detail> GetTheData(IdInputDTO input)
        {
            return await _itf_dcl_io_decl_cont_detailBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dcl_io_decl_cont_detail data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dcl_io_decl_cont_detailBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dcl_io_decl_cont_detailBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dcl_io_decl_cont_detailBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}