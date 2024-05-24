using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.Movie.MasterData
{
    public class MovieReactionModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public bool? visible { get; set; }
    }
}
