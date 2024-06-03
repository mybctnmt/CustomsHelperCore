using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItalarmconditionBusiness
    {
        Task<PageResult<talarmcondition>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<talarmcondition> GetTheDataAsync(string id);
        Task AddDataAsync(talarmcondition data);
        Task UpdateDataAsync(talarmcondition data);
        Task DeleteDataAsync(List<string> ids);
    }
}