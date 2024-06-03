using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseuseBusiness
    {
        Task<PageResult<tbaseuse>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseuse> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseuse data);
        Task UpdateDataAsync(tbaseuse data);
        Task DeleteDataAsync(List<string> ids);
    }
}