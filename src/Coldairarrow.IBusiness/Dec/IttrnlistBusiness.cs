using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface IttrnlistBusiness
    {
        Task<PageResult<ttrnlist>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttrnlist> GetTheDataAsync(string id);
        Task AddDataAsync(ttrnlist data);
        Task UpdateDataAsync(ttrnlist data);
        Task DeleteDataAsync(List<string> ids);
    }
}