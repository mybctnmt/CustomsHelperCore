using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustomerrelationBusiness
    {
        Task<PageResult<tbasecustomerrelation>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecustomerrelation> GetTheDataAsync(string id);
        Task AddDataAsync(tbasecustomerrelation data);
        Task UpdateDataAsync(tbasecustomerrelation data);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDatas(string cid, List<tbasecustomerrelation> datalist);
    }
}