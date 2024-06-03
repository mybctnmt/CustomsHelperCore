using Coldairarrow.Entity.DTO;
using Coldairarrow.IBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers
{
    [Route("/[controller]/[action]")]
    public class AutomaticPollingController : BaseApiController
    {

        private IAutomaticPollingBusiness automaticPolling;
        public AutomaticPollingController(IAutomaticPollingBusiness _automaticPolling)
        {
            automaticPolling = _automaticPolling;
        }
        [HttpGet]
        public Task<List<AutomaticDto>> GetQueryData()
        {
            return automaticPolling.GetQueryData();
        }
        [HttpGet]
        public Task<List<AutomaticDto>> GetDetailData()
        {
            return automaticPolling.GetDetailData();
        }
        [HttpGet]
        public Task<List<AutomaticDto>> GetDetailDataAll(string flag)
        {
            return automaticPolling.GetDetailDataAll(flag);
        }
        [HttpGet]
        public Task<List<AutomaticDto>> GetStateData()
        {
            return automaticPolling.GetStateData();
        }
        [HttpGet]
        public Task<List<RemindRecordDto>> GetUserRemindRecord(string uid)
        {
            return automaticPolling.GetUserRemindRecord(uid);
        }
        [HttpGet]
        public Task<List<RemindRecordDto>> GetRemindRecord()
        {
            return automaticPolling.GetRemindRecord();
        }
        [HttpPost]
        public Task<bool> GetDetectionData()
        {
            return automaticPolling.GetDetectionData();
        }
    }
}
