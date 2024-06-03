using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasedocreqBusiness
    {
        Task<PageResult<tbasedocreq>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasedocreq> GetTheDataAsync(string id);
        Task AddDataAsync(tbasedocreq data);
        Task UpdateDataAsync(tbasedocreq data);
        Task DeleteDataAsync(List<string> ids);
    }
}