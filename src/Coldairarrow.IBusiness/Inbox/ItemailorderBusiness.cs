using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public interface ItemailorderBusiness
    {
        Task<PageResultOrder<EmailOrderDto>> GetDataListAsync(PageInput<List<ConditionDTO>> input);
        Task<PageResult<temailorderjonhead>> GetDataListjoinHeadAsync(PageInput<ConditionDTO> input);
        Task<PageResult<temailorder>> GetDataListAsyncWhere(PageInput<List<ConditionDTO>> input);
        Task<PageResult<temailorderjonhead>> GetDataListjoinHeadAsyncWhere(PageInput<List<ConditionDTO>> input);
        Task<temailorder> GetTheDataAsync(string id);
        Task AddDataAsync(temailorder data);
        Task UpdateDataAsync(temailorder data);
        Task<temailallGroup> GetAllGroup();
        Task DeleteDataAsync(List<string> ids);
        Task AuditCompletedAsync(List<string> ids);

        Task EntryClerkAsync(List<string> orderNos);
        Task<string> Merge(List<temailorderjonhead> ids);
        Task<temailinfo> GetDataListJoinAttachment(string id);
        Task<string> GetOrderNo();

        Task<int> EmailUpdateStatus(EmailUpdateStatus updateStatus);
        Task<List<tbasecustomerbgremark>> GetRemark(string orderNo);
        Task UpdateShipDataAsync(temailorder temailorder);
        Task UpdateFeeMarkAsync(string id, string type, string feename, string feecode);
        Task UpdateInspectionDataAsync(temailorder temailorder);
        Task UpdateManifestArrivalAsync(temailorder temailorder);
        Task ConfirmOrderAsync(List<string> orderNos, string userId);

         Task<List<string>> IsExistBillNoAsync(List<string> orderNos);
        Task SaveDataJoinAttachment(temailinfo temailinfo);
        Task<temailorder> GetTheDataByOrderNoAsync(string orderNo);
        Task UrgentAsync(List<string> orderNos, string userId);
        Task RevokeOrderAsync(RejectDTO rejectDTO);
        Task SplitBillAsync(SplitBillInfo info);
        Task<bool> UpdateBGStates(string orderNo, List<BGBillState> bGBillStates);
        Task<bool> UpdatePrintState(string orderNo);
        Task<bool> IsPending(string orderNo);
        Task<bool> UpdateOnlineState(string DispatchId, int Online);
        Task TransferOrder(List<string> orderNos, string userId, string username);
        Task<List<SingleStatisticsOutput>> GetSingleStatistics(SingleStatisticsInput singleStatisticsInput);
        Task DeleteDocAsync(List<string> orderNos, string type);
        Task<List<SingleSummaryOutput>> GetSingleSummary(SingleSummaryInput singleSummaryInput);
        Task UpdateDepotDataAsync(temailorder temailorder);
        Task<List<ExportOrderDto>> ExportOrderDataAsync(SingleStatisticsInput singleStatisticsInput);
        Task UpdateCustomerAsync(temailorder data);
        Task<SendInfoOutput> GetSendInfo(string seqNo);
        Task UpdateInputId(string orderNo, bool open);
        Task UpdateActiveClients(List<string> activeClients);
        Task AutoDispatchOrder();
    }
}