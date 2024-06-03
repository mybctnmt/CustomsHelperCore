using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustomerbankBusiness
    {
        Task<PageResult<tbasecustomerbank>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecustomerbank> GetTheDataAsync(string id);
        Task<string> AddDataAsync(tbasecustomerbank data);
        Task SaveDatas(string cid, List<tbasecustomerbank> data);
        Task<string> UpdateDataAsync(tbasecustomerbank data);
        Task DeleteDataAsync(List<string> ids);
    }
}