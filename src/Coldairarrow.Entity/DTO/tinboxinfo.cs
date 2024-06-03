using Coldairarrow.Entity.Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class tinboxinfo
    {
        public string IsSeperate { get; set; }
        public string IsUrgent { get; set; }
        public string Description { get; set; }
        public string BillNo { get; set; }
        public tinboxcontent tinboxcontent { get; set; }
        public List<tinboxattachment> tinboxattachments { get; set; }
    }
}
