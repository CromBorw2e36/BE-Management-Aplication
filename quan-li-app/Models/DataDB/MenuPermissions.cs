using System.Text.Json.Serialization;

namespace quan_li_app.Models.DataDB
{
    public class MenuPermissions
    {
        public string? id { get; set; }
        public string? account { get; set; }
        public string? menuid { get; set; }
        [JsonIgnore]
        public DateTime? date { get; set; }
        [JsonIgnore]
        public string? modify { get; set; }
        public string? notes { get; set; }
    }
}
