using Coldairarrow.Entity.Fieldwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class TaskInfoDto
    {
        public ttaskhead ttaskhead { get; set; }
        public ttaskfeedback ttaskfeedback { get; set; }
        public List<ttaskattachment> ttaskattachments { get; set; }
        public List<ttaskcost> ttaskcosts { get; set; }
    }
}
