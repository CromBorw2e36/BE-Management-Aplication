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
    public class MovieWatchHistoryService : rootCommonService, IMovieWatchHistory
    {
        public readonly string _tableName = "MovieWatchHistory";
        public StatusMessage<MovieWatchHistoryModel> Delete(HttpRequest httpRequest, MovieWatchHistoryModel model)
        {
            try
            {
                if (
                    model == null
                    || this.commonHelpers.CheckInValidVariableTypeString(model.id)
                    )
                {
                    return new StatusMessage<MovieWatchHistoryModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.MovieWatchHistoryModel.FirstOrDefault(x => x.id == model.id);
                   if(result != null)
                   {
                        result.is_delete = true;
                        this.dataContext.MovieWatchHistoryModel.Update(result);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<MovieWatchHistoryModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                   }
                   else
                   {
                        return new StatusMessage<MovieWatchHistoryModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                   }
                }
            }
            catch
            {
                return new StatusMessage<MovieWatchHistoryModel>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<MovieWatchHistoryModel> Insert(HttpRequest httpRequest, MovieWatchHistoryModel model)
        {
            try
            {
                if(model == null)
                {
                    return new StatusMessage<MovieWatchHistoryModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {


                    var result = this.dataContext.MovieWatchHistoryModel
                        .FirstOrDefault(x => x.movie_id == model.movie_id && x.user_id == this.tokenHelper.GetUsername(httpRequest));
                    

                    if (result != null)
                    {
                        this.dataContext.MovieWatchHistoryModel.Remove(result);
                       
                    }

                    model.id = result != null ? result.id :  this.commonHelpers.GenerateRowID(this._tableName);
                    model.user_id = this.tokenHelper.GetUsername(httpRequest);

                    if (this.commonHelpers.CheckInValidVariableTypeString(model.user_name, false))
                    {
                        var user = this.dataContext.UserInfomation.FirstOrDefault(x => x.id == model.user_id);
                        if (user != null)
                        {
                            model.user_name = user.name;
                        }
                    }

                    if(this.commonHelpers.CheckInValidVariableTypeString(model.movie_name, false))
                    {
                        var movie = this.dataContext.MovieModel.FirstOrDefault(x => x.id == model.movie_id);
                        if(movie != null)
                        {
                           model.movie_name = movie.name;
                           model.movie_url = movie.movie_url;
                           model.movie_description = movie.description;

                        }
                    }

                    if(model.time_view == null)
                    {
                        model.time_view = 0;
                    }

                    this.dataContext.MovieWatchHistoryModel.Add(model);
                    this.dataContext.SaveChanges();

                    return new StatusMessage<MovieWatchHistoryModel>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieWatchHistoryModel>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<MovieWatchHistoryModel>> Search(HttpRequest httpRequest, MovieWatchHistoryModel model)
        {
            try
            {
                var result = this.dataContext.MovieWatchHistoryModel
                    .Where(x =>
                        (model.id == null || x.id == model.id)
                        && (model.movie_id == null || x.movie_id == model.movie_id)
                        && (model.user_id == null || x.user_id == model.user_id)
                        && (model.from_date == null || model.to_date == null || (model.from_date <= x.create_date && x.create_date <= model.to_date))
                        ).OrderByDescending(x => x.create_date)
                        .ThenBy(x => x.movie_name)
                        .ToList();

                return new StatusMessage<List<MovieWatchHistoryModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<MovieWatchHistoryModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model); 
            }
        }

        public StatusMessage<List<MovieWatchHistoryModel>> SearchRangePage(HttpRequest httpRequest, MovieWatchHistoryModel model)
        {
            try
            {
                var result = this.dataContext.MovieWatchHistoryModel
                    .Where(x =>
                        (model.id == null || x.id == model.id)
                        && (model.movie_id == null || x.movie_id == model.movie_id)
                        && (model.user_id == null || x.user_id == model.user_id)
                        && (model.from_date == null || model.to_date == null || (model.from_date <= x.create_date && x.create_date <= model.to_date))
                        )
                        .OrderByDescending(x => x.create_date)
                        .ThenBy(x => x.movie_name)
                        .Skip(model.skip ?? 0)
                        .Take(model.take ?? 10)
                        .ToList();

                return new StatusMessage<List<MovieWatchHistoryModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<MovieWatchHistoryModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

    }
}
