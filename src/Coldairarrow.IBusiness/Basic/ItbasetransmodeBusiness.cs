using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasetransmodeBusiness
    {
        Task<PageResult<tbasetransmode>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasetransmode> GetTheDataAsync(string id);
        Task AddDataAsync(tbasetransmode data);
        Task UpdateDataAsync(tbasetransmode data);
        Task DeleteDataAsync(List<string> ids);
    }
}