using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class SplitBillInfo
    {
        public string OrderNo { get; set; }
        public List<string> AttachmentIds { get; set; }
    }
}
