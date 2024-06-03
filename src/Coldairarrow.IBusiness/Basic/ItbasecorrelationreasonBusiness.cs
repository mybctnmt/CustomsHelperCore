using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecorrelationreasonBusiness
    {
        Task<PageResult<tbasecorrelationreason>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecorrelationreason> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecorrelationreason data);
        Task UpdateDataAsync(tbasecorrelationreason data);
        Task DeleteDataAsync(List<string> ids);
    }
}