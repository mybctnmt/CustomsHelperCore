using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasehscodedecBusiness
    {
        Task<PageResult<tbasehscodedec>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasehscodedec> GetTheDataAsync(string id);
        Task AddDataAsync(tbasehscodedec data);
        Task UpdateDataAsync(tbasehscodedec data);
        Task DeleteDataAsync(List<string> ids);
    }
}