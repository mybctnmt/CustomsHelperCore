using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdeclicensedocusController : BaseApiController
    {
        #region DI
        IOperator _operator { get; }
        public tdeclicensedocusController(ItdeclicensedocusBusiness tdeclicensedocusBus, IOperator @operator)
        {
            _tdeclicensedocusBus = tdeclicensedocusBus;
            _operator = @operator;
        }

        ItdeclicensedocusBusiness _tdeclicensedocusBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdeclicensedocus>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdeclicensedocusBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<tdeclicensedocus> GetTheData(IdInputDTO input)
        {
            return await _tdeclicensedocusBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdeclicensedocus data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdeclicensedocusBus.AddDataAsync(data);
            }
            else
            {
                await _tdeclicensedocusBus.UpdateDataAsync(data);
            }
        }
        [HttpPost]
        public async Task<bool> AddbusinessId(tdeclicensedocus data)
        {
            string userid = _operator?.UserId;
            await _tdeclicensedocusBus.AddbusinessIdAsync(data, userid);
            return true;
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdeclicensedocusBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}