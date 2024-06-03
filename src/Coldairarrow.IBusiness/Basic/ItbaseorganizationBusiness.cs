using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseorganizationBusiness
    {
        Task<PageResult<tbaseorganization>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseorganization> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseorganization data);
        Task UpdateDataAsync(tbaseorganization data);
        Task DeleteDataAsync(List<string> ids);
    }
}