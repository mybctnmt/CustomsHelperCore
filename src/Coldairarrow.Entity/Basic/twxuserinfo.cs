using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// twxuserinfo
    /// </summary>
    [Table("twxuserinfo")]
    public class twxuserinfo
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        public String OpenId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 联合Id
        /// </summary>
        public String Unionid { get; set; }

        /// <summary>
        /// 公众号OpenId
        /// </summary>
        public String POpenId { get; set; }

    }
}