using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasetradecountriesBusiness
    {
        Task<PageResult<tbasetradecountries>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasetradecountries> GetTheDataAsync(string id);
        Task AddDataAsync(tbasetradecountries data);
        Task UpdateDataAsync(tbasetradecountries data);
        Task DeleteDataAsync(List<string> ids);
    }
}