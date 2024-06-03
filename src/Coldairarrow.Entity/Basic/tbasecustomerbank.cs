using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 银行表
    /// </summary>
    [Table("tbasecustomerbank")]
    public class tbasecustomerbank
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        public String BankCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public String BankName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public String AccountNo { get; set; }

        /// <summary>
        /// 客户表ID
        /// </summary>
        public String CId { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public String LinkMan { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public String Currency { get; set; }     
    }
}