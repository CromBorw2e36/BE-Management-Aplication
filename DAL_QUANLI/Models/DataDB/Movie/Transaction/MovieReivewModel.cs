using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.Transaction
{
    public class MovieReivewModel
    {
        public string? id { get; set; }
        public string? user_id { get; set; }
        public string? user_name { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public double? rating { get; set; }
        public string? content { get; set; }
        public string? movie_id { get; set; }
        [NotMapped]
        public DateTime? from_date { get; set; }
        [NotMapped]
        public DateTime? to_date { get; set; }
        [NotMapped]
        public int? skip { get; set; } 
        [NotMapped]
        public int? take { get; set; } 
    }
}
