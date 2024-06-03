using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdectpaccessBusiness
    {
        Task<PageResult<tdectpaccess>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdectpaccess> GetTheDataAsync(string id);
        Task AddDataAsync(tdectpaccess data);
        Task UpdateDataAsync(tdectpaccess data);
        Task DeleteDataAsync(List<string> ids);
    }
}