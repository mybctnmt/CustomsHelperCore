using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecreviewBusiness
    {
        Task<PageResult<tdecreview>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecreview> GetTheDataAsync(string id);
        Task AddDataAsync(tdecreview data);
        Task UpdateDataAsync(tdecreview data);
        Task DeleteDataAsync(List<string> ids);
    }
}