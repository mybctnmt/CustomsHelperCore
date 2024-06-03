using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class itf_dec_dataController : BaseApiController
    {
        #region DI

        public itf_dec_dataController(Iitf_dec_dataBusiness itf_dec_dataBus)
        {
            _itf_dec_dataBus = itf_dec_dataBus;
        }

        Iitf_dec_dataBusiness _itf_dec_dataBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<itf_dec_data>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _itf_dec_dataBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<itf_dec_data> GetTheData(IdInputDTO input)
        {
            return await _itf_dec_dataBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(itf_dec_data data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _itf_dec_dataBus.AddDataAsync(data);
            }
            else
            {
                await _itf_dec_dataBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _itf_dec_dataBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}