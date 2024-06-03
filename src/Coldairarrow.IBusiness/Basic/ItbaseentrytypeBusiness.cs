using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseentrytypeBusiness
    {
        Task<PageResult<tbaseentrytype>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseentrytype> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseentrytype data);
        Task UpdateDataAsync(tbaseentrytype data);
        Task DeleteDataAsync(List<string> ids);
    }
}