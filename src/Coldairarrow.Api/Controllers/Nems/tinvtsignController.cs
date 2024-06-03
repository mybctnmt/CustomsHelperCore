using Coldairarrow.Business.Nems;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Nems
{
    [Route("/Nems/[controller]/[action]")]
    public class tinvtsignController : BaseApiController
    {
        #region DI

        public tinvtsignController(ItinvtsignBusiness tinvtsignBus)
        {
            _tinvtsignBus = tinvtsignBus;
        }

        ItinvtsignBusiness _tinvtsignBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tinvtsign>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tinvtsignBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tinvtsign> GetTheData(IdInputDTO input)
        {
            return await _tinvtsignBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tinvtsign data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tinvtsignBus.AddDataAsync(data);
            }
            else
            {
                await _tinvtsignBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tinvtsignBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}