using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Nems
{
    /// <summary>
    /// 核注清单导入相关信息
    /// </summary>
    [Table("timportinfo")]
    public class timportinfo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }
        public String Id { get; set; }
        /// <summary>
        /// 报文类型
        /// </summary>
        public String MessageType { get; set; }

        /// <summary>
        /// 导入操作类型
        /// </summary>
        public String OpType { get; set; }

        /// <summary>
        /// 导入客户端统一编号
        /// </summary>
        public String HostId { get; set; }

        /// <summary>
        /// 对应的附件关系的个数
        /// </summary>
        public String FileSize { get; set; }

        /// <summary>
        /// 数字签名
        /// </summary>
        public String Sign { get; set; }
        public string OrderNo { get; set; }
    }
}