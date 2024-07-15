using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.HRM;
using DAL_QUANLI.Models.CustomModel.HRM;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.HRM
{
    public class HRM_Employee_Service : rootCommonService, I_HRM_Employee_Service
    {
        public readonly string _TableName = "Employee";
        public StatusMessage<HRM_Employee_Model> Delete(HttpRequest httpRequest, HRM_Employee_Model model)
        {
            try
            {
                if(model == null || model.id == null)
                {
                    return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), null);
                }

                var result = this.dataContext.UserInfomation.FirstOrDefault(x => x.id == model.id);
                if(result == null)
                {
                    return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
                }

                result.delete_at = DateTime.Now;
                result.delete_by = this.tokenHelper.GetUsername(httpRequest);
                result.delete_by_fullname = this.tokenHelper.GetFullname(httpRequest);

                this.dataContext.UserInfomation.Update(result);
                this.dataContext.SaveChanges();
                
                return new StatusMessage<HRM_Employee_Model>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), null);
            }
        }

        public StatusMessage<HRM_Employee_Model> Get(HttpRequest httpRequest, HRM_Employee_Model model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), null);
                }

                var result = this.dataContext.UserInfomation.FirstOrDefault(x => x.id == model.id);
                if (result == null)
                {
                    return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
                }

                return new StatusMessage<HRM_Employee_Model>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
            }
        }


        public StatusMessage<HRM_Employee_Model> Insert(HttpRequest httpRequest, HRM_Employee_Model model)
        {
            try
            {
                model.id = this.commonHelpers.GenerateRowID(this._TableName);
                model.employee_code = this.commonHelpers.GenerateRowID(this._TableName);
                model.create_at = DateTime.Now;
                model.create_by = this.tokenHelper.GetUsername(httpRequest);
                model.update_at = DateTime.Now;
                model.update_by = this.tokenHelper.GetUsername(httpRequest);
                model.create_by_fullname = this.tokenHelper.GetFullname(httpRequest);
                model.update_by_fullname = model.create_by_fullname;

                if (model.codeCompany != null && model.codeCompany != "")
                {
                    Company company = dataContext.Companies.Where(x => x.id == model.codeCompany).FirstOrDefault();
                    if(company != null)
                    {
                        model.companyName = company.name;
                    }
                }

                this.dataContext.UserInfomation.Add(model);
                this.dataContext.SaveChanges();

                return new StatusMessage<HRM_Employee_Model>(0, this.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), null);
            }
        }

        public StatusMessage<List<HRM_Employee_Model>> Search(HttpRequest httpRequest, HRM_Employee_Model model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<List<HRM_Employee_Model>>(1, this.GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), null);
                }

                var result = this.dataContext.UserInfomation.Where(x =>
                    (model.BHXH == null || x.BHXH.IndexOf(model.BHXH) >= 0) &&
                    (model.CCCD == null || x.CCCD.IndexOf(model.CCCD) >= 0) &&
                    (model.is_delete == null || x.is_delete == model.is_delete)
                ).ToList();

                return new StatusMessage<List<HRM_Employee_Model>>(0, this.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<HRM_Employee_Model>>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
            }
        }

        public StatusMessage<HRM_Employee_Model> Update(HttpRequest httpRequest, HRM_Employee_Model model)
        {
            try
            {
                if (model == null || model.id == null)
                {
                    return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), null);
                }

                var result = this.dataContext.UserInfomation.FirstOrDefault(x => x.id == model.id);
                if (result == null)
                {
                    return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), null);
                }

                model.update_at = DateTime.Now;
                model.update_by = this.tokenHelper.GetUsername(httpRequest);

                if (model.codeCompany != null && model.codeCompany != "")
                {
                    Company company = dataContext.Companies.Where(x => x.id == model.codeCompany).FirstOrDefault();
                    if (company != null)
                    {
                        model.companyName = company.name;
                    }
                }

                model.update_by_fullname = this.tokenHelper.GetFullname(httpRequest);

                this.dataContext.UserInfomation.Remove(result);
                this.dataContext.UserInfomation.Add(result);
                this.dataContext.SaveChanges();

                return new StatusMessage<HRM_Employee_Model>(0, this.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<HRM_Employee_Model>(1, this.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), null);
            }
        }
    }
}
