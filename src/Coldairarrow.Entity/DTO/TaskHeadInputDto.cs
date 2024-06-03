using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class TaskHeadInputDto : PageInput
    {
        public string TaskName { get; set; }
        public string TaskContent { get; set; }
        public string BillNo { get; set; }
        public string OrderNo { get; set; }
        public int Type { get; set; }
    }
}
