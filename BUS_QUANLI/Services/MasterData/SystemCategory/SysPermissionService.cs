using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.MasterData.SystemCategory
{
    public class SysPermissionService : rootCommonService, ISysPermissionService
    {
        public string _tableName = "SysPermission";

        public StatusMessage<SysPermission> Delete(HttpRequest httpRequest, SysPermission model)
        {
            try
            {
                var result = dataContext.SysPermissions.Where(x => x.code == model.code).OrderBy(x => x.order_number).ToList();

                if (result.Count > 0)
                {
                    dataContext.SysPermissions.RemoveRange(result);
                    dataContext.SaveChanges();
                    return new StatusMessage<SysPermission>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                }
                else
                {
                    return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<SysPermission> Insert(HttpRequest httpRequest, SysPermission model)
        {
            try
            {
                if (model.name == null)
                {
                    return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DataNoName, httpRequest), model);
                }
                else if (model.level == null)
                {
                    return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DataNoLevel, httpRequest), model);
                }
                else
                {
                    var result = dataContext.SysPermissions.Where(x => x.code == model.code).ToList();

                    if (result.Count > 0)
                    {
                        return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DataExists, httpRequest));
                    }
                    else
                    {
                        model.code = commonHelpers.GenerateRowID(_tableName);
                        model.codeCompany = tokenHelper.GetCompanyCode(httpRequest);
                        model.order_number = model.order_number == null ? 0 : model.order_number;
                        dataContext.SysPermissions.Add(model);
                        dataContext.SaveChanges();
                        return new StatusMessage<SysPermission>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                    }
                }

            }
            catch
            {
                return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
        }

        public StatusMessage<List<SysPermission>> Search(HttpRequest httpRequest, SysPermission model)
        {
            try
            {
                var result = dataContext.SysPermissions.Where(x => model.code == null || x.code == model.code).OrderBy(x => x.order_number).ToList();
                return new StatusMessage<List<SysPermission>>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<SysPermission>>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), new List<SysPermission>());
            }
        }

        public StatusMessage<SysPermission> Update(HttpRequest httpRequest, SysPermission model)
        {
            try
            {
                var result = dataContext.SysPermissions.Where(x => x.code == model.code).OrderBy(x => x.order_number).ToList();

                if (result.Count > 0)
                {


                    if (model.code == null)
                    {
                        return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), model);
                    }
                    else if (model.name == null)
                    {
                        return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DataNoName, httpRequest), model);
                    }
                    else if (model.level == null)
                    {
                        return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.DataNoLevel, httpRequest), model);
                    }
                    else
                    {
                        dataContext.RemoveRange(result);

                        model.codeCompany = tokenHelper.GetCompanyCode(httpRequest);
                        model.order_number = model.order_number == null ? 0 : model.order_number;
                        dataContext.SysPermissions.Add(model);
                        dataContext.SaveChanges();
                        return new StatusMessage<SysPermission>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                    }
                }
                else
                {
                    return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<SysPermission>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
