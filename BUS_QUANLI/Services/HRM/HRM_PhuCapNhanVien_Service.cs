using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.HRM
{
    public class HRM_PhuCapNhanVien_Service : rootCommonService, ICategoryService<PhuCapNhanvienModel>
    {
        public readonly string _tableName = "PhuCapNhanvien";
        public StatusMessage<PhuCapNhanvienModel> Delete(HttpRequest httpRequest, PhuCapNhanvienModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.PhuCapNhanvienModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<PhuCapNhanvienModel>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<PhuCapNhanvienModel> Get(HttpRequest httpRequest, PhuCapNhanvienModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.PhuCapNhanvienModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        return new StatusMessage<PhuCapNhanvienModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<PhuCapNhanvienModel> Insert(HttpRequest httpRequest, PhuCapNhanvienModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }
                else
                {
                    model.id = this.commonHelpers.GenerateRowID(_tableName);
                    model.company_code = this.tokenHelper.GetCompanyCode(httpRequest);
                    model.create_at = DateTime.Now;
                    model.create_by = this.tokenHelper.GetUsername(httpRequest);
                    model.update_by = model.create_by;
                    model.update_at = model.create_at;
                    model.is_delete = false;
                    model.delete_at = null;
                    model.delete_by = null;

                    this.dataContext.PhuCapNhanvienModels.Add(model);
                    this.dataContext.SaveChanges();

                    return new StatusMessage<PhuCapNhanvienModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<List<PhuCapNhanvienModel>> Search(HttpRequest httpRequest, PhuCapNhanvienModel model)
        {
            try
            {
                List<PhuCapNhanvienModel> result = this.dataContext.PhuCapNhanvienModels.Where(x =>
                 (model.id == null || model.id == x.id) &&
                 (model.company_code == null || model.company_code == x.company_code) &&
                 (model.is_delete == null || model.is_delete == x.is_delete) &&
                 (model.is_active == null || model.is_active == x.is_active)
                 ).ToList();

                return new StatusMessage<List<PhuCapNhanvienModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<PhuCapNhanvienModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<PhuCapNhanvienModel> Update(HttpRequest httpRequest, PhuCapNhanvienModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.PhuCapNhanvienModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        model.update_by = model.create_by;
                        model.update_at = model.create_at;
                        this.dataContext.PhuCapNhanvienModels.Remove(result);
                        this.dataContext.PhuCapNhanvienModels.Add(model);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<PhuCapNhanvienModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<PhuCapNhanvienModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
