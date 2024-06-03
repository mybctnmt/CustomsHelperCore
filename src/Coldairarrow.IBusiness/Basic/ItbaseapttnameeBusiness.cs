using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseapttnameeBusiness
    {
        Task<PageResult<tbaseapttnamee>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseapttnamee> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseapttnamee data);
        Task UpdateDataAsync(tbaseapttnamee data);
        Task DeleteDataAsync(List<string> ids);
    }
}