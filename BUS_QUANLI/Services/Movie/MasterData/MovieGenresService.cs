using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.Movie.MasterData;
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
    public class MovieGenresService : rootCommonService, IMovieGenresService
    {
        public readonly string _tableName = "MovieGenres";

        public StatusMessage<MovieGenresModel> Delete(HttpRequest httpRequest, MovieGenresModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);

                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(model.id, false))
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }

                var result  = this.dataContext.MovieGenresModel.FirstOrDefault(x => x.id ==  model.id); 
                
                if (result == null)
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {

                    var getListMovieOfGenres = this.dataContext.MovieModel
                        .Where(x => x.genres_id == result.id).ToList();

                    var getGenResTop1 = this.dataContext.MovieGenresModel.Take(1).FirstOrDefault();

                    foreach (var item in getListMovieOfGenres)
                    {
                        item.genres_id = getGenResTop1.id;
                    }

                    this.dataContext.MovieModel.UpdateRange(getListMovieOfGenres);
                    this.dataContext.MovieGenresModel.Remove(result);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieGenresModel>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<MovieGenresModel> Insert(HttpRequest httpRequest, MovieGenresModel model)
        {
            try
            {
                if(model == null)
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);

                }else if (this.commonHelpers.CheckInValidVariableTypeString(model.name, false))
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }

                model.id = this.commonHelpers.GenerateRowID(_tableName);
                model.create_date = DateTime.Now;
                model.create_by = this.tokenHelper.GetUsername(httpRequest);
                model.is_parent = false;
                model.update_date = DateTime.Now;   
                model.update_by = this.tokenHelper.GetUsername(httpRequest);

                this.dataContext.MovieGenresModel.Add(model);
                this.dataContext.SaveChanges();

                return new StatusMessage<MovieGenresModel>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);

            }
            catch
            {
                return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<MovieGenresModel>> Search(HttpRequest httpRequest, MovieGenresModel model)
        {
            try
            {
                var result = dataContext.MovieGenresModel.Where(x => model.id == null || x.id == model.id).ToList();
                return new StatusMessage<List<MovieGenresModel>>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<MovieGenresModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
            }
        }
            public StatusMessage<MovieGenresModel> Update(HttpRequest httpRequest, MovieGenresModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);

                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(model.id, false))
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), model);
                }

                var result = this.dataContext.MovieGenresModel.FirstOrDefault(x => x.id == model.id);

                if (result == null)
                {
                    return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    model.update_date = DateTime.Now;
                    model.update_by = this.tokenHelper.GetUsername(httpRequest);

                    this.dataContext.MovieGenresModel.Remove(result);
                    this.dataContext.MovieGenresModel.Add(model);
                    this.dataContext.SaveChanges();
                    return new StatusMessage<MovieGenresModel>(0, this.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MovieGenresModel>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
