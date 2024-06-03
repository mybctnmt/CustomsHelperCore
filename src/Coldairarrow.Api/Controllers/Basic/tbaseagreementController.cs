using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class tbaseagreementController : BaseApiController
    {
        #region DI

        public tbaseagreementController(ItbaseagreementBusiness tbaseagreementBus)
        {
            _tbaseagreementBus = tbaseagreementBus;
        }

        ItbaseagreementBusiness _tbaseagreementBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tbaseagreement>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tbaseagreementBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tbaseagreement> GetTheData(IdInputDTO input)
        {
            return await _tbaseagreementBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tbaseagreement data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tbaseagreementBus.AddDataAsync(data);
            }
            else
            {
                await _tbaseagreementBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tbaseagreementBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}