using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecountryBusiness
    {
        Task<PageResult<tbasecountry>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecountry> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecountry data);
        Task UpdateDataAsync(tbasecountry data);
        Task DeleteDataAsync(List<string> ids);
    }
}