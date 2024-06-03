using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItdetectioncontentBusiness
    {
        Task<PageResult<tdetectioncontent>> GetDataListAsync(PageInput<List<ConditionDTO>> input);
        Task<tdetectioncontent> GetTheDataAsync(string id);
        Task AddDataAsync(tdetectioncontent data);
        Task UpdateDataAsync(tdetectioncontent data);
        Task DeleteDataAsync(List<string> ids);
        Task SaveListAsync(List<tdetectioncontent> tdetectioncontents);
    }
}