using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_cont_detailBusiness
    {
        Task<PageResult<itf_dcl_io_decl_cont_detail>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_cont_detail> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_cont_detail data);
        Task UpdateDataAsync(itf_dcl_io_decl_cont_detail data);
        Task DeleteDataAsync(List<string> ids);
    }
}