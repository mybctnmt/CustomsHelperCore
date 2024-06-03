using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasefeemarkBusiness
    {
        Task<PageResult<tbasefeemark>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasefeemark> GetTheDataAsync(string id);
        Task AddDataAsync(tbasefeemark data);
        Task UpdateDataAsync(tbasefeemark data);
        Task DeleteDataAsync(List<string> ids);
    }
}