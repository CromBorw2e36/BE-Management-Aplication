using DAL_QUANLI.Interface.MasterData;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.MasterData
{
    public class CompanyService : rootCommonService, ICompanyService
    {
        public readonly string _tableName = "Company";
        public StatusMessage<Company> Delete(HttpRequest httpRequest, Company model)
        {
            try
            {
                 if(model.id == null)
                {
                    return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), null);

                }
                else
                {
                    Company result = this.dataContext.Companies.Where(x => x.id == model.id).FirstOrDefault();
                    if (result != null)
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.Update(result);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<Company>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                    else {
                    return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);

                    }
                }
            }
            catch
            {
                return new StatusMessage<Company>(1, this.GetMessageDescription(quan_li_app.Models.EnumQuanLi.DeleteError, httpRequest), null);
            }
        }

        public StatusMessage<Company> Insert(HttpRequest httpRequest, Company model)
        {
            try
            {
                if(model == null)
                {
                    return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.NoneData, httpRequest), null);
                }else if(model.code == null)
                {
                    return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), null);
                }

                model.create_at = DateTime.Now;
                model.create_by = this.tokenHelper.GetUsername(httpRequest);
                model.update_at = DateTime.Now;
                model.update_by = this.tokenHelper.GetUsername(httpRequest);
                model.is_delete = false;


                model.id = this.commonHelpers.GenerateRowID(this._tableName);
                if (model.active == null) model.active = false;

                this.dataContext.Companies.Add(model);
                this.dataContext.SaveChanges();
                return new StatusMessage<Company>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);


            }
            catch
            {
                return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), null);
            }
        }

        public StatusMessage<Company> InsertCompanyChild(HttpRequest httpRequest, Company model)
        {
            throw new NotImplementedException();
        }

        public StatusMessage<List<Company>> Search(HttpRequest httpRequest, Company model)
        {
            try
            {
                var result =  this.dataContext.Companies.Where(x => (model.is_delete == null || x.is_delete == model.is_delete)
                && (model.id == null || x.id == model.id)
                && (model.active == null || x.active == model.active)
                && (model.code == null || x.code == model.code)
                ).ToList();
                return new StatusMessage<List<Company>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<Company>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<Company>());
            }
        }

        public StatusMessage<Company> Update(HttpRequest httpRequest, Company model)
        {
            try
            {
                if(model.id == null)
                {
                    return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), null);
                }
                else
                {
                    var result  = this.dataContext.Companies.FirstOrDefault(x => x.id == model.id);
                    if(result == null)
                    {
                        return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
                    }
                    else
                    {
                        model.update_at = DateTime.Now;
                        model.update_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.Companies.Remove(result);
                        this.dataContext.Companies.Add(model);
                        this.dataContext.SaveChanges();

                        return new StatusMessage<Company>(0, this.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                    }
                }
            }
            catch
            {
                return new StatusMessage<Company>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), null);
            }
        }
    }
}
