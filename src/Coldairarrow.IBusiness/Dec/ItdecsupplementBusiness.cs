using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecsupplementBusiness
    {
        Task<PageResult<tdecsupplement>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecsupplement> GetTheDataAsync(string id);
        Task AddDataAsync(tdecsupplement data);
        Task UpdateDataAsync(tdecsupplement data);
        Task DeleteDataAsync(List<string> ids);
    }
}