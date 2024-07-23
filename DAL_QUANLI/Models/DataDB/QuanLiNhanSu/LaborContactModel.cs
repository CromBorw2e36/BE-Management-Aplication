using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.QuanLiNhanSu
{
    public  class LaborContactModel
    {
        public string? id {  get; set; }
        public string? employee_code { get; set; }
        public string? type_labor { get; set; }
        public string? type_labor_name { get; set; }
        public DateTime? contact_sign_date {  get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set;}
        public double? basic_salary { get; set; }
        public string? phu_cap_code { get; set; }
        //[NotMapped]
        //public List<PhuCapNhanvienModel>? phu_cap_list { get; set; }
        public string? bonus_code {  get; set; }
        //[NotMapped]
        //public List<BonusNhanVienModel>? bonus_list { get; set; }
        public string? deduction_code { get; set; }
        //[NotMapped]
        //public List<DeductionNhanVienModel>? deduction_list { get; set; }
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
