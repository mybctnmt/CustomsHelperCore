using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public interface ItinboxconfigBusiness
    {
        Task<PageResult<tinboxconfig>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tinboxconfig> GetTheDataAsync(string id);
        Task AddDataAsync(tinboxconfig data);
        Task UpdateDataAsync(tinboxconfig data);
        Task DeleteDataAsync(List<string> ids);
    }
}