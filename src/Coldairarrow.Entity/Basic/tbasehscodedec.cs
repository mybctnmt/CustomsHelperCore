using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// hscode申报要素
    /// </summary>
    [Table("tbasehscodedec")]
    public class tbasehscodedec
    {

        /// <summary>
        /// hscode
        /// </summary>
        public String hscode { get; set; }

        /// <summary>
        /// requireCheck
        /// </summary>
        public String requireCheck { get; set; }

        /// <summary>
        /// decFacCode
        /// </summary>
        public String decFacCode { get; set; }

        /// <summary>
        /// codeTs
        /// </summary>
        public String codeTs { get; set; }

        /// <summary>
        /// decFacName
        /// </summary>
        public String decFacName { get; set; }

        /// <summary>
        /// gname
        /// </summary>
        public String gname { get; set; }

        /// <summary>
        /// decFacType
        /// </summary>
        public String decFacType { get; set; }

        /// <summary>
        /// ieFlag
        /// </summary>
        public String ieFlag { get; set; }

        /// <summary>
        /// textName
        /// </summary>
        public String textName { get; set; }

        /// <summary>
        /// snum
        /// </summary>
        public String snum { get; set; }

        /// <summary>
        /// extendFiled
        /// </summary>
        public String extendFiled { get; set; }

        /// <summary>
        /// decFacContent
        /// </summary>
        public String decFacContent { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 13)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }
        public String EorI { get; set; }
    }
}