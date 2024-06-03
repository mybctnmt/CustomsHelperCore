using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// 客户信息表
    /// </summary>
    [Table("tbasecustomer")]
    public class tbasecustomer
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }


        /// <summary>
        /// 是否审核 0未审核 1已审核
        /// </summary>
        public String IsCheck { get; set; }

        /// <summary>
        /// 客户全称
        /// </summary>
        public String CustomerName { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        public String CustomerShortName { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        public String CustomerCode { get; set; }

        /// <summary>
        /// 外贸
        /// </summary>
        public String ForeignTrade { get; set; }

        /// <summary>
        /// 货代
        /// </summary>
        public String FreightForwarder { get; set; }

        /// <summary>
        /// 委托单位
        /// </summary>
        public String EntrustUnit { get; set; }

        /// <summary>
        /// 经营单位
        /// </summary>
        public String BusinessUnit { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        public String Consignor { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public String Consignee { get; set; }

        /// <summary>
        /// 通知人
        /// </summary>
        public String Notifier { get; set; }

        /// <summary>
        /// 船公司
        /// </summary>
        public String ShippingCompany { get; set; }

        /// <summary>
        /// 报关行
        /// </summary>
        public String CustomsBroker { get; set; }

        /// <summary>
        /// 场站
        /// </summary>
        public String Station { get; set; }

        /// <summary>
        /// 航空公司
        /// </summary>
        public String Airline { get; set; }

        /// <summary>
        /// 快递公司
        /// </summary>
        public String ExpressCompany { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public String Motorcade { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public String Other { get; set; }

        /// <summary>
        /// 海关编码
        /// </summary>
        public String CustomsCode { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public String BusinessCode { get; set; }

        /// <summary>
        /// 揽货人员
        /// </summary>
        public String Collector { get; set; }

        /// <summary>
        /// 客服人员
        /// </summary>
        public String CustomerService { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public String Telephone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public String Fax { get; set; }

        /// <summary>
        /// 网站
        /// </summary>
        public String Website { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

    }
}