using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境集装箱
    /// </summary>
    [Table("itf_dcl_io_decl_cont_detail")]
    public class itf_dcl_io_decl_cont_detail
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
        /// 集装箱号码
        /// </summary>
        public String ContainerNo { get; set; }

        /// <summary>
        /// 集装箱规格代码
        /// </summary>
        public String CntnrModeCode { get; set; }

        /// <summary>
        /// 集装箱自重
        /// </summary>
        public Decimal? ContainerWt { get; set; }

        /// <summary>
        /// 拼箱标识
        /// </summary>
        public String LclFlag { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}