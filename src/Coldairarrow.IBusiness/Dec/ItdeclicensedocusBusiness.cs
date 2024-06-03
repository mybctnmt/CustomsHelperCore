using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdeclicensedocusBusiness
    {
        Task<PageResult<tdeclicensedocus>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdeclicensedocus> GetTheDataAsync(string id);
        Task AddDataAsync(tdeclicensedocus data);
        Task UpdateDataAsync(tdeclicensedocus data);
        Task DeleteDataAsync(List<string> ids);
        Task AddbusinessIdAsync(tdeclicensedocus data, string userid);
    }
}