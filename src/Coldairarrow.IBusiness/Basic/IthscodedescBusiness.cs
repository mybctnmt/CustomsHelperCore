using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface IthscodedescBusiness
    {
        Task<PageResult<thscodedesc>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<thscodedesc> GetTheDataAsync(string id);
        Task AddDataAsync(thscodedesc data);
        Task UpdateDataAsync(thscodedesc data);
        Task DeleteDataAsync(List<string> ids);
        Task<List<thscodedesc>> GetHscodeListAsync(List<string> hscodes);
    }
}