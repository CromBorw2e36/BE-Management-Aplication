using System.Text.Json.Serialization;

namespace quan_li_app.Models.Common
{
    public class SysStatus
    {
        public string? id { get; set; }
        [JsonIgnore]
        public string? module { get; set; }
        [JsonIgnore]
        public string? appModule { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        [JsonIgnore]
        public int? order_numer { get; set; }
        [JsonIgnore]
        public bool? enable { get; set; }

        public bool? accept_login { get; set; }
    }
}
