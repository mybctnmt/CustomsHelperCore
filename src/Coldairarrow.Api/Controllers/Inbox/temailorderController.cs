using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Inbox
{
    [Route("/Inbox/[controller]/[action]")]
    public class temailorderController : BaseApiController
    {
        #region DI

        public temailorderController(ItemailorderBusiness temailorderBus)
        {
            _temailorderBus = temailorderBus;
        }

        ItemailorderBusiness _temailorderBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResultOrder<EmailOrderDto>> GetDataList(PageInput<List<ConditionDTO>> input)
        {
            return await _temailorderBus.GetDataListAsync(input);
        }

        [HttpGet]
        public async Task<temailinfo> GetDataListJoinAttachment(string id)
        {
            return await _temailorderBus.GetDataListJoinAttachment(id);
        }

        [HttpPost]
        public async Task<PageResult<temailorderjonhead>> GetDataListjoinHead(PageInput<ConditionDTO> input)
        {
            return await _temailorderBus.GetDataListjoinHeadAsync(input);
        }

        [HttpPost]
        public async Task<PageResult<temailorder>> GetDataListWhere(PageInput<List<ConditionDTO>> input)
        {
            return await _temailorderBus.GetDataListAsyncWhere(input);
        }

        [HttpPost]
        public async Task<PageResult<temailorderjonhead>> GetDataListjoinHeadWhere(PageInput<List<ConditionDTO>> input)
        {
            return await _temailorderBus.GetDataListjoinHeadAsyncWhere(input);
        }

        [HttpPost]
        public async Task<temailorder> GetTheData(IdInputDTO input)
        {
            return await _temailorderBus.GetTheDataAsync(input.id);
        }
        [HttpGet]
        public async Task<temailorder> GetTheDataByOrderNo(string orderNo)
        {
            return await _temailorderBus.GetTheDataByOrderNoAsync(orderNo);
        }

        [HttpGet]
        public async Task<List<tbasecustomerbgremark>> GetRemark(string orderNo)
        {
            return await _temailorderBus.GetRemark(orderNo);
        }

        [HttpPost]
        public async Task<List<SingleStatisticsOutput>> GetSingleStatistics(SingleStatisticsInput singleStatisticsInput)
        {
            return await _temailorderBus.GetSingleStatistics(singleStatisticsInput);
        }

        [HttpPost]
        public async Task<List<SingleSummaryOutput>> GetSingleSummary(SingleSummaryInput singleSummaryInput)
        {
            return await _temailorderBus.GetSingleSummary(singleSummaryInput);
        }

        [HttpGet]
        public async Task<SendInfoOutput> GetSendInfo(string seqNo)
        {
            return await _temailorderBus.GetSendInfo(seqNo);
        }

        [HttpGet]
        public async Task UpdateInputId(string orderNo, bool open)
        {
            await _temailorderBus.UpdateInputId(orderNo, open);
        }


        [HttpGet]
        public async Task<temailallGroup> GetAllGroup()
        {
            return await _temailorderBus.GetAllGroup();
        }
        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveDataJoinAttachment(temailinfo temailinfo)
        {
            foreach (var tinboxattachment in temailinfo.tinboxattachments)
            {
                InitEntity(tinboxattachment);
            }

            await _temailorderBus.SaveDataJoinAttachment(temailinfo);
        }

        [HttpPost]
        public async Task UpdateCustomer(temailorder data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                throw new BusException("当前禁止操作！");
            }
            await _temailorderBus.UpdateCustomerAsync(data);
        }
        [HttpPost]
        public async Task SaveData(temailorder data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _temailorderBus.AddDataAsync(data);
            }
            else
            {
                await _temailorderBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _temailorderBus.DeleteDataAsync(ids);
        }

        //审核完成
        [HttpPost]
        public async Task AuditCompleted(List<string> ids)
        {
            await _temailorderBus.AuditCompletedAsync(ids);
        }
        //制单完成
        [HttpPost]
        public async Task EntryClerk(List<string> orderNos)
        {
            await _temailorderBus.EntryClerkAsync(orderNos);
        }
        //加急完成
        [HttpPost]
        public async Task Urgent(List<string> orderNos, string userId)
        {
            await _temailorderBus.UrgentAsync(orderNos, userId);
        }
        //确认订单
        [HttpPost]
        public async Task ConfirmOrder(List<string> orderNos, string userId)
        {
            await _temailorderBus.ConfirmOrderAsync(orderNos, userId);
        }
        //确认订单
        [HttpPost]
        public async Task<List<string>> IsExistBillNo(List<string> orderNos)
        {
            return await _temailorderBus.IsExistBillNoAsync(orderNos);
        }
        [HttpPost]
        public async Task RevokeOrder(RejectDTO rejectDTO)
        {
            await _temailorderBus.RevokeOrderAsync(rejectDTO);
        }
        //审核完成
        [HttpPost]
        public async Task UpdateShipData(temailorder temailorder)
        {
            await _temailorderBus.UpdateShipDataAsync(temailorder);
        } 
        [HttpPost]
        public async Task UpdateFeeMark(string id, string type, string feename, string feecode)
        {
            await _temailorderBus.UpdateFeeMarkAsync(id, type, feename, feecode);
        }
        //更新商检信息
        [HttpPost]
        public async Task UpdateInspectionData(temailorder temailorder)
        {
            await _temailorderBus.UpdateInspectionDataAsync(temailorder);
        }
        //更新舱单运抵信息
        [HttpPost]
        public async Task UpdateManifestArrival(temailorder temailorder)
        {
            await _temailorderBus.UpdateManifestArrivalAsync(temailorder);
        }
        //合并
        [HttpPost]
        public async Task<string> Merge(List<temailorderjonhead> ids)
        {
            return await _temailorderBus.Merge(ids);
        }
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        [HttpPost]
        public async Task<int> EmailUpdateStatus(EmailUpdateStatus updateStatus)
        {
            try
            {
                await _semaphore.WaitAsync(); // 等待直到可以进入
                return await _temailorderBus.EmailUpdateStatus(updateStatus);
            }
            finally
            {
                _semaphore.Release(); // 确保释放信号量
            }
        }
        [HttpGet]
        public async Task<string> GetOrderNo()
        {
            return await _temailorderBus.GetOrderNo();
        }
        [HttpPost]
        public async Task SplitBill(SplitBillInfo info)
        {
            await _temailorderBus.SplitBillAsync(info);
        }
        [HttpPost]
        public async Task<bool> UpdateBGStates(string orderNo, List<BGBillState> bGBillStates)
        {
            return await _temailorderBus.UpdateBGStates(orderNo, bGBillStates);
        }
        [HttpPost]
        public async Task<bool> IsPending(string orderNo)
        {
            return await _temailorderBus.IsPending(orderNo);
        }

        [HttpPost]
        public async Task<bool> UpdatePrintState(string orderNo)
        {
            return await _temailorderBus.UpdatePrintState(orderNo);
        }
        [HttpPost]
        public async Task<bool> UpdateOnlineState(string DispatchId, int Online)
        {
            return await _temailorderBus.UpdateOnlineState(DispatchId, Online);
        }
        [HttpPost]
        public async Task TransferOrder(List<string> orderNos, string userId, string username)
        {
            await _temailorderBus.TransferOrder(orderNos, userId, username);
        }

        [HttpPost]
        public async Task DeleteDoc(List<string> orderNos, string type)
        {
            if (orderNos.Count > 450)
            {
                throw new BusException("当前可能是误操作！");
            }
            await _temailorderBus.DeleteDocAsync(orderNos, type);
        }
        [HttpPost]
        public async Task UpdateDepotData(temailorder temailorder)
        {
            await _temailorderBus.UpdateDepotDataAsync(temailorder);
        }
        [HttpPost]
        public async Task<List<ExportOrderDto>> ExportOrderData(SingleStatisticsInput singleStatisticsInput)
        {
            return await _temailorderBus.ExportOrderDataAsync(singleStatisticsInput);
        }
        #endregion
    }
}