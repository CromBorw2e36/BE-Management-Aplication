using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.QuanLiNhanSu
{
    public class FollowTimeJoinAndOutModel
    {
        // Theo dỗi thời gian làm việc, ngày vào làm, ngày nghỉ việc, ngày vào làm lại
        public string? id { get; set; }
        public string? employee_id { get; set; }
        public string? description { get; set; }
        public DateTime? time { get; set; }
        public bool? is_join { get; set; }
        public bool? is_leave { get; set; }
        public bool? is_delete { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
        public string? created_by { get; set; }
        public string? update_by { get; set; }
        public string? delete_by { get; set; }
        public string? company_code { get; set; }
    }
}
