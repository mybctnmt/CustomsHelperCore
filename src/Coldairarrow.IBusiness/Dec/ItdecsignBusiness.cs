using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecsignBusiness
    {
        Task<PageResult<tdecsign>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecsign> GetTheDataAsync(string id);
        Task AddDataAsync(tdecsign data);
        Task UpdateDataAsync(tdecsign data);
        Task DeleteDataAsync(List<string> ids);
    }
}