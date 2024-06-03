using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// tbaseorganization
    /// </summary>
    [Table("tbaseorganization")]
    public class tbaseorganization
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
        /// codeValue
        /// </summary>
        public String codeValue { get; set; }

    }
}