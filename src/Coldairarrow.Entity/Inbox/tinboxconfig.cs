using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Inbox
{
    /// <summary>
    /// 收件箱配置表
    /// </summary>
    [Table("tinboxconfig")]
    public class tinboxconfig
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 邮箱账号
        /// </summary>
        public String EmailAddress { get; set; }

        /// <summary>
        /// 邮箱密码
        /// </summary>
        public String EmailPassword { get; set; }

        /// <summary>
        /// 邮箱类型
        /// </summary>
        public String EmailType { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 邮箱状态
        /// </summary>
        public String EmailState { get; set; }

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