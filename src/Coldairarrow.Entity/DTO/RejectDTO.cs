using Coldairarrow.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class RejectDTO
    {
        public List<string> OrderNos { get; set; }
        public string RejectReason { get; set; }
        public OrderType OrderType { get; set; }
    }
}
