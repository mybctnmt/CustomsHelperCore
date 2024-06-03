using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustomercontactsBusiness
    {
        Task<PageResult<tbasecustomercontacts>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasecustomercontacts> GetTheDataAsync(string id);
        Task<string> AddDataAsync(tbasecustomercontacts data);
        Task<string> UpdateDataAsync(tbasecustomercontacts data);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDatas(string cid, List<tbasecustomercontacts> datalist);
    }
}