using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecriskBusiness
    {
        Task<PageResult<tdecrisk>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecrisk> GetTheDataAsync(string id);
        Task AddDataAsync(tdecrisk data);
        Task UpdateDataAsync(tdecrisk data);
        Task DeleteDataAsync(List<string> ids);
    }
}