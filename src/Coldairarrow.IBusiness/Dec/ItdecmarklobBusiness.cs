using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItdecmarklobBusiness
    {
        Task<PageResult<tdecmarklob>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tdecmarklob> GetTheDataAsync(string id);
        Task AddDataAsync(tdecmarklob data);
        Task UpdateDataAsync(tdecmarklob data);
        Task DeleteDataAsync(List<string> ids);
    }
}