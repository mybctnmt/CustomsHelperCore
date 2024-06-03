using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItexemptionldBusiness
    {
        Task<PageResult<texemptionld>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<texemptionld> GetTheDataAsync(string id);
        Task AddDataAsync(texemptionld data);
        Task UpdateDataAsync(texemptionld data);
        Task DeleteDataAsync(List<string> ids);
    }
}