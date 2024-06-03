using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustomerbgremarkBusiness
    {
        Task<PageResult<tbasecustomerbgremark>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecustomerbgremark> GetTheDataAsync(string id);
        Task<string> AddDataAsync(tbasecustomerbgremark data);
        Task<string> UpdateDataAsync(tbasecustomerbgremark data);
        Task DeleteDataAsync(List<string> ids);
        Task SaveListData(BgRemarkDto bgRemarkDto);
    }
}