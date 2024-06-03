using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 电子随附单据关联关系信息
    /// </summary>
    [Table("tedocrealation")]
    public class tedocrealation
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }
        /// <summary>
        /// 文件名、随附单据编号（文件名命名规则是：申报口岸+随附单据类别代码+IM+18位流水号+.pdf）
        /// </summary>

        public String EdocID { get; set; }

        /// <summary>
        /// 随附单证类别
        /// </summary>
        public String EdocCode { get; set; }

        /// <summary>
        /// 随附单据格式类型
        /// </summary>
        public String EdocFomatType { get; set; }

        /// <summary>
        /// 操作说明（重传原因）
        /// </summary>
        public String OpNote { get; set; }

        /// <summary>
        /// 随附单据文件企业名
        /// </summary>
        public String EdocCopId { get; set; }

        /// <summary>
        /// 所属单位海关编号
        /// </summary>
        public String EdocOwnerCode { get; set; }

        /// <summary>
        /// 签名单位代码
        /// </summary>
        public String SignUnit { get; set; }

        /// <summary>
        /// 签名时间
        /// </summary>
        public String SignTime { get; set; }

        /// <summary>
        /// 所属单位名称
        /// </summary>
        public String EdocOwnerName { get; set; }

        /// <summary>
        /// 随附单据文件大小
        /// </summary>
        public String EdocSize { get; set; }

        /// <summary>
        /// 商品项号关系
        /// </summary>
        public String GNoStr { get; set; }

      
        public DateTime? CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public String FilePath { get; set; }

    }
}