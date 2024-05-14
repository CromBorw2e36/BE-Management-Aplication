using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB
{
    public class LogTimeDataUpdateModel
    {
        public string? id { get; set; }
        public string? table_name { get; set; }
        public string? action_name { get; set; } // ADD, UPDATE, DELETE
        public DateTime? create_date { get; set; } // Do time
        public string? account { get; set; }
        public string? status { get; set; } // Success, Error
        public string? notes { get; set; }
        public string? companyCode { get; set; }
    }
}
