using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境包装信息
    /// </summary>
    [Table("itf_dcl_io_decl_goods_pack")]
    public class itf_dcl_io_decl_goods_pack
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
        /// 辅助包装材料长
        /// </summary>
        public Decimal? PackLenth { get; set; }

        /// <summary>
        /// 辅助包装材料高
        /// </summary>
        public Decimal? PackHigh { get; set; }

        /// <summary>
        /// 辅助包装材料宽
        /// </summary>
        public Decimal? PackWide { get; set; }

        /// <summary>
        /// 辅助包装材料种类代码
        /// </summary>
        public String PackTypeCode { get; set; }

        /// <summary>
        /// 包装种类名称
        /// </summary>
        public String PackCatgName { get; set; }

        /// <summary>
        /// 包装种类中文简称
        /// </summary>
        public String PackTypeShort { get; set; }

        /// <summary>
        /// 包装件数
        /// </summary>
        public Decimal PackQty { get; set; }

        /// <summary>
        /// 是否主要包装
        /// </summary>
        public String IsMainPack { get; set; }

        /// <summary>
        /// 包装材料种类
        /// </summary>
        public String MatType { get; set; }

        /// <summary>
        /// 加工厂家
        /// </summary>
        public String ProcFactory { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// Gnumber
        /// </summary>
        public String Gnumber { get; set; }

    }
}