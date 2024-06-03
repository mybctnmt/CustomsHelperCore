using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecurrencyBusiness
    {
        Task<PageResult<tbasecurrency>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecurrency> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecurrency data);
        Task UpdateDataAsync(tbasecurrency data);
        Task DeleteDataAsync(List<string> ids);
    }
}