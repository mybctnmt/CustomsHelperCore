using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Nems
{
    public interface ItinvtlistBusiness
    {
        Task<PageResult<tinvtlist>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tinvtlist> GetTheDataAsync(string id);
        Task AddDataAsync(tinvtlist data);
        Task UpdateDataAsync(tinvtlist data);
        Task DeleteDataAsync(List<string> ids);
    }
}