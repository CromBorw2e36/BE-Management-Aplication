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
    public interface IMovieGenresService
    {
        StatusMessage<MovieGenresModel> Insert(HttpRequest httpRequest, MovieGenresModel model);
        StatusMessage<MovieGenresModel> Update(HttpRequest httpRequest, MovieGenresModel model);
        StatusMessage<MovieGenresModel> Delete(HttpRequest httpRequest, MovieGenresModel model);
        StatusMessage<List<MovieGenresModel>> Search(HttpRequest httpRequest, MovieGenresModel model);
    }
}
