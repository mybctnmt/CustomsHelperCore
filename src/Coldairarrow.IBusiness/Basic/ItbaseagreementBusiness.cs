using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseagreementBusiness
    {
        Task<PageResult<tbaseagreement>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseagreement> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseagreement data);
        Task UpdateDataAsync(tbaseagreement data);
        Task DeleteDataAsync(List<string> ids);
    }
}