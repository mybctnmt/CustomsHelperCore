using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItsddtaxheadBusiness
    {
        Task<PageResult<tsddtaxhead>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tsddtaxhead> GetTheDataAsync(string id);
        Task AddDataAsync(tsddtaxhead data);
        Task UpdateDataAsync(tsddtaxhead data);
        Task DeleteDataAsync(List<string> ids);
    }
}