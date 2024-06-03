using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecutmodeBusiness
    {
        Task<PageResult<tbasecutmode>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecutmode> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecutmode data);
        Task UpdateDataAsync(tbasecutmode data);
        Task DeleteDataAsync(List<string> ids);
    }
}