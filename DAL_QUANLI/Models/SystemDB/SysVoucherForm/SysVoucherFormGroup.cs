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
        public string? name1 { get; set; } // English
        public string? name2 { get; set; } // Vietnamese
        public string? name3 { get; set; } // Chinese
        public int? number_order { get; set; }
        public string? group_id { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }  
        public string? companyCode { get; set; }
        public string? description { get; set; } // Developer Description
        public string? description1 { get; set; } // English
        public string? description2 { get; set; } // Vietnamese
        public string? description3 { get; set; } // Chinese

    }
}
