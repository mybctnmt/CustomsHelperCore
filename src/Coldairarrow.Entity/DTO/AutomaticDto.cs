using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
   public class AutomaticDto
    {
        public string Id { get; set; }
        public string BillNo { get; set; }
        public string OrderNo { get; set; }
        public string CusVoyageNo { get; set; }
        public string TrafName { get; set; }
        public string SeqNo { get; set; }
        public string EncryptString { get; set; }
        public string IEFlag { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CusDecStatus { get; set; }
        public string CusDecStatusName { get; set; }
    }
}
