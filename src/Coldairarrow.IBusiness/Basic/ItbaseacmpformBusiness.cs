using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseacmpformBusiness
    {
        Task<PageResult<tbaseacmpform>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseacmpform> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseacmpform data);
        Task UpdateDataAsync(tbaseacmpform data);
        Task DeleteDataAsync(List<string> ids);
    }
}