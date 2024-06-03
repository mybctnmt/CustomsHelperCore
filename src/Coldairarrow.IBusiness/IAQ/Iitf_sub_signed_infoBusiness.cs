using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_sub_signed_infoBusiness
    {
        Task<PageResult<itf_sub_signed_info>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_sub_signed_info> GetTheDataAsync(string id);
        Task AddDataAsync(itf_sub_signed_info data);
        Task UpdateDataAsync(itf_sub_signed_info data);
        Task DeleteDataAsync(List<string> ids);
    }
}