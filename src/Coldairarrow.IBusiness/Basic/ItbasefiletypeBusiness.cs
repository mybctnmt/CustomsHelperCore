using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasefiletypeBusiness
    {
        Task<PageResult<tbasefiletype>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasefiletype> GetTheDataAsync(string id);
        Task AddDataAsync(tbasefiletype data);
        Task UpdateDataAsync(tbasefiletype data);
        Task DeleteDataAsync(List<string> ids);
    }
}