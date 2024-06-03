using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_ciq_dataController : BaseApiController
    {
        #region DI

        public itf_ciq_dataController(Iitf_ciq_dataBusiness itf_ciq_dataBus)
        {
            _itf_ciq_dataBus = itf_ciq_dataBus;
        }

        Iitf_ciq_dataBusiness _itf_ciq_dataBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_ciq_data>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_ciq_dataBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_ciq_data> GetTheData(IdInputDTO input)
        {
            return await _itf_ciq_dataBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_ciq_data data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_ciq_dataBus.AddDataAsync(data);
            }
            else
            {
                await _itf_ciq_dataBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_ciq_dataBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}