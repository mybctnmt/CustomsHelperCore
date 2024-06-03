using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecuserBusiness
    {
        Task<PageResult<tdecuser>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecuser> GetTheDataAsync(string id);
        Task AddDataAsync(tdecuser data);
        Task UpdateDataAsync(tdecuser data);
        Task DeleteDataAsync(List<string> ids);
    }
}