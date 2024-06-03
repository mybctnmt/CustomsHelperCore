using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_goodsBusiness
    {
        Task<PageResult<itf_dcl_io_decl_goods>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_goods> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_goods data);
        Task UpdateDataAsync(itf_dcl_io_decl_goods data);
        Task DeleteDataAsync(List<string> ids);
    }
}