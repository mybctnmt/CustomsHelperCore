using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_entBusiness
    {
        Task<PageResult<itf_dcl_io_decl_ent>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_ent> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_ent data);
        Task UpdateDataAsync(itf_dcl_io_decl_ent data);
        Task DeleteDataAsync(List<string> ids);
    }
}