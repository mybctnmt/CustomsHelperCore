using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Nems
{
    public interface ItimportinfoBusiness
    {
        Task<PageResult<timportinfo>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<timportinfo> GetTheDataAsync(string id);
        Task AddDataAsync(timportinfo data);
        Task UpdateDataAsync(timportinfo data);
        Task DeleteDataAsync(List<string> ids);
    }
}