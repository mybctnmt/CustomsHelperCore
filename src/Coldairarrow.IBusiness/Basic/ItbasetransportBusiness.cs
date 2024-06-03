using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasetransportBusiness
    {
        Task<PageResult<tbasetransport>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasetransport> GetTheDataAsync(string id);
        Task AddDataAsync(tbasetransport data);
        Task UpdateDataAsync(tbasetransport data);
        Task DeleteDataAsync(List<string> ids);
    }
}