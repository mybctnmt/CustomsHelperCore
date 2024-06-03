using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Inbox
{
    [Route("/Inbox/[controller]/[action]")]
    public class temailcontentController : BaseApiController
    {
        #region DI

        public temailcontentController(ItemailcontentBusiness temailcontentBus)
        {
            _temailcontentBus = temailcontentBus;
        }

        ItemailcontentBusiness _temailcontentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<temailcontent>> GetDataList(PageInput<List<ConditionDTO>> input)
        {
            return await _temailcontentBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<temailcontent> GetTheData(IdInputDTO input)
        {
            return await _temailcontentBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(temailcontent data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _temailcontentBus.AddDataAsync(data);
            }
            else
            {
                await _temailcontentBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _temailcontentBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}