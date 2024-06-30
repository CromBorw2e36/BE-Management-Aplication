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
    public class HRM_StatusEmployee_Service : rootCommonService, ICategoryService<StatusEmployeeModel>
    {
        public readonly string _tableName = "StatusEmployee";
        public StatusMessage<StatusEmployeeModel> Delete(HttpRequest httpRequest, StatusEmployeeModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.StatusEmployeeModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<StatusEmployeeModel>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<StatusEmployeeModel> Get(HttpRequest httpRequest, StatusEmployeeModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.StatusEmployeeModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        return new StatusMessage<StatusEmployeeModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<StatusEmployeeModel> Insert(HttpRequest httpRequest, StatusEmployeeModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
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

                    this.dataContext.StatusEmployeeModels.Add(model);
                    this.dataContext.SaveChanges();

                    return new StatusMessage<StatusEmployeeModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<List<StatusEmployeeModel>> Search(HttpRequest httpRequest, StatusEmployeeModel model)
        {
            try
            {
                List<StatusEmployeeModel> result = this.dataContext.StatusEmployeeModels.Where(x =>
                 (model.id == null || model.id == x.id) &&
                 (model.company_code == null || model.company_code == x.company_code) &&
                 (model.is_delete == null || model.is_delete == x.is_delete) &&
                 (model.is_active == null || model.is_active == x.is_active)
                 ).ToList();

                return new StatusMessage<List<StatusEmployeeModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<StatusEmployeeModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<StatusEmployeeModel> Update(HttpRequest httpRequest, StatusEmployeeModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.StatusEmployeeModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        model.update_by = model.created_by;
                        model.update_at = model.created_at;
                        this.dataContext.StatusEmployeeModels.Remove(result);
                        this.dataContext.StatusEmployeeModels.Add(model);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<StatusEmployeeModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<StatusEmployeeModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
