using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie
{
    public class MovieReactionToMovieModel
    {
        public string? id { get; set; } 
        public string? user_id { get; set; }
        public string? user_name { get; set; }
        public DateTime? create_date { get; set; }
        public string? reaction_code { get; set; } 
        public bool? is_active { get; set; }   
        public string? movie_id { get; set; }
    }
}
