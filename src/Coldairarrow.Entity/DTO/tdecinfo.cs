using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class tdecinfo
    {
        public temailorder temailorder { get; set; }
        public tdechead tdechead { get; set; }
        public List<tdeclist> tdeclists { get; set; }
        public List<tdeccontainer> tdeccontainers { get; set; }
        public List<tdeclicensedocus> tdeclicensedocuses { get; set; }
        public List<tdecotherpack> tdecotherpacks { get; set; }
        public List<tedocrealation> tedocrealations { get; set; }
        public List<tinboxattachment> tinboxattachments { get; set; }
        public List<tdecuser> tdecusers { get; set; }
        public List<tdeccoplimit> tdeccoplimits { get; set; }
        public List<tdecrequestcert> tdecrequestcerts { get; set; }
        public List<tdecgoodslimit> tdecgoodslimits { get; set; }
        public List<tdecgoodslimitvin> tdecgoodslimitvins { get; set; }
        public tdecfreetxt tdecfreetxt { get; set; }
        public tdecsign tdecsign { get; set; }
        public tdeccoppromise tdeccoppromise { get; set; }
        public tinboxcontent tinboxcontent { get; set; }
    }
}
