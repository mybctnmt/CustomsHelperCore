using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境随附单据信息
    /// </summary>
    [Table("itf_dcl_io_decl_att")]
    public class itf_dcl_io_decl_att
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 随附单据类别代码
        /// </summary>
        public String AttDocTypeCode { get; set; }

        /// <summary>
        /// 随附单据编号
        /// </summary>
        public String AttDocNo { get; set; }

        /// <summary>
        /// 随附单据名称
        /// </summary>
        public String AttDocName { get; set; }

        /// <summary>
        /// 随附单据核销货物序号
        /// </summary>
        public String AttDocWrtofDetailNo { get; set; }

        /// <summary>
        /// 随附单据核销数量
        /// </summary>
        public Decimal? AttDocWrtofQty { get; set; }

        /// <summary>
        /// 随附单据核销后明细余量
        /// </summary>
        public Decimal? AttDocDetailLeft { get; set; }

        /// <summary>
        /// 随附单据核销后余量
        /// </summary>
        public Decimal? AttDocWrtofLeft { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}