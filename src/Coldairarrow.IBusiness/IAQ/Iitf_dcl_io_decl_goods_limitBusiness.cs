using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_dcl_io_decl_goods_limitBusiness
    {
        Task<PageResult<itf_dcl_io_decl_goods_limit>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_dcl_io_decl_goods_limit> GetTheDataAsync(string id);
        Task AddDataAsync(itf_dcl_io_decl_goods_limit data);
        Task UpdateDataAsync(itf_dcl_io_decl_goods_limit data);
        Task DeleteDataAsync(List<string> ids);
    }
}