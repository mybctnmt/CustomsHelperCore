using Coldairarrow.Entity.Remind;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Remind
{
    public interface ItreminderrecordBusiness
    {
        Task<PageResult<treminderrecord>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<treminderrecord> GetTheDataAsync(string id);
        Task AddDataAsync(treminderrecord data);
        Task UpdateDataAsync(treminderrecord data);
        Task DeleteDataAsync(List<string> ids);
    }
}