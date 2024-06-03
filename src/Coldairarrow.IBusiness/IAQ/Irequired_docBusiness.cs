using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Irequired_docBusiness
    {
        Task<PageResult<required_doc>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<required_doc> GetTheDataAsync(string id);
        Task AddDataAsync(required_doc data);
        Task UpdateDataAsync(required_doc data);
        Task DeleteDataAsync(List<string> ids);
    }
}