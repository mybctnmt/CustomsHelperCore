using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Nems
{
    public interface ItnemsacmprlmessageBusiness
    {
        Task<PageResult<tnemsacmprlmessage>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tnemsacmprlmessage> GetTheDataAsync(string id);
        Task AddDataAsync(tnemsacmprlmessage data);
        Task UpdateDataAsync(tnemsacmprlmessage data);
        Task DeleteDataAsync(List<string> ids);
    }
}