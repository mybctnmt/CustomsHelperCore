using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Dec
{
    /// <summary>
    /// 两段准入申请
    /// </summary>
    [Table("tdectpaccess")]
    public class tdectpaccess
    {

        /// <summary>
        /// 转场申请
        /// </summary>
        public String TransitionApply { get; set; }

        /// <summary>
        /// 转入场所场地
        /// </summary>
        public String TransitionSite { get; set; }

        /// <summary>
        /// 附条件提离申请
        /// </summary>
        public String ConditionalLiftoffApply { get; set; }

        /// <summary>
        /// 口岸与目的地合并检查申请
        /// </summary>
        public String PortDestMergeCheckApply { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 5)]
        public String Id { get; set; }
        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }
        public string OrderNo { get; set; }

    }
}