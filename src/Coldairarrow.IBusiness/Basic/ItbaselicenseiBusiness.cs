using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaselicenseiBusiness
    {
        Task<PageResult<tbaselicensei>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaselicensei> GetTheDataAsync(string id);
        Task AddDataAsync(tbaselicensei data);
        Task UpdateDataAsync(tbaselicensei data);
        Task DeleteDataAsync(List<string> ids);
    }
}