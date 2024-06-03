using Coldairarrow.Business.Remind;
using Coldairarrow.Entity.Remind;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Remind
{
    [Route("/Remind/[controller]/[action]")]
    public class treminderuserlogController : BaseApiController
    {
        #region DI

        public treminderuserlogController(ItreminderuserlogBusiness treminderuserlogBus)
        {
            _treminderuserlogBus = treminderuserlogBus;
        }

        ItreminderuserlogBusiness _treminderuserlogBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<treminderuserlog>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _treminderuserlogBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<treminderuserlog> GetTheData(IdInputDTO input)
        {
            return await _treminderuserlogBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(treminderuserlog data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _treminderuserlogBus.AddDataAsync(data);
            }
            else
            {
                await _treminderuserlogBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _treminderuserlogBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}