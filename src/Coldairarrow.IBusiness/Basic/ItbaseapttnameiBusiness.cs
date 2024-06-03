using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseapttnameiBusiness
    {
        Task<PageResult<tbaseapttnamei>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseapttnamei> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseapttnamei data);
        Task UpdateDataAsync(tbaseapttnamei data);
        Task DeleteDataAsync(List<string> ids);
    }
}