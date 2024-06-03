using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public interface IBase_DispatchBusiness
    {
        Task<PageResult<Base_Dispatch>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<Base_Dispatch> GetTheDataAsync(string id);
        Task AddDataAsync(Base_Dispatch data);
        Task UpdateDataAsync(Base_Dispatch data);
        Task DeleteDataAsync(List<string> ids);
        Task<Base_Dispatch> GetOneDataAsync(string id);
    }
}