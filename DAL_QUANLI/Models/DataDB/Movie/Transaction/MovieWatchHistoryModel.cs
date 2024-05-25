using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.Transaction
{
    public class MovieWatchHistoryModel
    {
        public string? id { get; set; }
        public string? user_id { get; set; }
        public string? user_name { get; set; }
        public DateTime? create_date { get; set; }
        public string? movie_id { get; set; }
        public string? movie_name { get; set; }
        public string? movie_url { get; set; }
        public string? movie_description { get; set; }
        public string? movie_thumbnail_url { get; set; }
        public double? time_view { get; set; }
        public bool?  is_delete { get; set; }
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
