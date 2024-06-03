using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasedistrictBusiness
    {
        Task<PageResult<tbasedistrict>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasedistrict> GetTheDataAsync(string id);
        Task AddDataAsync(tbasedistrict data);
        Task UpdateDataAsync(tbasedistrict data);
        Task DeleteDataAsync(List<string> ids);
    }
}