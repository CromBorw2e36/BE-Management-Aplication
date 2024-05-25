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
    public class MovieWatchHistoryController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly MovieWatchHistoryService movieWatchHistoryService;

        public MovieWatchHistoryController()
        {
            this.commonService = new CommonService();
            this.movieWatchHistoryService = new MovieWatchHistoryService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<MovieWatchHistoryModel>>> Insert(MovieWatchHistoryModel model)
        {
            var res = this.movieWatchHistoryService.Insert(this.Request, model);
            this.commonService.LogTime<MovieWatchHistoryModel>(this.Request, this.movieWatchHistoryService._tableName, "INSERT", res);
            return res;
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<MovieWatchHistoryModel>>> Delete(MovieWatchHistoryModel model)
        {
            var res = this.movieWatchHistoryService.Insert(this.Request, model);
            this.commonService.LogTime<MovieWatchHistoryModel>(this.Request, this.movieWatchHistoryService._tableName, string.Format("Delete ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<MovieWatchHistoryModel>>>> Search(MovieWatchHistoryModel model)
        {
            var res = this.movieWatchHistoryService.Search(this.Request, model);
            return res;
        }

        [HttpPost("SearchRangePage")]
        public async Task<ActionResult<StatusMessage<List<MovieWatchHistoryModel>>>> SearchRangePage(MovieWatchHistoryModel model)
        {
            var res = this.movieWatchHistoryService.SearchRangePage(this.Request, model);
            return res;
        }



    }
}
