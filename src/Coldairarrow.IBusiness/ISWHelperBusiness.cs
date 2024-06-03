using Coldairarrow.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.IBusiness
{
   public interface ISWHelperBusiness
    {
        Task<DecDataDto> GetDecData(string orderNo);
        Task<NemsDataDto> GetNemsData(string oderNo);
        Task<bool> UpdateNemsData(NemsDataDto nemsData);
        Task<bool> InsertNemsData(NemsDataDto nemsData);
    }
}
