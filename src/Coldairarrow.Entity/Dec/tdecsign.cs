using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 报关单签名
    /// </summary>
    [Table("tdecsign")]
    public class tdecsign
    {

        /// <summary>
        /// 操作类型
        /// </summary>
        public String OperType { get; set; }

        /// <summary>
        /// 操作员IC卡号
        /// </summary>
        public String ICCode { get; set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public String OperName { get; set; }

        /// <summary>
        /// 操作企业组织机构代码
        /// </summary>
        public String CopCode { get; set; }

        /// <summary>
        /// 客户端报关单编号
        /// </summary>
        public String ClientSeqNo { get; set; }

        /// <summary>
        /// 数字签名信息
        /// </summary>
        public String Sign { get; set; }

        /// <summary>
        /// 签名日期
        /// </summary>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 客户端邮箱的HostId
        /// </summary>
        public String HostId { get; set; }

        /// <summary>
        /// 操作员卡的证书号
        /// </summary>
        public String Certificate { get; set; }

        /// <summary>
        /// 签名人分类
        /// </summary>
        public String DomainId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 对应清单统一编号
        /// </summary>
        public String BillSeqNo { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 13)]
        public String Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }
    }
}