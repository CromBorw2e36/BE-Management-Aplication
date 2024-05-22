using System.ComponentModel.DataAnnotations.Schema;

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

        // Account model plugin for search
        [NotMapped]
        public string? status { get; set; }
        [NotMapped]
        public DateTime? lock_date { get; set; }
        [NotMapped]
        public DateTime? last_enter { get; set; }
        [NotMapped]
        public string? email { get; set; }
        [NotMapped]
        public string? type_account { get; set; }
        [NotMapped]
        public string? namePermision { get; set; }
        [NotMapped]
        public string? status_f { get; set; }
        [NotMapped]
        public string? type_account_f { get; set; }


    }
}
