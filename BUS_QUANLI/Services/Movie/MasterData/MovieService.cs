using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.Movie.MasterData;
using DAL_QUANLI.Models.CustomModel.Movie.MasterData;
using DAL_QUANLI.Models.DataDB.Movie.MasterData;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.Movie.MasterData
{
    internal class MovieService : rootCommonService, IMovieService
    {
        public readonly string _tableName = "Movie";
        public StatusMessage<MovieModel> Delete(HttpRequest httpRequest, MovieModel model)
        {
            try
            {
                if(model == null)
                {
                    return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieModel());
                }else if (this.commonHelpers.CheckInValidVariableTypeString(model.id, false))
                {
                    return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieModel());
                }
                else 
                {
                    var result = this.dataContext.MovieModel.FirstOrDefault(x => x.id == model.id);
                    if (result != null)
                    {
                        result.is_delete = true;
                        result.is_active = false;
                        result.update_date = DateTime.Now;
                        result.update_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.Update(result);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<MovieModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                    }
                    else
                    {
                        return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new MovieModel());
                    }
                }
            }
            catch
            {
                return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieModel());
            }
        }

        public StatusMessage<MovieParamModel> Get(HttpRequest httpRequest, MovieModel model)
        {
            try
            {
                var result = this.dataContext.MovieModel
                   .Join(this.dataContext.MovieGenresModel, x => x.genres_id, y => y.id, (x, y) => new { movie = x, genres = y })
                   .Join(this.dataContext.Nationals, x =>  x.movie.national_id, z => z.code, (x, z) => new { movie = x.movie, genres = x.genres, national = z })
                    .Where(x =>
                   (model.genres_id == null || x.movie.genres_id == model.genres_id)
                   && (model.language_id == null || x.movie.language_id == model.language_id)
                   && (model.national_id == null || x.movie.national_id == model.national_id)
                   && (model.release_year == null || x.movie.release_year == model.release_year)
                   )
                   .OrderByDescending(x => x.movie.release_year).ThenBy(x => x.movie.name)
                   .Select(x => new MovieParamModel
                   {
                        id = x.movie.id,
                        name = x.movie.name ,
                        description = x.movie.description ,
                        genres_id = x.movie.genres_id ,
                        thumbnail_url = x.movie.thumbnail_url ,
                        trailer_url = x.movie.trailer_url ,
                        movie_url = x.movie.movie_url ,
                        create_date = x.movie.create_date ,
                        update_date = x.movie.update_date ,
                        create_by = x.movie.create_by ,
                        update_by = x.movie.update_by ,
                        is_delete = x.movie.is_delete ,
                        is_active = x.movie.is_active ,
                        national_id = x.movie.national_id ,
                        language_id = x.movie.language_id ,
                        release_year = x.movie.release_year ,
                        duration = x.movie.duration ,
                        curret_idx_item = null,
                        national_name = x.national.name ,
                        genres_name = x.genres.name ,
                        language_name = x.movie.language_id,
                   })
                   .ToList();

                return new StatusMessage<MovieParamModel>(0, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<MovieParamModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieParamModel());
            }
        }

        public StatusMessage<MovieModel> Insert(HttpRequest httpRequest, MovieModel model)
        {
            try
            {
                if(this.commonHelpers.CheckInValidVariableTypeString(model.language_id, false))
                {
                    model.language_id = "UNKONW";
                }
                if(this.commonHelpers.CheckInValidVariableTypeString(model.genres_id, false))
                {
                    model.genres_id = "UNKONW"; 
                }
                if(this.commonHelpers.CheckInValidVariableTypeString(model.national_id, false))
                {
                    model.national_id = "UNKONW";   
                }

                model.id = this.commonHelpers.GenerateRowID(this._tableName);
                model.is_delete = false;
                model.is_active = model.is_active != true ?  false : true;

                this.dataContext.MovieModel.Add(model);
                this.dataContext.SaveChanges();

                return new StatusMessage<MovieModel>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<MovieModel>> Search(HttpRequest httpRequest, MovieModel model)
        {
            try
            {
                var result = this.dataContext.MovieModel.Where(x =>
                   (model.genres_id == null || x.genres_id == model.genres_id)
                   && (model.language_id == null || x.language_id == model.language_id)
                   && (model.national_id == null || x.national_id == model.national_id)
                   && (model.release_year == null || x.release_year == model.release_year)
                   )
                   .OrderByDescending(x => x.release_year).ThenBy(x => x.name)
                   .ToList();
                   return new StatusMessage<List<MovieModel>>(0, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), result);     
            }
            catch
            {
                return new StatusMessage<List<MovieModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieModel>());
            }
        }

        public StatusMessage<List<MovieModel>> SearchRangePage(HttpRequest httpRequest, MovieModel model)
        {
            try
            {
                try
                {
                    if (model.page_current == null) model.page_current = 0;
                    if (model.item_take == null) model.page_current = 10;

                    var result = this.dataContext.MovieModel.Where(x =>
                       (model.genres_id == null || x.genres_id == model.genres_id)
                       && (model.language_id == null || x.language_id == model.language_id)
                       && (model.national_id == null || x.national_id == model.national_id)
                       && (model.release_year == null || x.release_year == model.release_year)
                       )
                       .OrderByDescending(x => x.release_year).ThenBy(x => x.name)
                       .Skip(model.page_current ?? 0)
                       .Take(model.item_take ?? 10)
                       .ToList();
                    return new StatusMessage<List<MovieModel>>(0, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), result);
                }
                catch
                {
                    return new StatusMessage<List<MovieModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieModel>());
                }
            }
            catch
            {
                return new StatusMessage<List<MovieModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieModel>());
            }
        }

        public StatusMessage<MovieModel> Update(HttpRequest httpRequest, MovieModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieModel());
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(model.id, false))
                {
                    return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieModel());
                }
                else
                {
                    var result = this.dataContext.MovieModel.FirstOrDefault(x => x.id == model.id);
                    if (result != null)
                    {
                       
                        model.update_date = DateTime.Now;
                        model.update_by = this.tokenHelper.GetUsername(httpRequest);

                        this.dataContext.MovieModel.Remove(result);
                        this.dataContext.MovieModel.Add(model);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<MovieModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                    }
                    else
                    {
                        return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new MovieModel());
                    }
                }
            }
            catch
            {
                return new StatusMessage<MovieModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), new MovieModel());
            }
        }
    }
}
