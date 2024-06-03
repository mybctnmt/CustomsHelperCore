using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tdecheadController : BaseApiController
    {
        #region DI

        public tdecheadController(ItdecheadBusiness tdecheadBus,IOperator operator1)
        {
            _tdecheadBus = tdecheadBus;
            _operator = operator1;
        }

        ItdecheadBusiness _tdecheadBus { get; }
        IOperator _operator { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tdechead>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tdecheadBus.GetDataListAsync(input);
        }
        [HttpPost]
        public async Task<List<tdechead>> GetDataOrderList(List<string> order)
        {
            return await _tdecheadBus.GetDataListOrderAsync(order);
        }
        [HttpPost]
        public async Task<List<QuickEntryDto>> GetQuickEntry(List<ConditionDTO> input)
        {
            return await _tdecheadBus.GetQuickEntryAsync(input);
        }

        [HttpPost]
        public async Task<tdechead> GetTheData(IdInputDTO input)
        {
            return await _tdecheadBus.GetTheDataAsync(input.id);
        }

        [HttpGet]
        public async Task<tdecinfo> GetDecInfo(string orderNo)
        {
            return await _tdecheadBus.GetDecInfo(orderNo);
        }

        [HttpGet]
        public async Task<tdechead> GetDecHead(string orderNo)
        {
            return await _tdecheadBus.GetDecHead(orderNo);
        }
        
        [HttpGet]
        public async Task<string> GetIEFlag(string orderNo)
        {
            return await _tdecheadBus.GetIEFlag(orderNo);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(tdechead data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tdecheadBus.AddDataAsync(data);
            }
            else
            {
                await _tdecheadBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tdecheadBus.DeleteDataAsync(ids);
        }

        [HttpPost]
        public async Task SaveDecInfo(tdecinfo tdecinfo)
        {
            if (tdecinfo.temailorder.OrderNo.IsNullOrEmpty())
            {
                throw new BusException("订单号不允许为空！");
            }
            if (tdecinfo.tdechead.OrderNo.IsNullOrEmpty())
            {
                throw new BusException("订单号不允许为空！");
            }
            await _tdecheadBus.SaveDecInfoAsync(tdecinfo);
        }
        [HttpPost]
        public async Task<string> SWBGDataSelect(List<tdechead> orderlist)
        {
            orderlist.ForEach(x =>
            {
                InitEntity(x);
            });
            return await _tdecheadBus.SWBGDataSelect(orderlist);
        }

        [HttpPost]
        public async Task<List<DeclarationListDto>> GetDataListWhere(List<ConditionDTO> input)
        {
            return await _tdecheadBus.GetDataListWhereAsync(input);
        }

        [HttpPost]
        public async Task<string> LoadingDels(List<DecHeadVo> orderlist)
        {
            string userid = _operator?.UserId;
            return await _tdecheadBus.LoadingDels(orderlist, userid);
        }

        [HttpPost]
        public async Task<string> SaveRemark(List<ConditionDTO> orderlist)
        {
            return await _tdecheadBus.SaveRemark(orderlist);
        }
        [HttpGet]
        public async Task<List<UnitDto>> GetUnit()
        {
            return await _tdecheadBus.GetUnit();
        }
        #endregion
    }
}