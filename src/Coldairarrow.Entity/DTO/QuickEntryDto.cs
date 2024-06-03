using Coldairarrow.Entity.Dec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Entity.DTO
{
    public class QuickEntryDto : tdeclist
    {
        public string DDate { get; set; }
        public string OwnerCode { get; set; }
        public string OwnerName { get; set; }
        public string SeqNo { get; set; }
        public string BillNo { get; set; }
        public string HId { get; set; }
        public string TradeMode { get; set; }
        public string ManualNo { get; set; }
        public string TradeCode { get; set; }
        public string TradeName { get; set; }
        public string EntryId { get; set; }
        public string IEFlag { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public String CustomerId { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        public String CustomerShortName { get; set; }
        /// <summary>
        /// 境外发货人名称（外文）
        /// </summary>
        public String OverseasConsignorEname { get; set; }
        public String OverseasConsigneeEname { get; set; }
        public Decimal? FeeRate { get; set; }
        public Decimal? InsurRate { get; set; }
        public Decimal? OtherRate { get; set; }
        public string FeeMark { get; set; }
        public string InsurMark { get; set; }
        public string OtherMark { get; set; }
        public string FeeCurr { get; set; }
        public string InsurCurr { get; set; }
        public string OtherCurr { get; set; }

        public List<tdecgoodslimit> Tdecgoodslimits { get; set; }
        public List<tdecgoodslimitvin> Tdecgoodslimitvins { get; set; }
    }
}
