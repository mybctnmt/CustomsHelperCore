using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecargopropBusiness
    {
        Task<PageResult<tbasecargoprop>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecargoprop> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecargoprop data);
        Task UpdateDataAsync(tbasecargoprop data);
        Task DeleteDataAsync(List<string> ids);
    }
}