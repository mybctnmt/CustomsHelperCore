using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasesetupBusiness
    {
        Task<PageResult<tbasesetup>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasesetup> GetTheDataAsync(string id);
        Task AddDataAsync(tbasesetup data);
        Task UpdateDataAsync(tbasesetup data);
        Task DeleteDataAsync(List<string> ids);
    }
}