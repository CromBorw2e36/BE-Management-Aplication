using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.SystemCategory
{
    public class NationalLanguageService : rootCommonService, INationalLanguageService
    {
        public string _tableName = "National";

        public StatusMessage<National> Delete(HttpRequest httpRequest, National model)
        {
            try
            {
                var result = dataContext.Nationals.Where(x => (model.code == null || x.code == model.code)).OrderBy(x => x.zip_code).ToList();
                if (result.Count > 0)
                {
                    dataContext.RemoveRange(result);
                    dataContext.SaveChanges();
                    return new StatusMessage<National>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                }
                return new StatusMessage<National>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<National>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<National> Insert(HttpRequest httpRequest, National model)
        {
            try
            {
                if (model.code == null || model.code.Length == 0)
                {
                    model.code = commonHelpers.GenerateRowID("National");
                }
                else if (model.language == null || model.language.Length == 0)
                {
                    return new StatusMessage<National>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }

                dataContext.Nationals.Add(model);
                dataContext.SaveChanges();
                return new StatusMessage<National>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<National>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<National>> Search(HttpRequest httpRequest, National model)
        {
            try
            {
                var result = dataContext.Nationals.Where(x => (model.code == null || x.code == model.code)).OrderBy(x => x.zip_code).ToList();
                return new StatusMessage<List<National>>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<National>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<National>());
            }
        }

        public StatusMessage<National> Update(HttpRequest httpRequest, National model)
        {
            try
            {
                if (model.code == null || model.code.Length == 0)
                {
                    model.code = commonHelpers.GenerateRowID(_tableName);
                }
                else if (model.language == null || model.language.Length == 0)
                {
                    return new StatusMessage<National>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
                }

                var result = dataContext.Nationals.Where(x => x.code == model.code).ToList();
                if (result.Count > 0)
                {
                    dataContext.Nationals.RemoveRange(result);
                }

                dataContext.Nationals.Add(model);
                dataContext.SaveChanges();
                return new StatusMessage<National>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<National>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
