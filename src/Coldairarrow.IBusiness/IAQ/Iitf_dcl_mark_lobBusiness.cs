using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_mark_lobBusiness
    {
        Task<PageResult<itf_dcl_mark_lob>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_mark_lob> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_mark_lob data);
        Task UpdateDataAsync(itf_dcl_mark_lob data);
        Task DeleteDataAsync(List<string> ids);
    }
}