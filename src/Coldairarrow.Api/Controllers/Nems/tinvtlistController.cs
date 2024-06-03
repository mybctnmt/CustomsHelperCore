using Coldairarrow.Business.Nems;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Nems
{
    [Route("/Nems/[controller]/[action]")]
    public class tinvtlistController : BaseApiController
    {
        #region DI

        public tinvtlistController(ItinvtlistBusiness tinvtlistBus)
        {
            _tinvtlistBus = tinvtlistBus;
        }

        ItinvtlistBusiness _tinvtlistBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tinvtlist>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tinvtlistBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tinvtlist> GetTheData(IdInputDTO input)
        {
            return await _tinvtlistBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tinvtlist data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tinvtlistBus.AddDataAsync(data);
            }
            else
            {
                await _tinvtlistBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tinvtlistBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}