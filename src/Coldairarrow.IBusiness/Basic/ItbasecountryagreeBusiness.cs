using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecountryagreeBusiness
    {
        Task<PageResult<tbasecountryagree>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecountryagree> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecountryagree data);
        Task UpdateDataAsync(tbasecountryagree data);
        Task DeleteDataAsync(List<string> ids);
    }
}