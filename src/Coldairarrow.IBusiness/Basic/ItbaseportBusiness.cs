using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseportBusiness
    {
        Task<PageResult<tbaseport>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseport> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseport data);
        Task UpdateDataAsync(tbaseport data);
        Task DeleteDataAsync(List<string> ids);
    }
}