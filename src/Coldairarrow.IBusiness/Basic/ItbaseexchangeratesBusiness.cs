using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseexchangeratesBusiness
    {
        Task<PageResult<tbaseexchangerates>> GetDataListAsync(PageInput<List<ConditionDTO>> input);
        Task<tbaseexchangerates> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseexchangerates data);
        Task UpdateDataAsync(tbaseexchangerates data);
        Task DeleteDataAsync(List<string> ids);
    }
}