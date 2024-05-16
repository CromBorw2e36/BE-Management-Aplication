using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.SystemDB.SysVoucherForm
{
    public class SysVoucherFormColumn
    {
        public string? id { get; set; }
        public string? table_name { get; set; }
        public string? code { get; set; }
        public string? labelModel { get; set; } // Tạm thời không sử dụng
        public bool? edit { get; set; }
        public string? labelControl { get; set; } // English
        public string? labelControlVN { get; set; } // Vietnamese
        public string? labelControlCN { get; set; } // Chinese
        public bool? labelRequired { get; set; } // Required in label
        public bool? visible { get; set; } // show or hide
        public bool? disabled { get; set; }
        public bool? readOnly { get; set; }
        public bool? required { get; set; } // Tạm thời không sử dụng
        public bool? showClearButton { get; set; }
        public string? label { get; set; }// Tạm thời không sử dụng
        public string? placeholder { get; set; }
        public string? mode { get; set; } // ERROR: When use for date box component then not accept this null => default is 'text' value if typeControl is 'DATEBOX'
        public string? mask { get; set; }
        public string? maskRules { get; set; } // JSON parase
        public string? groupId { get; set; } // Form Group
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? companyCode { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public string? typeControl { get; set; } // Loại control config
        public string? format { get; set; }
        public string? description { get; set; } // Developer Description
        public string? description1 { get; set; } // English
        public string? description2 { get; set; } // Vietnamese
        public string? description3 { get; set; } // Chinese
        public int? number_order { get; set; } // Order by of column
        public string? displayFormat { get; set; } // For component datebox
        public string? type { get; set; } // Date , Datetime, time}

    }
}
