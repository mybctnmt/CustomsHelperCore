using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_goods_limit_vnBusiness
    {
        Task<PageResult<itf_dcl_io_decl_goods_limit_vn>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_goods_limit_vn> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_goods_limit_vn data);
        Task UpdateDataAsync(itf_dcl_io_decl_goods_limit_vn data);
        Task DeleteDataAsync(List<string> ids);
    }
}