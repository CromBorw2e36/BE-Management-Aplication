using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime? create_at { get; set; }
        public bool? active { get; set; }
        public string? adminCompany { get; set; }
        public string? notes { get; set; }
        public int? left_company { get; set; }
        public int? right_company { get; set; }
        public bool? is_delete {  get; set; }
        public DateTime? delete_at {  get; set; }
        public DateTime? update_at { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public string? delete_by { get; set; }
        [NotMapped]
        public string? account_code { get; set; }
        public DateTime expiry { get; set; }
        public string? create_by_fullName {  get; set; }
        public string? update_by_fullName { get; set; }
        public string? delete_by_fullName { get; set; }
        public string? admin_company_fullName { get; set; }

    }
}
