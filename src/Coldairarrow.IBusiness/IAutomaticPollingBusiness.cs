using Coldairarrow.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.IBusiness
{
    public interface IAutomaticPollingBusiness
    {
        Task<List<AutomaticDto>> GetQueryData();
        Task<List<AutomaticDto>> GetDetailData();
        Task<bool> GetDetectionData();
        Task<List<RemindRecordDto>> GetUserRemindRecord(string userId);
        Task<List<RemindRecordDto>> GetRemindRecord();
        Task<List<AutomaticDto>> GetStateData();
        Task<List<AutomaticDto>> GetDetailDataAll(string flag);
    }
}
