using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustommasterBusiness
    {
        Task<PageResult<tbasecustommaster>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecustommaster> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecustommaster data);
        Task UpdateDataAsync(tbasecustommaster data);
        Task DeleteDataAsync(List<string> ids);
    }
}