using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 企业资质信息
    /// </summary>
    [Table("itf_dcl_io_decl_ent")]
    public class itf_dcl_io_decl_ent
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
        public Boolean? Deleted { get; set; }

        /// <summary>
        /// 企业资质编号
        /// </summary>
        public String EntQualifNo { get; set; }

        /// <summary>
        /// 企业资质类别代码/企业承诺证明、声明材料代码
        /// </summary>
        public String EntQualifTypeCode { get; set; }

        /// <summary>
        /// 根据HS编码设限情况确定
        /// </summary>
        public String EntQualifName { get; set; }

        /// <summary>
        /// 企业组织机构代码
        /// </summary>
        public String EntOrgCode { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public String EntName { get; set; }

        /// <summary>
        /// 业务类型：0/空：企业资质；1：企业承诺
        /// </summary>
        public String BizType { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}