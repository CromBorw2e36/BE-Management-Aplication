using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.Movie.Transaction;
using DAL_QUANLI.Models.DataDB.Movie.Transaction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.Movie.Transaction
{
    public class MovieFavoritesService : rootCommonService, IMovieFavorites
    {
        public readonly string _tableName = "MovieFavorites";
        public StatusMessage<MovieFavoritesModel> Delete(HttpRequest httpRequest, MovieFavoritesModel model)
        {
            try
            {
                if(model == null 
                    || this.commonHelpers.CheckInValidVariableTypeString(model.id, false)
                    )
                {
                    return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {
                   

                    var result = this.dataContext.MovieFavoritesModel.FirstOrDefault(x => x.id == model.id);
                    if(result == null)
                    {
                        return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                    }
                    else
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        this.dataContext.MovieFavoritesModel.Update(result);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<MovieFavoritesModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                    }

                }
            }
            catch
            {
                return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<MovieFavoritesModel> Insert(HttpRequest httpRequest, MovieFavoritesModel model)
        {
            try
            {
                if(model == null 
                    || this.commonHelpers.CheckInValidVariableTypeString(model.movie_id, false)
                )
                {
                    return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {
                    model.is_delete = false;
                    model.create_date = DateTime.Now;
                    model.user_id = this.tokenHelper.GetUsername(httpRequest);
                    model.id = this.commonHelpers.GenerateRowID(this._tableName);

                    var resultMovie = this.dataContext.MovieModel.FirstOrDefault(x => x.id == model.movie_id);
                    if(resultMovie != null)
                    {
                        model.movie_name = resultMovie.name;
                        model.movie_description = resultMovie.description;
                        model.movie_thumbnail_url = resultMovie.thumbnail_url;
                        model.movie_url = resultMovie.movie_url;
                    }


                    this.dataContext.MovieFavoritesModel.Add(model);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieFavoritesModel>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<MovieFavoritesModel>> Search(HttpRequest httpRequest, MovieFavoritesModel model)
        {
            try
            {
                var resutl = this.dataContext.MovieFavoritesModel.Where(x =>
                    (model.id == null || x.id == model.id)
                    || (model.user_id == null || x.user_id == model.user_id)
                    || (model.movie_id == null || x.movie_id == model.movie_id)
                    || (model.is_delete == null || x.is_delete == model.is_delete))
                    .OrderBy(x => x.create_date)
                    .ThenBy(x => x.movie_name)
                    .ToList();

                return new StatusMessage<List<MovieFavoritesModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), resutl);
            }
            catch
            {
                return new StatusMessage<List<MovieFavoritesModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieFavoritesModel>());
            }
        }

        public StatusMessage<MovieFavoritesModel> Update(HttpRequest httpRequest, MovieFavoritesModel model)
        {
            try
            {
                if (model == null
                    || this.commonHelpers.CheckInValidVariableTypeString(model.movie_id, false)
                )
                {
                    return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {

                    var resultFavorites = this.dataContext.MovieFavoritesModel.FirstOrDefault(x => x.id == model.id);
                    if(resultFavorites == null)
                    {
                        return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                    }


                    resultFavorites.is_delete = false;
                    resultFavorites.create_date = DateTime.Now;
                    resultFavorites.user_id = this.tokenHelper.GetUsername(httpRequest);

                    
                    this.dataContext.MovieFavoritesModel.Update(model);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieFavoritesModel>(0, this.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieFavoritesModel>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
