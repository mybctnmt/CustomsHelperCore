using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Fieldwork
{
    public interface IttaskheadBusiness
    {
        Task<PageResult<ttaskhead>> GetDataListAsync(TaskHeadInputDto input);
        Task<ttaskhead> GetTheDataAsync(string id);
        Task AddDataAsync(ttaskhead data);
        Task UpdateDataAsync(ttaskhead data);
        Task DeleteDataAsync(List<string> ids);
        Task<TaskInfoDto> GetTaskInfo(string id);
        Task AcceptTaskAsync(string id);
        Task SaveTaskInfo(TaskInfoDto taskInfo);
    }
}