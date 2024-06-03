using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecgoodslimitBusiness
    {
        Task<PageResult<tdecgoodslimit>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecgoodslimit> GetTheDataAsync(string id);
        Task AddDataAsync(tdecgoodslimit data);
        Task UpdateDataAsync(tdecgoodslimit data);
        Task DeleteDataAsync(List<string> ids);
    }
}