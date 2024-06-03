using Coldairarrow.Entity.Remind;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Remind
{
    public interface ItreminderuserlogBusiness
    {
        Task<PageResult<treminderuserlog>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<treminderuserlog> GetTheDataAsync(string id);
        Task AddDataAsync(treminderuserlog data);
        Task UpdateDataAsync(treminderuserlog data);
        Task DeleteDataAsync(List<string> ids);
    }
}