using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdeccoplimitBusiness
    {
        Task<PageResult<tdeccoplimit>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdeccoplimit> GetTheDataAsync(string id);
        Task AddDataAsync(tdeccoplimit data);
        Task UpdateDataAsync(tdeccoplimit data);
        Task DeleteDataAsync(List<string> ids);
    }
}