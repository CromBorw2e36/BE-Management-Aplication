using DAL_QUANLI.Models.DataDB.Movie.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.CustomModel.Movie.MasterData
{
    public  class MovieParamModel: MovieModel
    {
        public int? curret_idx_item {  get; set; }   // index item in list
        public string? national_name { get; set; }
        public string? genres_name { get; set; }    
        public string? language_name { get; set; }
    }
}
