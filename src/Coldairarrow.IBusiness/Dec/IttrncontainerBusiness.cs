using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface IttrncontainerBusiness
    {
        Task<PageResult<ttrncontainer>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttrncontainer> GetTheDataAsync(string id);
        Task AddDataAsync(ttrncontainer data);
        Task UpdateDataAsync(ttrncontainer data);
        Task DeleteDataAsync(List<string> ids);
    }
}