using Coldairarrow.Entity.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class thscodeinfo
    {
        public tbasehscodeinfo tbasehscodeinfo { get; set; }
        public List<tbasehscodedec> tbasehscodedecIs { get; set; }
        public List<tbasehscodedec> tbasehscodedecEs { get; set; }
    }
}
