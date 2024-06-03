using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tdeclarationdefaultController : BaseApiController
    {
        #region DI

        public tdeclarationdefaultController(ItdeclarationdefaultBusiness tdeclarationdefaultBus)
        {
            _tdeclarationdefaultBus = tdeclarationdefaultBus;
        }

        ItdeclarationdefaultBusiness _tdeclarationdefaultBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdeclarationdefault>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdeclarationdefaultBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdeclarationdefault> GetTheData(IdInputDTO input)
        {
            return await _tdeclarationdefaultBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdeclarationdefault data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdeclarationdefaultBus.AddDataAsync(data);
            }
            else
            {
                await _tdeclarationdefaultBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdeclarationdefaultBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}