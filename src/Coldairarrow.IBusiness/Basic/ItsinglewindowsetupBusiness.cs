using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItsinglewindowsetupBusiness
    {
        Task<PageResult<tsinglewindowsetup>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tsinglewindowsetup> GetTheDataAsync(string id);
        Task AddDataAsync(tsinglewindowsetup data);
        Task UpdateDataAsync(tsinglewindowsetup data);
        Task DeleteDataAsync(List<string> ids);
    }
}