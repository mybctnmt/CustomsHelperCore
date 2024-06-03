using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_declBusiness
    {
        Task<PageResult<itf_dcl_io_decl>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl data);
        Task UpdateDataAsync(itf_dcl_io_decl data);
        Task DeleteDataAsync(List<string> ids);
    }
}