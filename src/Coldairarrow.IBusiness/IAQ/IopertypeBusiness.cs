using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface IopertypeBusiness
    {
        Task<PageResult<opertype>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<opertype> GetTheDataAsync(string id);
        Task AddDataAsync(opertype data);
        Task UpdateDataAsync(opertype data);
        Task DeleteDataAsync(List<string> ids);
    }
}