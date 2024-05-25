using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.Transaction
{
    public class MovieCommentModel
    {
        public string? id { get; set; }
        public string? user_id { get; set; }
        public string? movie_id { get; set; }
        public DateTime? create_date { get; set; }
        public bool is_delete { get; set; }
        public string? movie_url { get; set; }
        public string? content { get; set; }
        public bool? id_parent { get; set; }
        public string? parent_id { get; set; }

        [NotMapped]
        public DateTime? form_date {  get; set; }
        [NotMapped]
        public DateTime? to_date {  get; set; }
    }
}
