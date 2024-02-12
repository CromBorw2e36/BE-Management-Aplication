namespace quan_li_app.Models.DataDB
{
    public class TOKEN
    {
        public string? id { get; set; }
        public string? Token { get; set; }
        public string? username { get; set; }
        public DateTime? date { get; set; }
        public DateTime? endDate { get; set; }
        public string? ip_address { get; set; } // IP address
        public string? type_device { get; set; }
        public string? os { get; set; }
        public string? browser { get; set; }
        public string? device { get; set; }
        public string? os_version { get; set; }
        public string? browser_version { get; set; }
        public bool? is_mobile { get; set; }
        public bool? is_tablet { get; set; }
        public bool? is_desktop { get; set; }
        public bool? is_ios { get; set; }
        public bool? is_android { get; set; }
        public string? orientation { get; set; }  // Xác định hướng của thiết bị(ví dụ: portrait, landscape).
        public decimal? latitude { get; set; }  // Vĩ độ
        public decimal? longitude { get; set; }  // Kinh độ
        public string? connectionSignalID { get; set; }
    }
}
