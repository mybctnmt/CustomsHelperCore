using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class SingleStatisticsOutput
    {
        public string EntryClerkName { get; set; }
        public int VoteNumber { get; set; }
        public int ProductNumber { get; set; }
        public int RejectCount { get; set; }
    }
    public class SingleSummaryOutput
    {
        public string CustomerShortName { get; set; }
        public int VoteNumber { get; set; }
    }
}
