using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasequickentryBusiness
    {
        Task<PageResult<tbasequickentry>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasequickentry> GetTheDataAsync(string id);
        Task AddDataAsync(tbasequickentry data);
        Task UpdateDataAsync(tbasequickentry data);
        Task DeleteDataAsync(List<string> ids);
    }
}