using Coldairarrow.Entity.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class BgRemarkDto
    {
        public string Name { get; set; }
        public string CId { get; set; }
        public List<tbasecustomerbgremark> tbasecustomerbgremarks { get; set; }
    }
}
