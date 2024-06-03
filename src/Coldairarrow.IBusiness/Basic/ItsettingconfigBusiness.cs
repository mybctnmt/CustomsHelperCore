using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItsettingconfigBusiness
    {
        Task<PageResult<tsettingconfig>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tsettingconfig> GetTheDataAsync(string id);
        Task AddDataAsync(tsettingconfig data);
        Task UpdateDataAsync(tsettingconfig data);
        Task DeleteDataAsync(List<string> ids);
    }
}