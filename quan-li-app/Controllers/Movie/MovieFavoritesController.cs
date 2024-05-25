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
    public class MovieFavoritesController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly MovieFavoritesService movieFavoritesService;
        public MovieFavoritesController()
        {
            commonService = new CommonService();
            movieFavoritesService = new MovieFavoritesService();
        }

        [HttpPost("Insert")] 
        public  async Task<ActionResult<StatusMessage<MovieFavoritesModel>>> Insert(MovieFavoritesModel model)
        {
            var res = this.movieFavoritesService.Insert(this.Request, model);
            this.commonService.LogTime<MovieFavoritesModel>(this.Request, this.movieFavoritesService._tableName, "Insert", res);
            return res;
        }

        [HttpPost("Update")] 
        public  async Task<ActionResult<StatusMessage<MovieFavoritesModel>>> Update(MovieFavoritesModel model)
        {
            var res = this.movieFavoritesService.Update(this.Request, model);
            this.commonService.LogTime<MovieFavoritesModel>(this.Request, this.movieFavoritesService._tableName, string.Format("Update ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Delete")] 
        public async Task<ActionResult<StatusMessage<MovieFavoritesModel>>> Delete(MovieFavoritesModel model) 
        {
            var res = this.movieFavoritesService.Delete(this.Request, model);
            this.commonService.LogTime<MovieFavoritesModel>(this.Request, this.movieFavoritesService._tableName, string.Format("Delete ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<MovieFavoritesModel>>>> Search(HttpRequest httpRequest, MovieFavoritesModel model)
        {
            var res = this.movieFavoritesService.Search(this.Request, model);
            return res;
        }
    }
}
