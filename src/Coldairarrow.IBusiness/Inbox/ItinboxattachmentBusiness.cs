using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public interface ItinboxattachmentBusiness
    {
        Task<PageResult<tinboxattachment>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<List<tinboxattachment>> GetDataListIDSAsync(List<string> ids);
        Task<tinboxattachment> GetTheDataAsync(string id);
        Task AddDataAsync(tinboxattachment data);
        Task UpdateDataAsync(tinboxattachment data);
        Task DeleteDataAsync(List<string> ids);
        Task<List<tinboxattachment>> GetAttachmentList(string orderNo);
    }
}