using Coldairarrow.Business.External;
using Coldairarrow.Entity.External;
using Coldairarrow.Util.Primitives;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Qingdao
{
    [Route("/External/[controller]/[action]")]
    public class QingdaoPortController : BaseApiController
    {
        IQingdaoPortBusiness _qingdaoPortBusiness { get; }
        public QingdaoPortController(IQingdaoPortBusiness qingdaoPortBusiness)
        {
            _qingdaoPortBusiness = qingdaoPortBusiness;
        }
        

        [HttpPost]
        [AllowAnonymous]
        public async Task<QingdaoPortResult> UpdateArrival(Arrival arrival)
        {
            return await _qingdaoPortBusiness.UpdateArrivalAsync(arrival);
        }

    }
}
