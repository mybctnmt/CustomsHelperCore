using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdeccoppromiseBusiness
    {
        Task<PageResult<tdeccoppromise>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdeccoppromise> GetTheDataAsync(string id);
        Task AddDataAsync(tdeccoppromise data);
        Task UpdateDataAsync(tdeccoppromise data);
        Task DeleteDataAsync(List<string> ids);
    }
}