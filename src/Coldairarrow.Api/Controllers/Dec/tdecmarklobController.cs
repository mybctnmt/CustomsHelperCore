using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecmarklobController : BaseApiController
    {
        #region DI

        public tdecmarklobController(ItdecmarklobBusiness tdecmarklobBus)
        {
            _tdecmarklobBus = tdecmarklobBus;
        }

        ItdecmarklobBusiness _tdecmarklobBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdecmarklob>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecmarklobBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdecmarklob> GetTheData(IdInputDTO input)
        {
            return await _tdecmarklobBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdecmarklob data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecmarklobBus.AddDataAsync(data);
            }
            else
            {
                await _tdecmarklobBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecmarklobBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}