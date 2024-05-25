using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.Movie.Transaction;
using DAL_QUANLI.Models.DataDB.Movie.Transaction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.Movie.Transaction
{
    public class MovieReviewService : rootCommonService, IMovieReview
    {
        public StatusMessage<MovieReivewModel> Delete(HttpRequest httpRequest, MovieReivewModel model)
        {
            throw new NotImplementedException();
        }

        public StatusMessage<MovieReivewModel> Insert(HttpRequest httpRequest, MovieReivewModel model)
        {
            throw new NotImplementedException();
        }

        public StatusMessage<List<MovieReivewModel>> Search(HttpRequest httpRequest, MovieReivewModel model)
        {
            throw new NotImplementedException();
        }

        public StatusMessage<List<MovieReivewModel>> SearchRangeDate(HttpRequest httpRequest, MovieReivewModel model)
        {
            throw new NotImplementedException();
        }

        public StatusMessage<List<MovieReivewModel>> SearchRangePage(HttpRequest httpRequest, MovieReivewModel model)
        {
            throw new NotImplementedException();
        }

        public StatusMessage<MovieReivewModel> Update(HttpRequest httpRequest, MovieReivewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
