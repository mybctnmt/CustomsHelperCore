using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Nems
{
    public interface ItinvtsignBusiness
    {
        Task<PageResult<tinvtsign>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tinvtsign> GetTheDataAsync(string id);
        Task AddDataAsync(tinvtsign data);
        Task UpdateDataAsync(tinvtsign data);
        Task DeleteDataAsync(List<string> ids);
    }
}