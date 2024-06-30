using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using quan_li_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;

namespace BUS_QUANLI.Services.HRM
{
    public class HRM_TypeWork_Service:rootCommonService, ICategoryService<TypeWorkModel>
    {
        public readonly string _tableName = "TypeWork";
        public StatusMessage<TypeWorkModel> Delete(HttpRequest httpRequest, TypeWorkModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.TypeWorkModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<TypeWorkModel>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<TypeWorkModel> Get(HttpRequest httpRequest, TypeWorkModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.TypeWorkModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        return new StatusMessage<TypeWorkModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<TypeWorkModel> Insert(HttpRequest httpRequest, TypeWorkModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }
                else
                {
                    model.id = this.commonHelpers.GenerateRowID(_tableName);
                    model.company_code = this.tokenHelper.GetCompanyCode(httpRequest);
                    model.created_at = DateTime.Now;
                    model.created_by = this.tokenHelper.GetUsername(httpRequest);
                    model.update_by = model.created_by;
                    model.update_at = model.created_at;
                    model.is_delete = false;
                    model.delete_at = null;
                    model.delete_by = null;

                    this.dataContext.TypeWorkModels.Add(model);
                    this.dataContext.SaveChanges();

                    return new StatusMessage<TypeWorkModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<List<TypeWorkModel>> Search(HttpRequest httpRequest, TypeWorkModel model)
        {
            try
            {
                List<TypeWorkModel> result = this.dataContext.TypeWorkModels.Where(x =>
                 (model.id == null || model.id == x.id) &&
                 (model.company_code == null || model.company_code == x.company_code) &&
                 (model.is_delete == null || model.is_delete == x.is_delete) &&
                 (model.is_active == null || model.is_active == x.is_active)
                 ).ToList();

                return new StatusMessage<List<TypeWorkModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<TypeWorkModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<TypeWorkModel> Update(HttpRequest httpRequest, TypeWorkModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.TypeWorkModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        model.update_by = model.created_by;
                        model.update_at = model.created_at;
                        this.dataContext.TypeWorkModels.Remove(result);
                        this.dataContext.TypeWorkModels.Add(model);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<TypeWorkModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<TypeWorkModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
