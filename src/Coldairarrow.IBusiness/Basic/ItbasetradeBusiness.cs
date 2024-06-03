using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasetradeBusiness
    {
        Task<PageResult<tbasetrade>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasetrade> GetTheDataAsync(string id);
        Task AddDataAsync(tbasetrade data);
        Task UpdateDataAsync(tbasetrade data);
        Task DeleteDataAsync(List<string> ids);
    }
}