using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbaseinspectionitemBusiness
    {
        Task<PageResult<tbaseinspectionitem>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbaseinspectionitem> GetTheDataAsync(string id);
        Task AddDataAsync(tbaseinspectionitem data);
        Task UpdateDataAsync(tbaseinspectionitem data);
        Task DeleteDataAsync(List<string> ids);
    }
}