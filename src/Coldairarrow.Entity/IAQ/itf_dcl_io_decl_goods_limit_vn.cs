using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境许可证VIN信息
    /// </summary>
    [Table("itf_dcl_io_decl_goods_limit_vn")]
    public class itf_dcl_io_decl_goods_limit_vn
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
        /// 许可证编号
        /// </summary>
        public String LicenceNo { get; set; }

        /// <summary>
        /// 许可证类别代码
        /// </summary>
        public String LicTypeCode { get; set; }

        /// <summary>
        /// 提/运单日期
        /// </summary>
        public DateTime? BillLadDate { get; set; }

        /// <summary>
        /// 质量保质期
        /// </summary>
        public String QualityQgp { get; set; }

        /// <summary>
        /// 发动机号或电机号
        /// </summary>
        public String MotorNo { get; set; }

        /// <summary>
        /// 车辆识别代码（VIN）
        /// </summary>
        public String VinCode { get; set; }

        /// <summary>
        /// 底盘(车架)号
        /// </summary>
        public String ChassisNo { get; set; }

        /// <summary>
        /// 发票所列数量
        /// </summary>
        public Decimal? InvoiceNum { get; set; }

        /// <summary>
        /// 品名（中文名称）
        /// </summary>
        public String ProdCnnm { get; set; }

        /// <summary>
        /// 品名（英文名称）
        /// </summary>
        public String ProdEnnm { get; set; }

        /// <summary>
        /// 型号(英文)
        /// </summary>
        public String ModelEn { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public String PricePerUnit { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        public String InvoiceNo { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// Gnumber
        /// </summary>
        public String Gnumber { get; set; }

        /// <summary>
        /// Vnumber
        /// </summary>
        public String Vnumber { get; set; }

    }
}