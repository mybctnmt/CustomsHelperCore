using Coldairarrow.Entity.DTO;
using Coldairarrow.IBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class swhelperController : BaseApiController
    {
        private ISWHelperBusiness sWHelper;
        public swhelperController(ISWHelperBusiness _sWHelper)
        {
            sWHelper = _sWHelper;
        }
        [HttpGet]
        public Task<DecDataDto> GetDecData(string orderNo)
        {
            return sWHelper.GetDecData(orderNo);
        }
        [HttpGet]
        public Task<NemsDataDto> GetNemsData(string orderNo)
        {
            return sWHelper.GetNemsData(orderNo);
        }
        [HttpPost]
        public Task<bool> SaveNemsData(NemsDataDto nemsData)
        {
            if (string.IsNullOrEmpty(nemsData.invthead.Id))
            {
                InitEntity(nemsData.invthead);
                InitEntity(nemsData.importinfo);
                InitEntity(nemsData.invtsign);
                foreach (var item in nemsData.nemsacmprlmessages)
                {
                    InitEntity(item);
                }                
                foreach (var item in nemsData.invtlists)
                {
                    InitEntity(item);
                }                
                return sWHelper.InsertNemsData(nemsData);
            }
            else
            {
                InitEntity(nemsData.importinfo);
                InitEntity(nemsData.invtsign);
                foreach (var item in nemsData.nemsacmprlmessages)
                {
                    InitEntity(item);
                }
                foreach (var item in nemsData.invtlists)
                {
                    InitEntity(item);
                }
                return sWHelper.UpdateNemsData(nemsData);
            }

           
        }
    }
}
