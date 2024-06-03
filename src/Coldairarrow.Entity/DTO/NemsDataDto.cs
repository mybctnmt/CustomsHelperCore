using Coldairarrow.Entity.Nems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
   public class NemsDataDto
    {
        public tinvthead invthead { get; set; }
        public List<tinvtlist> invtlists { get; set; }
        public timportinfo importinfo { get; set; }
        public tinvtsign invtsign { get; set; }
        public List<tnemsacmprlmessage> nemsacmprlmessages { get; set; }
    }
}
