using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbasehscodeinfoController : BaseApiController
    {
        #region DI

        public tbasehscodeinfoController(ItbasehscodeinfoBusiness tbasehscodeinfoBus)
        {
            _tbasehscodeinfoBus = tbasehscodeinfoBus;
        }

        ItbasehscodeinfoBusiness _tbasehscodeinfoBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbasehscodeinfo>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbasehscodeinfoBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbasehscodeinfo> GetTheData(IdInputDTO input)
        {
            return await _tbasehscodeinfoBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbasehscodeinfo data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);
                await _tbasehscodeinfoBus.AddDataAsync(data);
            }
            else
            {
                await _tbasehscodeinfoBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbasehscodeinfoBus.DeleteDataAsync(ids);
        }

        [HttpPost]
        public async Task HscodeSync(thscodeinfo thscodeinfo)
        {
            InitEntity(thscodeinfo.tbasehscodeinfo);

            foreach (var item in thscodeinfo.tbasehscodedecEs)
            {
                InitEntity(item);
            }

            foreach (var item in thscodeinfo.tbasehscodedecIs)
            {
                InitEntity(item);
            }

            await _tbasehscodeinfoBus.HscodeSync(thscodeinfo);
        }

        #endregion
    }
}