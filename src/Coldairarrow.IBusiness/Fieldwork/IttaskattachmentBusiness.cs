using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Fieldwork
{
    public interface IttaskattachmentBusiness
    {
        Task<PageResult<ttaskattachment>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttaskattachment> GetTheDataAsync(string id);
        Task AddDataAsync(ttaskattachment data);
        Task UpdateDataAsync(ttaskattachment data);
        Task DeleteDataAsync(List<string> ids);
    }
}