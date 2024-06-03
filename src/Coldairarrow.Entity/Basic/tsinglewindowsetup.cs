using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 单一窗口设置
    /// </summary>
    [Table("tsinglewindowsetup")]
    public class tsinglewindowsetup
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
        /// 货物申报_发送文件
        /// </summary>
        public String Deccus001OutBox { get; set; }

        /// <summary>
        /// 货物申报_回执文件
        /// </summary>
        public String Deccus001InBox { get; set; }

        /// <summary>
        /// 货物申报_回执文件备份
        /// </summary>
        public String Deccus001HDNBox { get; set; }

        /// <summary>
        /// 货物申报_压缩回执文件备份
        /// </summary>
        public String Deccus001HDNBoxZIP { get; set; }

        /// <summary>
        /// 加工贸易手册_发送文件
        /// </summary>
        public String NptsOutBox { get; set; }

        /// <summary>
        /// 加工贸易手册_回执文件
        /// </summary>
        public String NptsInBox { get; set; }

        /// <summary>
        /// 加工贸易手册_回执文件备份
        /// </summary>
        public String NptsHDNBox { get; set; }

        /// <summary>
        /// 加工贸易手册_压缩回执文件备份
        /// </summary>
        public String NptsHDNBoxZIP { get; set; }

        /// <summary>
        /// 加工贸易账册_发送文件
        /// </summary>
        public String NemsOutBox { get; set; }

        /// <summary>
        /// 加工贸易账册_回执文件
        /// </summary>
        public String NemsInBox { get; set; }

        /// <summary>
        /// 加工贸易账册_回执文件备份
        /// </summary>
        public String NemsHDNBox { get; set; }

        /// <summary>
        /// 加工贸易账册_压缩回执文件备份
        /// </summary>
        public String NemsHDNBoxZIP { get; set; }

        /// <summary>
        /// 加工贸易随附单据_发送文件
        /// </summary>
        public String AcmpOutBox { get; set; }

        /// <summary>
        /// 加工贸易随附单据_回执文件
        /// </summary>
        public String AcmpInBox { get; set; }

        /// <summary>
        /// 加工贸易随附单据_回执文件备份
        /// </summary>
        public String AcmpHDNBox { get; set; }

        /// <summary>
        /// 加工贸易随附单据_压缩回执文件备份
        /// </summary>
        public String AcmpHDNBoxZIP { get; set; }

        /// <summary>
        /// 随附单据_发送文件
        /// </summary>
        public String Decedoc001OutBox { get; set; }

        /// <summary>
        /// 随附单据_回执文件
        /// </summary>
        public String Decedoc001InBox { get; set; }

        /// <summary>
        /// 随附单据_回执文件备份
        /// </summary>
        public String Decedoc001HDNBox { get; set; }

        /// <summary>
        /// 随附单据_压缩回执文件备份
        /// </summary>
        public String Decedoc001HDNBoxZIP { get; set; }

        /// <summary>
        /// 报关代理委托_发送文件
        /// </summary>
        public String AcdOutBox { get; set; }

        /// <summary>
        /// 报关代理委托_回执文件
        /// </summary>
        public String AcdInBox { get; set; }

        /// <summary>
        /// 报关代理委托_回执文件备份
        /// </summary>
        public String AcdHDNBox { get; set; }

        /// <summary>
        /// 报关代理委托_压缩回执文件备份
        /// </summary>
        public String AcdHDNBoxZIP { get; set; }

    }
}