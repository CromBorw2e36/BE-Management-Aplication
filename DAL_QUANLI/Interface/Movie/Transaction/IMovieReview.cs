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
    public interface IMovieReview
    {
        public StatusMessage<MovieReivewModel> Insert(HttpRequest httpRequest, MovieReivewModel model);
        public StatusMessage<MovieReivewModel> Update(HttpRequest httpRequest, MovieReivewModel model);
        public StatusMessage<MovieReivewModel> Delete(HttpRequest httpRequest, MovieReivewModel model);
        public StatusMessage<List<MovieReivewModel>> Search(HttpRequest httpRequest, MovieReivewModel model);
        public StatusMessage<List<MovieReivewModel>> SearchRangePage(HttpRequest httpRequest, MovieReivewModel model);
    }
}
