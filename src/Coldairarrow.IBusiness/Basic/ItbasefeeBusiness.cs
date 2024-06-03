using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasefeeBusiness
    {
        Task<PageResult<tbasefee>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasefee> GetTheDataAsync(string id);
        Task AddDataAsync(tbasefee data);
        Task UpdateDataAsync(tbasefee data);
        Task DeleteDataAsync(List<string> ids);

        Task<List<tbasefee>> SaveDatas(List<tbasefee> data);
    }
}