using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class EmailUpdateStatus
    {
        public string OrderNo { get; set; }
        public string SeqNo { get; set; }
        public string DeclarationStatus { get; set; }
        public string DeclarationReason { get; set; }
        public string INVDeclarationStatus { get; set; }
        public string INVDeclarationReason { get; set; }
        public string EntryId { get; set; }
        public string DDate { get; set; }
        public string CusDecStatus { get; set; }
        public string CusDecStatusName { get; set; }

        public string BondInvtNo { get; set; }

        public string EntrustedStatus { get; set; }
        public string EntrustedReason { get; set; }

    }
}
