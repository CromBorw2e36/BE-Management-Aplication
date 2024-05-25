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
    public interface IMovieComment
    {
        public StatusMessage<MovieCommentModel> Insert(HttpRequest httpRequest, MovieCommentModel model);
        public StatusMessage<MovieCommentModel> Delete(HttpRequest httpRequest, MovieCommentModel model);
        public StatusMessage<MovieCommentModel> Update(HttpRequest httpRequest, MovieCommentModel model);
        public StatusMessage<List<MovieCommentModel>> Search(HttpRequest httpRequest, MovieCommentModel model);
        public StatusMessage<List<MovieCommentModel>> SearchByDate(HttpRequest httpRequest, MovieCommentModel model);
    }
}
