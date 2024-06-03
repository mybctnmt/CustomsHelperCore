using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 基础设置
    /// </summary>
    [Table("tbasesetup")]
    public class tbasesetup
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
        /// API请求地址
        /// </summary>
        public String APIURL { get; set; }

        public String ImageURL { get; set; }
        /// <summary>
        /// 自动获取列表
        /// </summary>
        public String AutoListRetrieval { get; set; }

        /// <summary>
        /// 自动获取明细
        /// </summary>
        public String AutoDetailRetrieval { get; set; }

        /// <summary>
        /// 自动获取运抵舱单
        /// </summary>
        public String AutoManifestRetrieval { get; set; }
        /// <summary>
        /// 自动查船期
        /// </summary>
        public String AutoQueryShip { get; set; } 
        /// <summary>
        /// 自动查询间隔
        /// </summary>
        public int AutoQueryTime { get; set; }

        /// <summary>
        /// 自动获取云港通
        /// </summary>
        public String AutoYungangtongRetrieval { get; set; }

        /// <summary>
        /// 卡密码
        /// </summary>
        public String CardPass { get; set; }

        /// <summary>
        /// 云港通账号
        /// </summary>
        public String YungangtongAcct { get; set; }

        /// <summary>
        /// 云港通密码
        /// </summary>
        public String YungangtongPass { get; set; }

        public String AttachmentPath { get; set; }
        public String SWControlPath { get; set; }

    }
}