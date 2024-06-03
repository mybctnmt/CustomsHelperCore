using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Util.Primitives
{
    public class QingdaoPortResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; } = true;

        /// <summary>
        /// 回执信息
        /// </summary>
        public string message { get; set; }
    }
}
