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
        public string? labelControl { get; set; }
        public bool? labelRequired { get; set; }
        public bool? visible { get; set; }
        public bool? disabled { get; set; }
        public bool? readOnly { get; set; }
        public bool? required { get; set; } // Tạm thời không sử dụng
        public bool? showClearButton { get; set; }
        public string? label { get; set; }// Tạm thời không sử dụng
        public string? placeholder { get; set; }
        public string? mode { get; set; }
        public string? mask { get; set; }
        public string? maskRules { get; set; } // JSON parase
        public string? groupId { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? companyCode { get; set; }
        public string? createBy { get; set; }
        public string? typeControl { get; set; } // Loại control config
        public string? format { get; set; }
        public string? description { get; set; }
    }
}
