using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB
{
    public class CategoryCommonModel
    {
        public string? id { get; set; }
        public string? group_id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? name1 { get; set; }
        public string? name2 { get; set; }
        public string? name3 { get; set; }
        public int? number_order { get; set; }
        public string? description { get; set; }
        public string? company_code { get; set; }
        public DateTime? create_date {  get; set; }
        public DateTime? update_date { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        [NotMapped]
        public List<CategoryCommonModel>? items { get; set; }
    }
}
