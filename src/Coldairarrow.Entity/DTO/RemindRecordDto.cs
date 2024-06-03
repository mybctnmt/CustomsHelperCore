using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
   public class RemindRecordDto
    {
        /// <summary>
        /// 提醒名称
        /// </summary>
        public String UserTag { get; set; }

        /// <summary>
        /// 提醒级别
        /// </summary>
        public String ReminderLevel { get; set; }

        /// <summary>
        /// 提醒方式
        /// </summary>
        public String ReminderMethod { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }
        /// <summary>
        /// 提单号
        /// </summary>
        public String BillNo { get; set; }
        /// <summary>
        /// 消费使用/生产销售单位代码
        /// </summary>
        public String OwnerCode { get; set; }

        /// <summary>
        /// 消费使用/生产销售单位名称
        /// </summary>
        public String OwnerName { get; set; }
        /// <summary>
        /// 提醒时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
