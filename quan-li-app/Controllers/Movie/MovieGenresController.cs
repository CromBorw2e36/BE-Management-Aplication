using BUS_QUANLI.Services.MasterData;
using BUS_QUANLI.Services.Movie.MasterData;
using DAL_QUANLI.Models.DataDB.Movie.MasterData;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Models.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quan_li_app.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly MovieGenresService movieGenresService;

        public MovieGenresController()
        {
            commonService = new CommonService();
            movieGenresService = new MovieGenresService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<MovieGenresModel>>> Insert(MovieGenresModel model)
        {
            var res = this.movieGenresService.Insert(this.Request, model);
            this.commonService.LogTime<MovieGenresModel>(this.Request, this.movieGenresService._tableName, "INSERT", res);
            return res;
        }

        [HttpPost("Update")]
        public async Task<ActionResult<StatusMessage<MovieGenresModel>>> Update(MovieGenresModel model)
        {
            var res = this.movieGenresService.Update(this.Request, model);
            this.commonService.LogTime<MovieGenresModel>(this.Request, this.movieGenresService._tableName, "UPDATE", res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<MovieGenresModel>>> Delete(MovieGenresModel model)
        {
            var res = this.movieGenresService.Delete(this.Request, model);
            this.commonService.LogTime<MovieGenresModel>(this.Request, this.movieGenresService._tableName, "DELETE", res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<MovieGenresModel>>>> Search(MovieGenresModel model)
        {
            var res = this.movieGenresService.Search(this.Request, model);
            //this.commonService.LogTime<List<MovieGenresModel>>(this.Request, this.movieGenresService._tableName, "INSERT", res);
            return res;
        }

    }
}
