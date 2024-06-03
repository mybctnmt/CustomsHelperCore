using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 检查项表
    /// </summary>
    [Table("tbaseinspectionitem")]
    public class tbaseinspectionitem
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public String TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public String FieldName { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        public String FieldValue { get; set; }

        /// <summary>
        /// 描述名称
        /// </summary>
        public String DescriptionName { get; set; }
        /// <summary>
        /// 触发条件
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// 类别1-节点2-条件
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public String FieldType { get; set; }
        public int? TriggerConditions { get; set; }
     

    }
}