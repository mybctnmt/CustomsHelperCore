using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Basic
{
    /// <summary>
    /// thscodedesc
    /// </summary>
    [Table("thscodedesc")]
    public class thscodedesc
    {

        /// <summary>
        /// id
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// catalog_id
        /// </summary>
        public String catalog_id { get; set; }

        /// <summary>
        /// chapter_id
        /// </summary>
        public String chapter_id { get; set; }

        /// <summary>
        /// code
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// criteria
        /// </summary>
        public String criteria { get; set; }

        /// <summary>
        /// legal_unit1
        /// </summary>
        public String legal_unit1 { get; set; }

        /// <summary>
        /// legal_unit2
        /// </summary>
        public String legal_unit2 { get; set; }

        /// <summary>
        /// import_tariff_conv
        /// </summary>
        public String import_tariff_conv { get; set; }

        /// <summary>
        /// import_tariff_norm
        /// </summary>
        public String import_tariff_norm { get; set; }

        /// <summary>
        /// import_tariff_temp
        /// </summary>
        public String import_tariff_temp { get; set; }

        /// <summary>
        /// consumption_rate
        /// </summary>
        public String consumption_rate { get; set; }

        /// <summary>
        /// export_tariff
        /// </summary>
        public String export_tariff { get; set; }

        /// <summary>
        /// export_tariff_temp
        /// </summary>
        public String export_tariff_temp { get; set; }

        /// <summary>
        /// export_rebate_rate
        /// </summary>
        public String export_rebate_rate { get; set; }

        /// <summary>
        /// VAT
        /// </summary>
        public String VAT { get; set; }

        /// <summary>
        /// cust_supervision_cond
        /// </summary>
        public String cust_supervision_cond { get; set; }

        /// <summary>
        /// ins_quaran_type
        /// </summary>
        public String ins_quaran_type { get; set; }

        /// <summary>
        /// desc
        /// </summary>
        public String desc { get; set; }

        /// <summary>
        /// desc_en
        /// </summary>
        public String desc_en { get; set; }

        /// <summary>
        /// catalog_title
        /// </summary>
        public String catalog_title { get; set; }

        /// <summary>
        /// chapter_title
        /// </summary>
        public String chapter_title { get; set; }

    }
}