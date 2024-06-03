using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasepackagekindBusiness
    {
        Task<PageResult<tbasepackagekind>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasepackagekind> GetTheDataAsync(string id);
        Task AddDataAsync(tbasepackagekind data);
        Task UpdateDataAsync(tbasepackagekind data);
        Task DeleteDataAsync(List<string> ids);
    }
}