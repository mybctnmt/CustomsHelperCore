using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public interface ItemailcontentBusiness
    {
        Task<PageResult<temailcontent>> GetDataListAsync(PageInput<List<ConditionDTO>> input);
        Task<temailcontent> GetTheDataAsync(string id);
        Task AddDataAsync(temailcontent data);
        Task UpdateDataAsync(temailcontent data);
        Task DeleteDataAsync(List<string> ids);
    }
}