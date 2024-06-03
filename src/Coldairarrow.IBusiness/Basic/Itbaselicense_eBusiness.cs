using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface Itbaselicense_eBusiness
    {
        Task<PageResult<tbaselicense_e>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaselicense_e> GetTheDataAsync(string id);
        Task AddDataAsync(tbaselicense_e data);
        Task UpdateDataAsync(tbaselicense_e data);
        Task DeleteDataAsync(List<string> ids);
    }
}