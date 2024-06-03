using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 集装箱规格
    /// </summary>
    [Table("tbasenorms")]
    public class tbasenorms
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32 Id { get; set; }

        /// <summary>
        /// codeName
        /// </summary>
        public String codeName { get; set; }

        /// <summary>
        /// cusCode
        /// </summary>
        public String cusCode { get; set; }

        /// <summary>
        /// codeValue
        /// </summary>
        public String codeValue { get; set; }

        /// <summary>
        /// gbName
        /// </summary>
        public String gbName { get; set; }

        /// <summary>
        /// ciqName
        /// </summary>
        public String ciqName { get; set; }

        /// <summary>
        /// cusName
        /// </summary>
        public String cusName { get; set; }

        /// <summary>
        /// gbCode
        /// </summary>
        public String gbCode { get; set; }

        /// <summary>
        /// ciqCode
        /// </summary>
        public String ciqCode { get; set; }

    }
}