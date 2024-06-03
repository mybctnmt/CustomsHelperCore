using Coldairarrow.Entity.External;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using Coldairarrow.Util.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.External
{
    public interface IQingdaoPortBusiness
    {
        Task<QingdaoPortResult> UpdateArrivalAsync(Arrival arrival);
    }
}