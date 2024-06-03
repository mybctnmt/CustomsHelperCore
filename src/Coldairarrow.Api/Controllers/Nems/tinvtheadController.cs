using Coldairarrow.Business.Nems;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Nems
{
    [Route("/Nems/[controller]/[action]")]
    public class tinvtheadController : BaseApiController
    {
        #region DI

        public tinvtheadController(ItinvtheadBusiness tinvtheadBus)
        {
            _tinvtheadBus = tinvtheadBus;
        }

        ItinvtheadBusiness _tinvtheadBus { get; }

        #endregion

        #region 获取

        [HttpGet]
        public async Task<tinvtinfo> GetInvtInfo(string orderNo)
        {
            return await _tinvtheadBus.GetDecInfo(orderNo);
        }

        [HttpPost]
        public async Task<PageResult<tinvthead>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tinvtheadBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tinvthead> GetTheData(IdInputDTO input)
        {
            return await _tinvtheadBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tinvthead data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tinvtheadBus.AddDataAsync(data);
            }
            else
            {
                await _tinvtheadBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tinvtheadBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}