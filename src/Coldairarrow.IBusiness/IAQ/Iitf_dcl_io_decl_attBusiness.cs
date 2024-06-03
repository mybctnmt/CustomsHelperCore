using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_attBusiness
    {
        Task<PageResult<itf_dcl_io_decl_att>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_att> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_att data);
        Task UpdateDataAsync(itf_dcl_io_decl_att data);
        Task DeleteDataAsync(List<string> ids);
    }
}