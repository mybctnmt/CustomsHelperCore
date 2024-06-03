using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItsddtaxdetailsBusiness
    {
        Task<PageResult<tsddtaxdetails>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tsddtaxdetails> GetTheDataAsync(string id);
        Task AddDataAsync(tsddtaxdetails data);
        Task UpdateDataAsync(tsddtaxdetails data);
        Task DeleteDataAsync(List<string> ids);
    }
}