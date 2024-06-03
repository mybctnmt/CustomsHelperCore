using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 系统设置表
    /// </summary>
    [Table("tsettingconfig")]
    public class tsettingconfig
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 邮件订单列表显示天数
        /// </summary>
        public int EmailListDataShowDays { get; set; }

        /// <summary>
        /// 报关单列表显示天数
        /// </summary>
        public int CusListDataShowDays { get; set; }

        /// <summary>
        /// 报文生成Ip
        /// </summary>
        public String EDIIp { get; set; }

        /// <summary>
        /// 报文生成端口
        /// </summary>
        public int EDIPort { get; set; }

        /// <summary>
        /// 文件保存路径
        /// </summary>
        public String FileSavePath { get; set; }

        /// <summary>
        /// 是否弹窗
        /// </summary>
        public bool IsPopUpReminder { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public String ServerFileSavePath { get; set; }
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public String FileDownLoadUrl { get; set; }

        /// <summary>
        /// 报关章
        /// </summary>
        public string BGChapter { get; set; }
        /// <summary>
        /// 公司章
        /// </summary>
        public string CompanyChapter { get; set; }
        /// <summary>
        /// 委托章
        /// </summary>
        public string WTChapter { get; set; }
        public string FTPPORT { get; set; }
        public string FTPUser { get; set; }
        public string FTPIP { get; set; }
        public string FTPPASS { get; set; }
        public string FTPCopId { get; set; }
        public string SWControlPath { get; set; }
        public string CID { get; set; }

    }
}