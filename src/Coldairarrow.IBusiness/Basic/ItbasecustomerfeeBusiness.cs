using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustomerfeeBusiness
    {
        Task<PageResult<tbasecustomerfee>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecustomerfee> GetTheDataAsync(string id);
        Task<string> AddDataAsync(tbasecustomerfee data);
        Task<string> UpdateDataAsync(tbasecustomerfee data);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDatas(string cid, List<tbasecustomerfee> datalist);
    }
}