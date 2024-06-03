using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 客户联系人表
    /// </summary>
    [Table("tbasecustomercontacts")]
    public class tbasecustomercontacts
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public String Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public String Age { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public String Position { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public String Department { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>
        public String OfficePhone { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public String QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public String Wechat { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public String MobilePhone { get; set; }

        /// <summary>
        /// 爱好
        /// </summary>
        public String Hobby { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 客户表ID
        /// </summary>
        public String CId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

    }
}