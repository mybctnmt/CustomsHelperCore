using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public interface Iitf_attached_documentBusiness
    {
        Task<PageResult<itf_attached_document>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<itf_attached_document> GetTheDataAsync(string id);
        Task AddDataAsync(itf_attached_document data);
        Task UpdateDataAsync(itf_attached_document data);
        Task DeleteDataAsync(List<string> ids);
    }
}