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
    public class MovieCommentService : rootCommonService, IMovieComment
    {

        public readonly string _tableName = "MovieComment";
        public StatusMessage<MovieCommentModel> Delete(HttpRequest httpRequest, MovieCommentModel model)
        {
            try
            {
                if(model == null)
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else if(this.commonHelpers.CheckInValidVariableTypeString(model.id, false))
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }

                var result = this.dataContext.MovieCommentModel.FirstOrDefault(x => x.id == model.id);
                if (result != null)
                {
                    this.dataContext.MovieCommentModel.Remove(result);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieCommentModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                }
                else
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<MovieCommentModel> Insert(HttpRequest httpRequest, MovieCommentModel model)
        {
            try
            {
                if(model == null)
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(model.movie_id, false))
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else if(this.commonHelpers.CheckInValidVariableTypeString(model.user_id, false))
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else
                {
                    model.id = this.commonHelpers.GenerateRowID(this._tableName);
                    model.is_delete = false;
                    model.create_date = DateTime.Now;
                    model.user_id = this.tokenHelper.GetUsername(httpRequest);

                    this.dataContext.MovieCommentModel.Add(model);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieCommentModel>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<MovieCommentModel>> Search(HttpRequest httpRequest, MovieCommentModel model)
        {
            try
            {
                var result = this.dataContext.MovieCommentModel.Where(x =>
                        (model.movie_id == null || x.movie_id == model.movie_id)
                        && (model.id_parent == null || x.id_parent == model.id_parent)
                        && (model.user_id == null || x.user_id == model.user_id)
                        && (model.is_delete == null || x.is_delete == model.is_delete)
                    ).ToList();

                return new StatusMessage<List<MovieCommentModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);

            }
            catch
            {
                return new StatusMessage<List<MovieCommentModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieCommentModel>());
            }
        }

        public StatusMessage<List<MovieCommentModel>> SearchByDate(HttpRequest httpRequest, MovieCommentModel model)
        {
            try
            {
                var result = this.dataContext.MovieCommentModel.Where(x =>
                        (model.movie_id == null || x.movie_id == model.movie_id)
                        && (model.id_parent == null || x.id_parent == model.id_parent)
                        && (model.user_id == null || x.user_id == model.user_id)
                        && (model.is_delete == null || x.is_delete == model.is_delete)
                        && (model.form_date == null || model.to_date == null || (x.create_date >= model.form_date && x.create_date <= model.to_date))
                    ).ToList();

                return new StatusMessage<List<MovieCommentModel>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);

            }
            catch
            {
                return new StatusMessage<List<MovieCommentModel>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MovieCommentModel>());
            }
        }

        public StatusMessage<MovieCommentModel> Update(HttpRequest httpRequest, MovieCommentModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(model.id, false))
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }

                var result = this.dataContext.MovieCommentModel.FirstOrDefault(x => x.id == model.id);
                if (result != null)
                {
                    this.dataContext.MovieCommentModel.Remove(result);
                    this.dataContext.MovieCommentModel.Add(model);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieCommentModel>(0, this.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                }
                else
                {
                    return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieCommentModel>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
