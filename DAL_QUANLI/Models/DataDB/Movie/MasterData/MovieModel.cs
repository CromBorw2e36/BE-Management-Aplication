using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.MasterData
{
    public class MovieModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? genres_id { get; set; }
        public string? thumbnail_url { get; set; }
        public string? trailer_url { get; set; }
        public string? movie_url { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public bool? is_delete { get; set; }
        public bool? is_active { get; set; }
        public string? national_id { get; set; }
        public string? language_id { get; set; }
        public int? release_year {  get; set; } 
        public double? duration { get; set; }

        [NotMapped]
        public int? page_current { get; set; } = 0;
        [NotMapped]
        public int? item_take { get; set; } = 10;
    }
}
