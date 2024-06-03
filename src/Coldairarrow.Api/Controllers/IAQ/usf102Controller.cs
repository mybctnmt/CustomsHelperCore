using Coldairarrow.Business.IAQ;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IAQ
{
    [Route("/IAQ/[controller]/[action]")]
    public class usf102Controller : BaseApiController
    {
        #region DI

        public usf102Controller(Iusf102Business usf102Bus)
        {
            _usf102Bus = usf102Bus;
        }

        Iusf102Business _usf102Bus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<usf102>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _usf102Bus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<usf102> GetTheData(IdInputDTO input)
        {
            return await _usf102Bus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(usf102 data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _usf102Bus.AddDataAsync(data);
            }
            else
            {
                await _usf102Bus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _usf102Bus.DeleteDataAsync(ids);
        }

        #endregion
    }
}