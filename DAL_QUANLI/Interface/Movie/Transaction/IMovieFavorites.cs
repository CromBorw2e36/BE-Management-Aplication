using DAL_QUANLI.Models.DataDB.Movie.Transaction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.Movie.Transaction
{
    public interface IMovieFavorites
    {
        public StatusMessage<MovieFavoritesModel> Insert (HttpRequest httpRequest, MovieFavoritesModel model);
        public StatusMessage<MovieFavoritesModel> Update (HttpRequest httpRequest, MovieFavoritesModel model);
        public StatusMessage<MovieFavoritesModel> Delete (HttpRequest httpRequest, MovieFavoritesModel model);
        public StatusMessage<List<MovieFavoritesModel>> Search (HttpRequest httpRequest, MovieFavoritesModel model);
    }
}
