using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasedestBusiness
    {
        Task<PageResult<tbasedest>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasedest> GetTheDataAsync(string id);
        Task AddDataAsync(tbasedest data);
        Task UpdateDataAsync(tbasedest data);
        Task DeleteDataAsync(List<string> ids);
    }
}