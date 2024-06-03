using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iusf102Business
    {
        Task<PageResult<usf102>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<usf102> GetTheDataAsync(string id);
        Task AddDataAsync(usf102 data);
        Task UpdateDataAsync(usf102 data);
        Task DeleteDataAsync(List<string> ids);
    }
}