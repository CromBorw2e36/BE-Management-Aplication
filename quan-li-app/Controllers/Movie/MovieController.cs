using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_QUANLI.Models.DataDB.Movie.MasterData;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using BUS_QUANLI.Services.MasterData;
using BUS_QUANLI.Services.Movie.MasterData;
using DAL_QUANLI.Models.CustomModel.Movie.MasterData;

namespace quan_li_app.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly MovieService movieService;

        public MovieController()
        {
            commonService = new CommonService();
            movieService = new MovieService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<MovieModel>>> Insert(MovieModel model)
        {
            var res = this.movieService.Insert(this.Request, model);
            this.commonService.LogTime<MovieModel>(this.Request, this.movieService._tableName, "INSERT", res);
            return res;
        }


        [HttpPost("Update")]
        public async Task<ActionResult<StatusMessage<MovieModel>>> Update(MovieModel model)
        {
            var res = this.movieService.Update(this.Request, model);
            this.commonService.LogTime<MovieModel>(this.Request, this.movieService._tableName, string.Format("UPDATE Movie ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<MovieModel>>> Delete(MovieModel model)
        {
            var res = this.movieService.Delete(this.Request, model);
            this.commonService.LogTime<MovieModel>(this.Request, this.movieService._tableName, string.Format("DELETE Movie ID: {0}", model.id), res);
            return res;
        }

        [HttpPost("Get")]
        public async Task<ActionResult<StatusMessage<MovieParamModel>>> Get(MovieModel model)
        {
            var res = this.movieService.Get(this.Request, model);
            this.commonService.LogTime<MovieParamModel>(this.Request, this.movieService._tableName, string.Format("GET Movie ID: {0}", model.id), res);
            return res;
        }
        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<MovieModel>>>> Search(MovieModel model)
        {
            var res = this.movieService.Search(this.Request, model);
            this.commonService.LogTime<List<MovieModel>>(this.Request, this.movieService._tableName, "INSERT", res);
            return res;
        }

        [HttpPost("SearchRangePage")]
        public async Task<ActionResult<StatusMessage<List<MovieModel>>>> SearchRangePage(MovieModel model)
        {
            var res = this.movieService.SearchRangePage(this.Request, model);
            //this.commonService.LogTime<List<MovieModel>> (this.Request, this.movieService._tableName, string.Format("SearchRangePage ", model.id), res);
            return res;
        }
    }

}
