using Coldairarrow.Entity.IAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.IAQ
{
    public class iaqinfo
    {
        public string Unumber { get; set; }
        public List<itf_dcl_io_decl> ididOC { get; set; }
        public List<itf_dcl_io_decl_att> ididaOC { get; set; }
        public List<itf_dcl_io_decl_goods> ididgOC { get; set; }
        public List<itf_dcl_io_decl_goods_cont> ididgcOC { get; set; }
        public List<itf_dcl_io_decl_goods_limit> ididglOC { get; set; }
        public List<itf_dcl_io_decl_goods_limit_vn> ididlvOC { get; set; }
        public List<itf_dcl_io_decl_goods_pack> ididgpOC { get; set; }
        public List<itf_dcl_io_decl_ent> idideOC { get; set; }
        public List<itf_dcl_io_decl_user> ididuOC { get; set; }
        public List<itf_dcl_mark_lob> idmlOC { get; set; }
        public List<itf_dcl_io_decl_cont_detail> ididcdOC { get; set; }

    }
}
