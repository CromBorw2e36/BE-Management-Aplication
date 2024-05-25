using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.MasterData
{
    public class MovieActorModel
    {
        public string? id { get; set; } 
        public string? name { get; set; }   
        public string? avatar_url { get; set; } 
        public string? description { get; set; }
        public string? gender { get; set; }
        public string? nationality { get; set; }
        public string? birthday { get; set; }   
        public string? deathday { get; set; }
        public bool? is_delete {  get; set; }   
        public bool? is_visible { get; set; }
        public string? create_by { get; set; }  
        public DateTime? created_at { get; set;}
        public string? update_by { get; set; }
        public DateTime? updated_at { get;set; }
    }
}
