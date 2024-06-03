using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecgoodslimitvinBusiness
    {
        Task<PageResult<tdecgoodslimitvin>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecgoodslimitvin> GetTheDataAsync(string id);
        Task AddDataAsync(tdecgoodslimitvin data);
        Task UpdateDataAsync(tdecgoodslimitvin data);
        Task DeleteDataAsync(List<string> ids);
    }
}