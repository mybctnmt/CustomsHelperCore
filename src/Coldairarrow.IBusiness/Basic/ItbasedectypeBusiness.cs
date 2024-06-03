using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasedectypeBusiness
    {
        Task<PageResult<tbasedectype>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasedectype> GetTheDataAsync(string id);
        Task AddDataAsync(tbasedectype data);
        Task UpdateDataAsync(tbasedectype data);
        Task DeleteDataAsync(List<string> ids);
    }
}