using Coldairarrow.Business.Nems;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Nems
{
    [Route("/Nems/[controller]/[action]")]
    public class timportinfoController : BaseApiController
    {
        #region DI

        public timportinfoController(ItimportinfoBusiness timportinfoBus)
        {
            _timportinfoBus = timportinfoBus;
        }

        ItimportinfoBusiness _timportinfoBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<timportinfo>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _timportinfoBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<timportinfo> GetTheData(IdInputDTO input)
        {
            return await _timportinfoBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(timportinfo data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _timportinfoBus.AddDataAsync(data);
            }
            else
            {
                await _timportinfoBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _timportinfoBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}