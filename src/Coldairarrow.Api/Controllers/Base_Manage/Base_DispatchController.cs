using Coldairarrow.Business.Base_Manage;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    [Route("/Base_Manage/[controller]/[action]")]
    public class Base_DispatchController : BaseApiController
    {
        #region DI

        public Base_DispatchController(IBase_DispatchBusiness Base_DispatchBus)
        {
            _Base_DispatchBus = Base_DispatchBus;
        }

        IBase_DispatchBusiness _Base_DispatchBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<Base_Dispatch>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _Base_DispatchBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<Base_Dispatch> GetTheData(IdInputDTO input)
        {
            return await _Base_DispatchBus.GetTheDataAsync(input.id);
        }
        
        [HttpPost]
        public async Task<Base_Dispatch> GetOneDataAsync(IdInputDTO input)
        {
            return await _Base_DispatchBus.GetOneDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(Base_Dispatch data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _Base_DispatchBus.AddDataAsync(data);
            }
            else
            {
                await _Base_DispatchBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _Base_DispatchBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}