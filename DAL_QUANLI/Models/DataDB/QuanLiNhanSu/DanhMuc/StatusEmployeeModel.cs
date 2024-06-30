using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc
{
    public class StatusEmployeeModel
    {
        // Nghỉ việc, nghỉ phép, dưỡng thai
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int? level { get; set; }
        public bool? is_delete { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
        public string? created_by { get; set; }
        public string? update_by { get; set; }
        public string? delete_by { get; set; }
        public string? company_code { get; set; }
    }
}
