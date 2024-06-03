using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iciq_retBusiness
    {
        Task<PageResult<ciq_ret>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ciq_ret> GetTheDataAsync(string id);
        Task AddDataAsync(ciq_ret data);
        Task UpdateDataAsync(ciq_ret data);
        Task DeleteDataAsync(List<string> ids);
    }
}