using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public interface ItbasecustomerBusiness
    {
        Task<PageResult<tbasecustomer>> GetDataListAsync(PageInput<List<ConditionDTO>> input);
        Task<tbasecustomer> GetTheDataAsync(string id);
        Task<bool> CheckRepeat(tbasecustomer data);
        Task<string> AddDataAsync(tbasecustomer data);
        Task<string> UpdateDataAsync(tbasecustomer data);
        Task DeleteDataAsync(List<string> ids);
        Task DeleteData(string id);
        Task<string> Check(string Id, string Type);
        Task Import(DataTable dataTable);
    }
}