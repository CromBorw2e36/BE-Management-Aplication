using System.Text.Json.Serialization;

namespace quan_li_app.Models.DataDB
{
    public class Company
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public DateTime? date { get; set; }
        [JsonIgnore]
        public bool? active { get; set; }
        public string? adminCompany { get; set; }
        public string? notes { get; set; }
    }
}
