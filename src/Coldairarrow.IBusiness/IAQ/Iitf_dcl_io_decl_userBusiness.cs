using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_userBusiness
    {
        Task<PageResult<itf_dcl_io_decl_user>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_user> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_user data);
        Task UpdateDataAsync(itf_dcl_io_decl_user data);
        Task DeleteDataAsync(List<string> ids);
    }
}