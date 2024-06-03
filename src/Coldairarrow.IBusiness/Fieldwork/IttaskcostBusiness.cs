using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Fieldwork
{
    public interface IQingdaoBusiness
    {
        Task<PageResult<ttaskcost>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttaskcost> GetTheDataAsync(string id);
        Task AddDataAsync(ttaskcost data);
        Task UpdateDataAsync(ttaskcost data);
        Task DeleteDataAsync(List<string> ids);
    }
}