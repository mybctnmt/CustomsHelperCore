using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseunitBusiness
    {
        Task<PageResult<tbaseunit>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseunit> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseunit data);
        Task UpdateDataAsync(tbaseunit data);
        Task DeleteDataAsync(List<string> ids);
    }
}