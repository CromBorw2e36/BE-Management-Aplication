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
    public class HRM_BonusNhanVien_Service : rootCommonService, ICategoryService<BonusNhanVienModel>
    {
        public readonly string _tableName = "BonusNhanVien";
        public StatusMessage<BonusNhanVienModel> Delete(HttpRequest httpRequest, BonusNhanVienModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.BonusNhanVienModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        result.is_delete = true;
                        result.delete_at = DateTime.Now;
                        result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                        model.delete_by_fullname = this.tokenHelper.GetFullname(httpRequest);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<BonusNhanVienModel>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<BonusNhanVienModel> Get(HttpRequest httpRequest, BonusNhanVienModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.BonusNhanVienModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        return new StatusMessage<BonusNhanVienModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<BonusNhanVienModel> Insert(HttpRequest httpRequest, BonusNhanVienModel model)
        {
            try
            {
                if (model == null)
                {
                    return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }
                else
                {
                    model.id = this.commonHelpers.GenerateRowID(_tableName);
                    model.company_code = this.tokenHelper.GetCompanyCode(httpRequest);
                    model.create_at = DateTime.Now;
                    model.create_by = this.tokenHelper.GetUsername(httpRequest);
                    model.create_by_fullname = this.tokenHelper.GetFullname(httpRequest);
                    model.update_by = model.create_by;
                    model.update_at = model.create_at;
                    model.update_by_fullname = this.tokenHelper.GetFullname(httpRequest);
                    model.is_delete = false;
                    model.delete_at = null;
                    model.delete_by = null;
                    model.delete_by_fullname = this.tokenHelper.GetFullname(httpRequest);

                    this.dataContext.BonusNhanVienModels.Add(model);
                    this.dataContext.SaveChanges();

                    return new StatusMessage<BonusNhanVienModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<List<BonusNhanVienModel>> Search(HttpRequest httpRequest, BonusNhanVienModel model)
        {
            try
            {
                List<BonusNhanVienModel> result = this.dataContext.BonusNhanVienModels.Where(x =>
                 (model.id == null || model.id == x.id) &&
                 (model.company_code == null || model.company_code == x.company_code) &&
                 (model.is_delete == null || model.is_delete == x.is_delete) &&
                 (model.is_active == null || model.is_active == x.is_active)
                 ).ToList();

                return new StatusMessage<List<BonusNhanVienModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<BonusNhanVienModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
            }
        }

        public StatusMessage<BonusNhanVienModel> Update(HttpRequest httpRequest, BonusNhanVienModel model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
                else
                {
                    var result = this.dataContext.BonusNhanVienModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result == null)
                    {
                        return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);

                    }
                    else
                    {
                        model.update_by = model.create_by;
                        model.update_at = model.create_at;
                        model.update_by_fullname = this.tokenHelper.GetFullname(httpRequest);
                        this.dataContext.BonusNhanVienModels.Remove(result);
                        this.dataContext.BonusNhanVienModels.Add(model);
                        this.dataContext.SaveChanges();
                        return new StatusMessage<BonusNhanVienModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), result);
                    }
                }
            }
            catch
            {
                return new StatusMessage<BonusNhanVienModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
