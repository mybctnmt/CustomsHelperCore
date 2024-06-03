using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_ciq_dataBusiness
    {
        Task<PageResult<itf_ciq_data>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_ciq_data> GetTheDataAsync(string id);
        Task AddDataAsync(itf_ciq_data data);
        Task UpdateDataAsync(itf_ciq_data data);
        Task DeleteDataAsync(List<string> ids);
    }
}