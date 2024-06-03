using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// tbaseapttnamee
    /// </summary>
    [Table("tbaseapttnamee")]
    public class tbaseapttnamee
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