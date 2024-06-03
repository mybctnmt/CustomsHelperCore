using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public interface ItecorelationBusiness
    {
        Task<PageResult<tecorelation>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<tecorelation> GetTheDataAsync(string id);
        Task AddDataAsync(tecorelation data);
        Task UpdateDataAsync(tecorelation data);
        Task DeleteDataAsync(List<string> ids);
    }
}