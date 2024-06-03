using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdeclistBusiness
    {
        Task<PageResult<tdeclist>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdeclist> GetTheDataAsync(string id);
        Task AddDataAsync(tdeclist data);
        Task UpdateDataAsync(tdeclist data);
        Task DeleteDataAsync(List<string> ids);
        Task<List<tdeclist>> GetDataByCodeTS(CodeTSDTO codeTSDTO);
        Task<List<tdeclist>> GNameQueryAsync(string OwnerCode, string GName, string CodeTS);
    }
}