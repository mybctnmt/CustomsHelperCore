using Coldairarrow.Entity.Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class temailinfo
    {
        public temailorder temailorder { get; set; }
        public tinboxcontent tinboxcontent { get; set; }
        public List<tinboxattachment> tinboxattachments { get; set; }
    }
    public class temailallGroup
    {
        public String IsEntryClerk { get; set; }

        public string IsReject { get; set; }
        public string IsConfirmOrder { get; set; }
    }
}
