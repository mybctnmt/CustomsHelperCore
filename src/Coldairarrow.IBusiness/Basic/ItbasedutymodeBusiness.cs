using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasedutymodeBusiness
    {
        Task<PageResult<tbasedutymode>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasedutymode> GetTheDataAsync(string id);
        Task AddDataAsync(tbasedutymode data);
        Task UpdateDataAsync(tbasedutymode data);
        Task DeleteDataAsync(List<string> ids);
    }
}