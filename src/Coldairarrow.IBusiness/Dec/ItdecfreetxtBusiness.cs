using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecfreetxtBusiness
    {
        Task<PageResult<tdecfreetxt>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecfreetxt> GetTheDataAsync(string id);
        Task AddDataAsync(tdecfreetxt data);
        Task UpdateDataAsync(tdecfreetxt data);
        Task DeleteDataAsync(List<string> ids);
    }
}