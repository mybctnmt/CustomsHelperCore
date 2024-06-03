using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItsddtaxlistsBusiness
    {
        Task<PageResult<tsddtaxlists>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tsddtaxlists> GetTheDataAsync(string id);
        Task AddDataAsync(tsddtaxlists data);
        Task UpdateDataAsync(tsddtaxlists data);
        Task DeleteDataAsync(List<string> ids);
    }
}