using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Entity.Nems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class tinvtinfo
    {
        public tinvthead tinvthead { get; set; }
        public List<tinvtlist> tinvtlists { get; set; }
    }
}
