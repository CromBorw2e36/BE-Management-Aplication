using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB
{
    public class UploadFileModel
    {
        public string? table_name { get; set; }
        public string? col_name { get; set; }
        public DateTime? create_date { get; set; }
        public string? create_by { get; set; }
        public string? id { get; set; } // primary key
        public string? file_name { get; set; }
        public string? file_type { get; set; }
        public double? file_size { get; set; }
        public string? file_path { get; set; }
        public string? description { get; set; }
        public string? company_code { get; set; }
        public bool? enabled { get; set; }
        [NotMapped]
        public List<IFormFile>? files { get; set; }
        [NotMapped]
        public dynamic? file { get; set; }
        [NotMapped]
        public IFormFile? file2 { get; set; }
    }
}
