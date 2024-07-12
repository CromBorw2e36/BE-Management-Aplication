using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace quan_li_app.Models.DataDB.UserData
{
    public class UserInfo
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public string? gender { get; set; }
        public string? nationality { get; set; } // quốc tịch
        public string? ethnicity { get; set; } //  dân tộc
        public string? interests { get; set; } // sở thích
        public string? maritalStatus { get; set; } //  tình trạng hôn nhân
        public DateTime? modifyDate { get; set; } //  tình trạng hôn nhân
        public string? BHXH { get; set; } // sở thích
        public string? CCCD { get; set; } // sở thích
        public string? codeCompany { get; set; } // công ty 
        public string? avatar { get; set; } // ảnh đại diện
        public string? avatar16 { get; set; }  // ảnh đại diện 16x16
        public string? avatar32 { get; set; }  // ảnh đại diện 32 x 32
        public string? avatar64 { get; set; } // ảnh đại diện 64 x64
        // HRM module
        public string? email { get; set; }
        public string? department_id { get; set; }
        public string? type_employee_id { get; set; }
        public string? position_id { get; set; }
        public string? type_work_id { get; set; }
        public bool? is_delete { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public string? delete_by { get; set; }
    }
}
