using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdeclistController : BaseApiController
    {
        #region DI

        public tdeclistController(ItdeclistBusiness tdeclistBus)
        {
            _tdeclistBus = tdeclistBus;
        }

        ItdeclistBusiness _tdeclistBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdeclist>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdeclistBus.GetDataListAsync(input);
        }
        [HttpGet]
        public async Task<List<tdeclist>> GNameQueryAsync(string OwnerCode, string GName, string CodeTS)
        {
            return await _tdeclistBus.GNameQueryAsync(OwnerCode, GName, CodeTS);
        }

        //[HttpGet]
        //public async Task<List<tdeclist>> GetDataByCodeTS(string codeTS, string tradeCurr, string tradeName)
        //{
        //    return await _tdeclistBus.GetDataByCodeTS(codeTS, tradeCurr, tradeName);
        //}
        

        [HttpPost]
        public async Task<List<tdeclist>> GetDataByCodeTS(CodeTSDTO codeTSDTO)
        {
            return await _tdeclistBus.GetDataByCodeTS(codeTSDTO);
        }

        [HttpPost]
        public async Task<tdeclist> GetTheData(IdInputDTO input)
        {
            return await _tdeclistBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdeclist data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdeclistBus.AddDataAsync(data);
            }
            else
            {
                await _tdeclistBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdeclistBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}