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
        public StatusMessage<MovieGenresModel> Delete(HttpRequest httpRequest, MovieGenresModel model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public StatusMessage<MovieGenresModel> Update(HttpRequest httpRequest, MovieGenresModel model)
        {
            throw new NotImplementedException();
        }
    }
}
