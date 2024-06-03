using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdeccontainerBusiness
    {
        Task<PageResult<tdeccontainer>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdeccontainer> GetTheDataAsync(string id);
        Task AddDataAsync(tdeccontainer data);
        Task UpdateDataAsync(tdeccontainer data);
        Task DeleteDataAsync(List<string> ids);
    }
}