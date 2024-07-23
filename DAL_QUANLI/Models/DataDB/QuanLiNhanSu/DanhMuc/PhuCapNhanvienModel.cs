using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc
{
    public class PhuCapNhanvienModel
    {
        public string? id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? type { get; set; }
        public string? salary { get; set; }
        public bool? is_delete { get; set; }
        public bool? is_active { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public string? delete_by { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
        public string? company_code { get; set; }
        public string? create_by_fullname { get; set; }
        public string? update_by_fullname { get; set; }
        public string? delete_by_fullname { get; set; }
    }
}
