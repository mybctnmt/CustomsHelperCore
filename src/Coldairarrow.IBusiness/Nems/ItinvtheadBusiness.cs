using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Nems
{
    public interface ItinvtheadBusiness
    {
        Task<PageResult<tinvthead>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tinvthead> GetTheDataAsync(string id);
        Task AddDataAsync(tinvthead data);
        Task UpdateDataAsync(tinvthead data);
        Task DeleteDataAsync(List<string> ids);
        Task<tinvtinfo> GetDecInfo(string orderNo);
    }
}