using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface IttrnheadBusiness
    {
        Task<PageResult<ttrnhead>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttrnhead> GetTheDataAsync(string id);
        Task AddDataAsync(ttrnhead data);
        Task UpdateDataAsync(ttrnhead data);
        Task DeleteDataAsync(List<string> ids);
    }
}