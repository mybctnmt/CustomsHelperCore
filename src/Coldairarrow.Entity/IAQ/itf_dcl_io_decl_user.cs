using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 出入境使用人信息
    /// </summary>
    [Table("itf_dcl_io_decl_user")]
    public class itf_dcl_io_decl_user
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
        /// 使用人代码
        /// </summary>
        public String ConsumerUsrCode { get; set; }

        /// <summary>
        /// 使用人名称
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 使用单位联系人
        /// </summary>
        public String UseOrgPersonCode { get; set; }

        /// <summary>
        /// 使用单位联系电话
        /// </summary>
        public String UseOrgPersonTel { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

    }
}