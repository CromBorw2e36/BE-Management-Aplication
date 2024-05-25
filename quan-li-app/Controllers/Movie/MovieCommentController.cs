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
    public class MovieCommentController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly MovieCommentService movieCommentService;   


        public MovieCommentController()
        {
            this.commonService = new CommonService();
            this.movieCommentService = new MovieCommentService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<MovieCommentModel>>> Insert(MovieCommentModel model)
        {
            var res = this.movieCommentService.Insert(this.Request, model);
            this.commonService.LogTime<MovieCommentModel>(this.Request, this.movieCommentService._tableName, "Insert Movie", res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<MovieCommentModel>>> Delete(MovieCommentModel model)
        {
            var res = this.movieCommentService.Delete(this.Request, model);
            this.commonService.LogTime<MovieCommentModel>(this.Request, this.movieCommentService._tableName, string.Format("Delete Movie ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Update")]
        public async Task<ActionResult<StatusMessage<MovieCommentModel>>> Update(MovieCommentModel model)
        {
            var res = this.movieCommentService.Update(this.Request, model);
            this.commonService.LogTime<MovieCommentModel>(this.Request, this.movieCommentService._tableName, string.Format("Update Movie ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<MovieCommentModel>>>> Search(MovieCommentModel model)
        {
            var res = this.movieCommentService.Search(this.Request, model);
            return res;
        }

        [HttpPost("SearchByDate")]
        public async Task<ActionResult<StatusMessage<List<MovieCommentModel>>>> SearchByDate(MovieCommentModel model)
        {
            var res = this.movieCommentService.SearchByDate(this.Request, model);
            return res;
        }

    }
}
