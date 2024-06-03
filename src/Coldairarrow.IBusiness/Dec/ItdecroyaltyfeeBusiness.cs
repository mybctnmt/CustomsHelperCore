using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecroyaltyfeeBusiness
    {
        Task<PageResult<tdecroyaltyfee>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecroyaltyfee> GetTheDataAsync(string id);
        Task AddDataAsync(tdecroyaltyfee data);
        Task UpdateDataAsync(tdecroyaltyfee data);
        Task DeleteDataAsync(List<string> ids);
    }
}