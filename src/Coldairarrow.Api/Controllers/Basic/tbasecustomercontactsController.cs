using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasecustomercontactsController : BaseApiController
    {
        #region DI

        public tbasecustomercontactsController(ItbasecustomercontactsBusiness tbasecustomercontactsBus)
        {
            _tbasecustomercontactsBus = tbasecustomercontactsBus;
        }

        ItbasecustomercontactsBusiness _tbasecustomercontactsBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasecustomercontacts>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasecustomercontactsBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasecustomercontacts> GetTheData(IdInputDTO input)
        {
            return await _tbasecustomercontactsBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task<string> SaveData(tbasecustomercontacts data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

               return  await _tbasecustomercontactsBus.AddDataAsync(data);
            }
            else
            {
              return  await _tbasecustomercontactsBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasecustomercontactsBus.DeleteDataAsync(ids);
        }


        [HttpPost]
        public async Task SaveDatas([FromQuery] string cid, List<tbasecustomercontacts> datalist)
        {
            foreach (var item in datalist)
            {
                InitEntity(item);
            }
            await _tbasecustomercontactsBus.SaveDatas(cid, datalist);
        }
        #endregion
    }
}