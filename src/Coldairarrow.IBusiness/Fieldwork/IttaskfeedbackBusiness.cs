using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Fieldwork
{
    public interface IttaskfeedbackBusiness
    {
        Task<PageResult<ttaskfeedback>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<ttaskfeedback> GetTheDataAsync(string id);
        Task AddDataAsync(ttaskfeedback data);
        Task UpdateDataAsync(ttaskfeedback data);
        Task DeleteDataAsync(List<string> ids);
    }
}