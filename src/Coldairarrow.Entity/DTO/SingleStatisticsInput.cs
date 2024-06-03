using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class SingleStatisticsInput
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CustomerShortName { get; set; }
        public string EntryClerkName { get; set; }
        public string OperatorName { get; set; }
    }
    public class SingleSummaryInput
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TradeName { get; set; }
        public string SalespersonId { get; set; }
        public string CustomerId { get; set; }
    }
}
