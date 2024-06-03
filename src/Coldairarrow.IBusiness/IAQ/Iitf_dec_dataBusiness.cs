using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dec_dataBusiness
    {
        Task<PageResult<itf_dec_data>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dec_data> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dec_data data);
        Task UpdateDataAsync(itf_dec_data data);
        Task DeleteDataAsync(List<string> ids);
    }
}