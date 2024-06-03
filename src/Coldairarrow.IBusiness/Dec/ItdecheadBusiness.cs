using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecheadBusiness
    {
        Task<PageResult<tdechead>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<List<tdechead>> GetDataListOrderAsync(List<string> input);
        Task<tdechead> GetTheDataAsync(string id);
        Task AddDataAsync(tdechead data);
        Task UpdateDataAsync(tdechead data);
        Task DeleteDataAsync(List<string> ids);
        Task AddDecInfoAsync(tdecinfo tdecinfo, bool isExist);
        Task UpdateDecInfoAsync(tdecinfo tdecinfo, bool isExist);
        Task<string> SWBGDataSelect(List<tdechead> orderlist);
        Task<tdecinfo> GetDecInfo(string orderNo);
        Task<List<DeclarationListDto>> GetDataListWhereAsync(List<ConditionDTO> input);
        Task<string> LoadingDels(List<DecHeadVo> orderlist,string userid);
        Task<string> SaveRemark(List<ConditionDTO> orderlist);
        /// <summary>
        /// 快速录入
        /// </summary>
        /// <param name="searchs"></param>
        /// <returns></returns>
        Task<List<QuickEntryDto>> GetQuickEntryAsync(List<ConditionDTO> searchs);
        Task<tdechead> GetDecHead(string orderNo);
        Task<List<UnitDto>> GetUnit();
        Task SaveDecInfoAsync(tdecinfo tdecinfo);
        Task<string> GetIEFlag(string orderNo);
    }
}