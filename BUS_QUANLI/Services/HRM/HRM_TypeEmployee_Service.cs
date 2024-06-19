using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using quan_li_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.HRM
{
    public class HRM_TypeEmployee_Service:rootCommonService,  ICategoryService<TypeEmployeeModel>
    {
        public readonly string _tableName = "TypeEmployee";
        public StatusMessage<TypeEmployeeModel> Delete(HttpRequest httpRequest, TypeEmployeeModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.TypeEmployeeModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<TypeEmployeeModel>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<TypeEmployeeModel> Get(HttpRequest httpRequest, TypeEmployeeModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.TypeEmployeeModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        return new StatusMessage<TypeEmployeeModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<TypeEmployeeModel> Insert(HttpRequest httpRequest, TypeEmployeeModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
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

                    this.dataContext.TypeEmployeeModels.Add(model);
                    this.dataContext.SaveChanges();

                    return new StatusMessage<TypeEmployeeModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<List<TypeEmployeeModel>> Search(HttpRequest httpRequest, TypeEmployeeModel model)
        {
            try
            {
                List<TypeEmployeeModel> result = this.dataContext.TypeEmployeeModels.Where(x =>
                 (model.id == null || model.id == x.id) &&
                 (model.company_code == null || model.company_code == x.company_code)).ToList();

                return new StatusMessage<List<TypeEmployeeModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<TypeEmployeeModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<TypeEmployeeModel> Update(HttpRequest httpRequest, TypeEmployeeModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.TypeEmployeeModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        model.update_by = model.created_by;
                        model.update_at = model.created_at;
                        this.dataContext.TypeEmployeeModels.Remove(result);
                        this.dataContext.TypeEmployeeModels.Add(model);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<TypeEmployeeModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<TypeEmployeeModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
