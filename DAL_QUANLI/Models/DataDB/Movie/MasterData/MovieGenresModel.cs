using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.MasterData
{
    public class MovieGenresModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public string? genres_id { get; set; }   // id genres_farent
        public bool? is_parent { get; set; }
    }
}
