using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface IttrncontagoodsliBusiness
    {
        Task<PageResult<ttrncontagoodsli>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttrncontagoodsli> GetTheDataAsync(string id);
        Task AddDataAsync(ttrncontagoodsli data);
        Task UpdateDataAsync(ttrncontagoodsli data);
        Task DeleteDataAsync(List<string> ids);
    }
}