using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseplaceBusiness
    {
        Task<PageResult<tbaseplace>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseplace> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseplace data);
        Task UpdateDataAsync(tbaseplace data);
        Task DeleteDataAsync(List<string> ids);
    }
}