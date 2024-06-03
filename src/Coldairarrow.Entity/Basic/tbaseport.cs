﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 港口
    /// </summary>
    [Table("tbaseport")]
    public class tbaseport
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
        /// gbCode
        /// </summary>
        public String gbCode { get; set; }

        /// <summary>
        /// ciqCode
        /// </summary>
        public String ciqCode { get; set; }

        public String enName { get; set; }
    }
}