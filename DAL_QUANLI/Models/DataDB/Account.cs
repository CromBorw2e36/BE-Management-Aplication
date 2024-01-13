using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace quan_li_app.Models.DataDB
{
    public class Account
    {
        public string? account { get; set; }
        public string? password { get; set; }
        public string? status { get; set; }
        [JsonIgnore]
        public DateTime? create_date { get; set; }
        [JsonIgnore]
        public DateTime? lock_date { get; set; }
        [JsonIgnore]
        public DateTime? last_enter { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? type_account { get; set; }
        public string? token { get; set; }
        public string? codePermision { get; set; }
        public string? companyCode { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int? levelPermision { get; set; }
        [NotMapped]
        public string? namePermision { get; set; }
        [NotMapped]
        public string? type_device { get; set; }
        [NotMapped]
        public string? os { get; set; }
        [NotMapped]
        public string? browser { get; set; }
        [NotMapped]
        public string? device { get; set; }
        [NotMapped]
        public string? os_version { get; set; }
        [NotMapped]
        public string? browser_version { get; set; }
        [NotMapped]
        public bool? is_mobile { get; set; }
        [NotMapped]
        public bool? is_tablet { get; set; }
        [NotMapped]
        public bool? is_desktop { get; set; }
        [NotMapped]
        public bool? is_ios { get; set; }
        [NotMapped]
        public bool? is_android { get; set; }
        [NotMapped]
        public string? orientation { get; set; }  // Xác định hướng của thiết bị(ví dụ: portrait, landscape).
        [NotMapped]
        public decimal? latitude { get; set; }  // Vĩ độ
        [NotMapped]
        public decimal? longitude { get; set; }  // Kinh độ
        [NotMapped]
        public string? connectionSignalID { get; set; }
    }
}
