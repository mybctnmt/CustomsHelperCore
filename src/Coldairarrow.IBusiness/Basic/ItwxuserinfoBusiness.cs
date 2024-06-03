using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItwxuserinfoBusiness
    {
        Task<PageResult<twxuserinfo>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<twxuserinfo> GetTheDataAsync(string id);
        Task AddDataAsync(twxuserinfo data);
        Task UpdateDataAsync(twxuserinfo data);
        Task DeleteDataAsync(List<string> ids);
        Task<twxuserinfo> AccountBind(AccountBindDto accountBindDto);
        Task CancelBind(string openid);
        Task<twxuserinfo> GetWXToken(string openid);
    }
}