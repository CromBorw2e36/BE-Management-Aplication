using BUS_QUANLI.Services.MasterData;
using BUS_QUANLI.Services.Movie.Transaction;
using DAL_QUANLI.Models.DataDB.Movie.Transaction;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Models.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quan_li_app.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieReviewController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly MovieReviewService movieReviewService;

        public MovieReviewController()
        {
            commonService = new CommonService();
            movieReviewService = new MovieReviewService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<MovieReivewModel>>> Insert(MovieReivewModel model)
        {
            var res = this.movieReviewService.Insert(this.Request, model);
            this.commonService.LogTime<MovieReivewModel>(this.Request, this.movieReviewService._tableName, "INSERT", res);
            return res;
        }

        [HttpPost("Update")]
        public async Task<ActionResult<StatusMessage<MovieReivewModel>>> Update(MovieReivewModel model)
        {
            var res = this.movieReviewService.Update(this.Request, model);
            this.commonService.LogTime<MovieReivewModel>(this.Request, this.movieReviewService._tableName, string.Format("Update ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<MovieReivewModel>>> Delete(MovieReivewModel model)
        {
            var res = this.movieReviewService.Delete(this.Request, model);
            this.commonService.LogTime<MovieReivewModel>(this.Request, this.movieReviewService._tableName, string.Format("Delete ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<MovieReivewModel>>>> Search(MovieReivewModel model)
        {
            var res = this.movieReviewService.Search(this.Request, model);
            return res;
        }

        [HttpPost("SearchRangePage")]
        public async Task<ActionResult<StatusMessage<List<MovieReivewModel>>>> SearchRangePage(MovieReivewModel model)
        {
            var res = this.movieReviewService.SearchRangePage(this.Request, model);
            return res;
        }


    }
}
