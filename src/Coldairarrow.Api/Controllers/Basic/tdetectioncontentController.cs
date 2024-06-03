using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tdetectioncontentController : BaseApiController
    {
        #region DI

        public tdetectioncontentController(ItdetectioncontentBusiness tdetectioncontentBus)
        {
            _tdetectioncontentBus = tdetectioncontentBus;
        }

        ItdetectioncontentBusiness _tdetectioncontentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdetectioncontent>> GetDataList(PageInput<List<ConditionDTO>> input)
        {
            return await _tdetectioncontentBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdetectioncontent> GetTheData(IdInputDTO input)
        {
            return await _tdetectioncontentBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdetectioncontent data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdetectioncontentBus.AddDataAsync(data);
            }
            else
            {
                await _tdetectioncontentBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdetectioncontentBus.DeleteDataAsync(ids);
        }

        #endregion

        [HttpPost]
        public async Task SaveList(List<tdetectioncontent> tdetectioncontents)
        {
            foreach (var item in tdetectioncontents)
            {
                InitEntity(item);
            }
            await _tdetectioncontentBus.SaveListAsync(tdetectioncontents);
        }
    }
}