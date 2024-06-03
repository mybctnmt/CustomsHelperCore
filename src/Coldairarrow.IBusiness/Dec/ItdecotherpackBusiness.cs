using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecotherpackBusiness
    {
        Task<PageResult<tdecotherpack>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecotherpack> GetTheDataAsync(string id);
        Task AddDataAsync(tdecotherpack data);
        Task UpdateDataAsync(tdecotherpack data);
        Task DeleteDataAsync(List<string> ids);
    }
}