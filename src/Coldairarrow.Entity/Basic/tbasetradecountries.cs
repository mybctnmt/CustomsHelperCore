using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// tbasetradecountries
    /// </summary>
    [Table("tbasetradecountries")]
    public class tbasetradecountries
    {

        /// <summary>
        /// id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32 Id { get; set; }

        /// <summary>
        /// agreeMentId
        /// </summary>
        /*public Int32? agreeMentId { get; set; }*/
        public string agreeMentName { get; set; }
        /// <summary>
        /// countryName
        /// </summary>
        public String countryName { get; set; }

        /// <summary>
        /// createdAt
        /// </summary>
        public DateTime createdAt { get; set; }

    }
}