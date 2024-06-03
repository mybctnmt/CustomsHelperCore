using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public interface ItinboxcontentBusiness
    {
        Task<PageResult<tinboxcontent>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tinboxcontent> GetTheDataAsync(string id);
        Task<tinboxcontent> GetOneData(string email);
        Task<string> AddDataAsync(tinboxcontent data);
        Task<string> UpdateDataAsync(tinboxcontent data);
        Task DeleteDataAsync(List<string> ids);
        Task AddInboxInfoAsync(List<tinboxinfo> data);
        Task<tinboxcontent> GetOneDataEmailId(string emailId, DateTime sendTime);
    }
}