using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Nems
{
    /// <summary>
    /// 核注清单签名信息
    /// </summary>
    [Table("tinvtsign")]
    public class tinvtsign
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
        /// 预录入统一编号
        /// </summary>

        public String SeqNo { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public String BusiType { get; set; }

        /// <summary>
        /// 变更次数
        /// </summary>
        public String ChgTmsCnt { get; set; }

        /// <summary>
        /// 经营单位海关编码
        /// </summary>
        public String BizopEtpsNo { get; set; }

        /// <summary>
        /// 经营单位社会信用代码
        /// </summary>
        public String BizopEtpsSccd { get; set; }

        /// <summary>
        /// 加工单位海关编码
        /// </summary>
        public String OwnerEtpsNo { get; set; }

        /// <summary>
        /// 加工单位社会信用代码
        /// </summary>
        public String OwnerEtpsSccd { get; set; }

        /// <summary>
        /// 加签卡号
        /// </summary>
        public String IcCode { get; set; }

        /// <summary>
        /// 卡用户海关编码
        /// </summary>
        public String IcEtpsNo { get; set; }

        /// <summary>
        /// 卡用户社会信用代码
        /// </summary>
        public String IcEtpsSccd { get; set; }

        /// <summary>
        /// 签名信息
        /// </summary>
        public String SignInfo { get; set; }

        /// <summary>
        /// 签名日期
        /// </summary>
        public String SignDate { get; set; }

        /// <summary>
        /// 加签证书编号
        /// </summary>
        public String CertNo { get; set; }
        public string OrderNo { get; set; }

    }
}