using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class thscodedescController : BaseApiController
    {
        #region DI

        public thscodedescController(IthscodedescBusiness thscodedescBus)
        {
            _thscodedescBus = thscodedescBus;
        }

        IthscodedescBusiness _thscodedescBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<thscodedesc>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _thscodedescBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<thscodedesc> GetTheData(IdInputDTO input)
        {
            return await _thscodedescBus.GetTheDataAsync(input.id);
        }

        [HttpPost]
        public async Task<List<thscodedesc>> GetHscodeList(List<string> hscodes)
        {
            return await _thscodedescBus.GetHscodeListAsync(hscodes);
        }
        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(thscodedesc data)
        {
            if (data.id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _thscodedescBus.AddDataAsync(data);
            }
            else
            {
                await _thscodedescBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _thscodedescBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}