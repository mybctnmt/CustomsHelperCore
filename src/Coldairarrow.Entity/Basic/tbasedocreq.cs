using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// tbasedocreq
    /// </summary>
    [Table("tbasedocreq")]
    public class tbasedocreq
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32 Id { get; set; }

        /// <summary>
        /// appCertCode
        /// </summary>
        public String appCertCode { get; set; }

        /// <summary>
        /// appCertName
        /// </summary>
        public String appCertName { get; set; }

        /// <summary>
        /// applCopyQuan
        /// </summary>
        public String applCopyQuan { get; set; }

        /// <summary>
        /// applOri
        /// </summary>
        public String applOri { get; set; }

        /// <summary>
        /// requCertSeqNo
        /// </summary>
        public String requCertSeqNo { get; set; }

    }
}