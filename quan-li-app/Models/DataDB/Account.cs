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

    }
}
