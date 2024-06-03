using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItdeclarationdefaultBusiness
    {
        Task<PageResult<tdeclarationdefault>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdeclarationdefault> GetTheDataAsync(string id);
        Task AddDataAsync(tdeclarationdefault data);
        Task UpdateDataAsync(tdeclarationdefault data);
        Task DeleteDataAsync(List<string> ids);
    }
}