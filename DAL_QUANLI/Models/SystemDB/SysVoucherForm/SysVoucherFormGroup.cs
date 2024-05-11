using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.SystemDB.SysVoucherForm
{
    public class SysVoucherFormGroup
    {
        public string? id { get; set; }
        public string? table_name { get; set; }
        public string? code { get; set; } 
        public string? name { get; set; }
        public int? number_order { get; set; }
        public string? group_id { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? companyCode { get; set; }
    }
}
