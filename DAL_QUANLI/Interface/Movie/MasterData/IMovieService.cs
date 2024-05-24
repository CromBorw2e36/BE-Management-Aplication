using DAL_QUANLI.Models.CustomModel.Movie.MasterData;
using DAL_QUANLI.Models.DataDB.Movie.MasterData;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.Movie.MasterData
{
    public interface IMovieService
    {
        public StatusMessage<MovieModel> Insert (HttpRequest httpRequest, MovieModel model);
        public StatusMessage<MovieModel> Update (HttpRequest httpRequest, MovieModel model);
        public StatusMessage<MovieModel> Delete (HttpRequest httpRequest, MovieModel model);
        public StatusMessage<MovieParamModel> Get (HttpRequest httpRequest, MovieModel model);

        public StatusMessage<List<MovieModel>> Search(HttpRequest httpRequest, MovieModel model);

    }
}
