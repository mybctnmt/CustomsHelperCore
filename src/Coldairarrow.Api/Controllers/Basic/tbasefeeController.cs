using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasefeeController : BaseApiController
    {
        #region DI

        public tbasefeeController(ItbasefeeBusiness tbasefeeBus)
        {
            _tbasefeeBus = tbasefeeBus;
        }

        ItbasefeeBusiness _tbasefeeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasefee>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasefeeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasefee> GetTheData(IdInputDTO input)
        {
            return await _tbasefeeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task<List<tbasefee>> SaveDatas(List<tbasefee> datalist)
        {
            datalist.ForEach(x =>
            {
                if (x.Id.IsNullOrEmpty())
                {
                    InitEntity(x);
                }
            });
            return await _tbasefeeBus.SaveDatas(datalist);
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasefeeBus.DeleteDataAsync(ids);
        }


        #endregion
    }
}