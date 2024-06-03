using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecrequestcertBusiness
    {
        Task<PageResult<tdecrequestcert>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecrequestcert> GetTheDataAsync(string id);
        Task AddDataAsync(tdecrequestcert data);
        Task UpdateDataAsync(tdecrequestcert data);
        Task DeleteDataAsync(List<string> ids);
    }
}