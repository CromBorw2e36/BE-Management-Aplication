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
    public interface IMovieWatchHistory
    {
        public StatusMessage<MovieWatchHistoryModel> Insert(HttpRequest httpRequest, MovieWatchHistoryModel model);
        public StatusMessage<MovieWatchHistoryModel> Delete(HttpRequest httpRequest, MovieWatchHistoryModel model);
        public StatusMessage<List<MovieWatchHistoryModel>> Search(HttpRequest httpRequest, MovieWatchHistoryModel model);
        public StatusMessage<List<MovieWatchHistoryModel>> SearchRangePage(HttpRequest httpRequest, MovieWatchHistoryModel model);


    }
}
