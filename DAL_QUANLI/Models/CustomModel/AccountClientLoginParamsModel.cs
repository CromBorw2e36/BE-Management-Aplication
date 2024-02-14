using System.Diagnostics.CodeAnalysis;

namespace DAL_QUANLI.Models.CustomModel
{
    public class AccountClientLoginParamsModel
    {
        [NotNull]
        public string account { get; set; }
        [NotNull]
        public string password { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? companyCode { get; set; }
        public string? type_device { get; set; }
        public string? os { get; set; }
        public string? browser { get; set; }
        public string? device { get; set; }
        public string? os_version { get; set; }
        public string? browser_version { get; set; }
        public string? ip_address { get; set; }
        public bool? is_mobile { get; set; }
        public bool? is_tablet { get; set; }
        public bool? is_desktop { get; set; }
        public bool? is_ios { get; set; }
        public bool? is_android { get; set; }
        public string? orientation { get; set; }  // Xác định hướng của thiết bị(ví dụ: portrait, landscape).
        public decimal? latitude { get; set; }  // Vĩ độ
        public decimal? longitude { get; set; }  // Kinh độ
    }
}
