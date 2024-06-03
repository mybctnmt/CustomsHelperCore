using Coldairarrow.Entity.Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class SendInfoOutput
    {
        public string OrderNo { get; set; }
        public string SendAddress { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string TrafName { get; set; }
        public string CusVoyageNo { get; set; }
        public string EmailType { get; set; }
        public string BillNo { get; set; }
        public string SeqNo { get; set; }
        public string EdocID { get; set; }
        public string TradeName { get; set; }
        public string OperatorId { get; set; }
        public string EmailId { get; set; }
        public List<temailcontent> Temailcontents { get; set; }
    }
}
