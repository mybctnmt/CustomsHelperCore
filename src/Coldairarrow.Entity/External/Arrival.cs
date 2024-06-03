using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.External
{
    public class Arrival
    {
        public List<Data> data { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string YWCM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CKHC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TDH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FDH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CCXX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string XHDGQDM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SBDHGDM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FZHM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HZSJ { get; set; }
        /// <summary>
        /// 25202 海运出口运抵报告传输成功。比对结果为：运抵异常。
        /// </summary>
        public string HZMS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZHZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZTJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZJS { get; set; }
    }
}
