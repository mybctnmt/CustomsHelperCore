using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Nems
{
    /// <summary>
    /// 核注清单随附单证
    /// </summary>
    [Table("tnemsacmprlmessage")]
    public class tnemsacmprlmessage
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
        /// 附件文件名称
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// 变更或报核次数
        /// </summary>
        public String ChgTmsCnt { get; set; }

        /// <summary>
        /// 随附单证格式
        /// </summary>
        public String AcmpFormFmt { get; set; }

        /// <summary>
        /// 业务单证类型
        /// </summary>
        public String BlsType { get; set; }

        /// <summary>
        /// 随附单证序号
        /// </summary>
        public Int64 AcmpFormSeqNo { get; set; }

        /// <summary>
        /// 随附单证类型代码
        /// </summary>
        public String AcmpFormTypeCd { get; set; }

        /// <summary>
        /// 随附单证编号
        /// </summary>
        public String AcmpFormNo { get; set; }

        /// <summary>
        /// 随附单证文件名称
        /// </summary>
        public String AcmpFormFileNm { get; set; }

        /// <summary>
        /// 清单商品序号
        /// </summary>
        public Int64? InvtGdsSeqNo { get; set; }

        /// <summary>
        /// 上传人IC卡号
        /// </summary>
        public String IcCardNo { get; set; }

        /// <summary>
        /// 上传单位海关编码
        /// </summary>
        public String TransferTradeCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Rmk { get; set; }

        /// <summary>
        /// 修改标记代码
        /// </summary>
        public String ModfMarkCd { get; set; }

        /// <summary>
        /// 包ID
        /// </summary>
        public String PocketId { get; set; }

        /// <summary>
        /// 当前包序号
        /// </summary>
        public Int32? CurPocketNo { get; set; }

        /// <summary>
        /// 总包数
        /// </summary>
        public Int32? TotalPocketQty { get; set; }
        public string OrderNo { get; set; }

    }
}