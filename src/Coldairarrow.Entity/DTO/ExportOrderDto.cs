using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class ExportOrderDto
    {
        public string BillNo { get; set; }
        public string OperatorName { get; set; }
        public string EntryClerkName { get; set; }
        public string CustomerShortName { get; set; }
        public string ContactName { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? ConfirmTime { get; set; }
        public DateTime? EntryClerkTime { get; set; }
        public string OverseasConsigneeEname { get; set; }
        public int CommodityQuantity { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsManual { get; set; }
        public bool IsAfter6PM { get; set; }
        public bool IsAfter8PM { get; set; }
        public bool IsWeekend { get; set; }
        public bool HasTemplate { get; set; }
    }
}
