using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasenormsBusiness
    {
        Task<PageResult<tbasenorms>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasenorms> GetTheDataAsync(string id);
        Task AddDataAsync(tbasenorms data);
        Task UpdateDataAsync(tbasenorms data);
        Task DeleteDataAsync(List<string> ids);
    }
}