using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasedespportBusiness
    {
        Task<PageResult<tbasedespport>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasedespport> GetTheDataAsync(string id);
        Task AddDataAsync(tbasedespport data);
        Task UpdateDataAsync(tbasedespport data);
        Task DeleteDataAsync(List<string> ids);
    }
}