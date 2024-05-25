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
    public class MovieReviewService : rootCommonService, IMovieReview
    {
        public readonly string _tableName = "MovieReivew";
        public StatusMessage<MovieReivewModel> Delete(HttpRequest httpRequest, MovieReivewModel model)
        {
            try
            {
                if(model == null 
                    || this.commonHelpers.CheckInValidVariableTypeString(model.id, false)
                    )
                {
                    return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.MovieReivewModel.FirstOrDefault(x => x.id == model.id);   
                    if(result == null)
                    {
                        return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                    }
                    else
                    {
                        this.dataContext.MovieReivewModel.Remove(result);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<MovieReivewModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<MovieReivewModel> Insert(HttpRequest httpRequest, MovieReivewModel model)
        {
            try
            {
                if (model == null || this.commonHelpers.CheckInValidVariableTypeString(model.movie_id, false))
                {
                    return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {
                    model.id = this.commonHelpers.GenerateRowID(this._tableName);
                    model.create_date = DateTime.Now;
                    model.update_date = DateTime.Now;
                    model.user_id = this.tokenHelper.GetUsername(httpRequest);

                    if(this.commonHelpers.CheckInValidVariableTypeString(model.user_name, false))
                    {
                        var user = this.dataContext.UserInfomation.FirstOrDefault(x => x.id == model.user_id);   
                        if(user != null)
                        {
                            model.user_name = user.name;
                        }
                    }

                    if(model.rating == null)
                    {
                        model.rating = 0;
                    }

                    if(this.commonHelpers.CheckInValidVariableTypeString(model.content, false))
                    {
                        model.content = "";
                    }
                    
                    this.dataContext.MovieReivewModel.Add(model);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieReivewModel>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<MovieReivewModel>> Search(HttpRequest httpRequest, MovieReivewModel model)
        {
            try
            {
                var result = this.dataContext.MovieReivewModel
                    .Where(x =>
                        (model.movie_id == null || x.movie_id == model.movie_id)
                    && (model.user_id == null || x.user_id == model.user_id)
                    && (model.id == null || x.id == model.id)
                    && (model.from_date == null || model.to_date == null || (model.from_date <= x.update_date && x.update_date <= model.to_date))
                    )
                    .OrderByDescending(x => x.update_date)
                    .ThenBy(x => x.user_name)
                    .ToList();
                return new StatusMessage<List<MovieReivewModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<MovieReivewModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieReivewModel>());
            }
        }

        public StatusMessage<List<MovieReivewModel>> SearchRangeDate(HttpRequest httpRequest, MovieReivewModel model)
        {
 throw new NotImplementedException();
        }

        public StatusMessage<List<MovieReivewModel>> SearchRangePage(HttpRequest httpRequest, MovieReivewModel model)
        {
            try
            {
                var result = this.dataContext.MovieReivewModel
                    .Where(x =>
                        (model.movie_id == null || x.movie_id == model.movie_id)
                    && (model.user_id == null || x.user_id == model.user_id)
                    && (model.id == null || x.id == model.id)
                    && (model.from_date == null || model.to_date == null || (model.from_date <= x.update_date && x.update_date <= model.to_date))
                    )
                    .OrderByDescending(x => x.update_date)
                    .ThenBy(x => x.user_name)
                    .Skip(model.skip ?? 0)
                    .Take(model.take ?? 10)
                    .ToList();
                return new StatusMessage<List<MovieReivewModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<MovieReivewModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieReivewModel>());
            }
        }

        public StatusMessage<MovieReivewModel> Update(HttpRequest httpRequest, MovieReivewModel model)
        {
            try
            {
                if (model == null || this.commonHelpers.CheckInValidVariableTypeString(model.movie_id, false))
                {
                    return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {

                    var result = this.dataContext.MovieReivewModel.FirstOrDefault(x => x.id == model.id);
                    if(result == null)
                    {
                        return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                    }
                    else
                    {

                        model.create_date = DateTime.Now;
                        model.update_date = DateTime.Now;
                        model.user_id = this.tokenHelper.GetUsername(httpRequest);

                        if (this.commonHelpers.CheckInValidVariableTypeString(model.user_name, false))
                        {
                            var user = this.dataContext.UserInfomation.FirstOrDefault(x => x.id == model.user_id);
                            if (user != null)
                            {
                                model.user_name = user.name;
                            }
                        }

                        if (model.rating == null)
                        {
                            model.rating = 0;
                        }

                        if (this.commonHelpers.CheckInValidVariableTypeString(model.content, false))
                        {
                            model.content = "";
                        }

                        this.dataContext.MovieReivewModel.Remove(result);
                        this.dataContext.MovieReivewModel.Add(model);
                        this.dataContext.SaveChanges();

                        return new StatusMessage<MovieReivewModel>(0, this.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                    }
                }
            }
            catch
            {
                return new StatusMessage<MovieReivewModel>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
