using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 优惠贸易协定项下原产地
    /// </summary>
    [Table("tbasecountryagree")]
    public class tbasecountryagree
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32 Id { get; set; }

        /// <summary>
        /// aid
        /// </summary>
        public String aid { get; set; }

        /// <summary>
        /// ciqCode
        /// </summary>
        public String ciqCode { get; set; }

        /// <summary>
        /// codeName
        /// </summary>
        public String codeName { get; set; }

        /// <summary>
        /// codeValue
        /// </summary>
        public String codeValue { get; set; }

        /// <summary>
        /// cusCode
        /// </summary>
        public String cusCode { get; set; }

        /// <summary>
        /// gbCode
        /// </summary>
        public String gbCode { get; set; }

        /// <summary>
        /// gbName
        /// </summary>
        public String gbName { get; set; }

    }
}