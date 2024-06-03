using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasehscodeinfoBusiness
    {
        Task<PageResult<tbasehscodeinfo>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tbasehscodeinfo> GetTheDataAsync(string codets);
        Task AddDataAsync(tbasehscodeinfo data);
        Task UpdateDataAsync(tbasehscodeinfo data);
        Task DeleteDataAsync(List<string> ids);
        Task HscodeSync(thscodeinfo thscodeinfo);
    }
}