using Coldairarrow.Entity.Dec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class DecDataDto
    {
        public tdechead dechead { get; set; }
        public List<tdeclist> declists { get; set; }
        public List<tdeccontainer> deccontainers { get; set; }
        public List<tdeccoplimit> deccoplimits { get; set; }
        public List<tdeccoppromise> deccoppromises { get; set; }

        public List<tdecgoodslimit> decgoodslimits { get; set; }
        public List<tdecgoodslimitvin> decgoodslimitvins { get; set; }
        public List<tdeclicensedocus> declicensedocuss { get; set; }
        public List<tdecmarklob> decmarklobs { get; set; }
        public List<tdecotherpack> decotherpacks { get; set; }
        public List<tdecrequestcert> decrequestcerts { get; set; }
        public List<tdecrisk> decrisks { get; set; }
        public List<tdecroyaltyfee> decroyaltyfees { get; set; }
       
        public List<tdecuser> decusers { get; set; }
        public List<tedocrealation> edocrealations { get; set; }
        public tdecfreetxt decfreetxt { get; set; }
        public List<tecorelation> ecorelations{ get; set; }
        public tdecsign decsign { get; set; }


    }
}
