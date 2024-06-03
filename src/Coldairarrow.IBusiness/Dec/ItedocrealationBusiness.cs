using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItedocrealationBusiness
    {
        Task<PageResult<tedocrealation>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<List<tedocrealation>> GetDataListOrderAsync(List<string> Order);
        Task<tedocrealation> GetTheDataAsync(string id);
        Task AddDataAsync(tedocrealation data);
        Task UpdateDataAsync(tedocrealation data);
        Task DeleteDataAsync(List<string> ids);
        Task<List<tedocrealation>> GetDataByEdocIDs(List<string> docIds);
        Task SaveDataByEdocCode(tedocrealation data);
    }
}