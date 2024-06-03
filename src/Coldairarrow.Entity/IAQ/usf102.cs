using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IAQ
{
    /// <summary>
    /// 响应业务数据USF102
    /// </summary>
    [Table("usf102")]
    public class usf102
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
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// Unumber
        /// </summary>
        public String Unumber { get; set; }

        /// <summary>
        /// 导入文件名
        /// </summary>
        public String FILE_NAME { get; set; }

        /// <summary>
        /// 单一窗口业务唯一标识


        /// </summary>
        public String FILE_TYPE { get; set; }

        /// <summary>
        /// 回执发送时间


        /// </summary>
        public String OP_TIME { get; set; }

        /// <summary>
        /// 响应结果
        /// </summary>
        public String PROC_RESULT { get; set; }

        /// <summary>
        /// 相应描述
        /// </summary>
        public String PROC_DESC { get; set; }

    }
}