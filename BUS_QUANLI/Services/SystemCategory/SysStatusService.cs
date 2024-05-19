using DAL_QUANLI.Interface;
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
    public class SysStatusService : rootCommonService, ISysStatus
    {
        public string _tableName = "SysStatus";
        public StatusMessage<SysStatus> Delete(HttpRequest httpRequest, SysStatus model)
        {
            try
            {
                var result = dataContext.SysStatus.Where(x => x.id == model.id).ToList();
                if (result.Count == 0)
                {
                    return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }

                dataContext.SysStatus.RemoveRange(result);
                dataContext.SaveChanges();
                return new StatusMessage<SysStatus>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<SysStatus> Insert(HttpRequest httpRequest, SysStatus model)
        {
            try
            {
                model.id = commonHelpers.GenerateRowID(_tableName);

                if (model.module == null || model.module.Length == 0)
                {
                    return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }
                if(model.appModule == null || model.appModule.Length == 0)
                {
                    return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }
                
                if (model.code == null || model.code.Length == 0)
                {
                    model.code = model.id;
                }
                
                if(model.order_numer == null)
                {
                    model.order_numer = 0;
                }

                if(model.enable == null)
                {
                    model.enable = false;
                }

                dataContext.SysStatus.Add(model);
                dataContext.SaveChanges();
                return new StatusMessage<SysStatus>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public StatusMessage<List<SysStatus>> Search(HttpRequest httpRequest, SysStatus model)
        {
            try
            {
                var result = dataContext.SysStatus.Where(x => (model.id == null || x.id == model.id)).ToList();
                return new StatusMessage<List<SysStatus>>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<SysStatus>>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), new List<SysStatus>());
            }
        }

        public StatusMessage<SysStatus> Update(HttpRequest httpRequest, SysStatus model)
        {
            try
            {
                var result = dataContext.SysStatus.Where(x => x.id == model.id).ToList();
                if(result.Count == 0)
                {
                    return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }

                if (model.module == null || model.module.Length == 0)
                {
                    return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }
                if (model.appModule == null || model.appModule.Length == 0)
                {
                    return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
                }

                if (model.code == null || model.code.Length == 0)
                {
                    model.code = model.id;
                }

                if (model.order_numer == null)
                {
                    model.order_numer = 0;
                }

                if (model.enable == null)
                {
                    model.enable = false;
                }

                dataContext.SysStatus.RemoveRange(result);
                dataContext.SysStatus.Add(model);
                dataContext.SaveChanges();
                return new StatusMessage<SysStatus>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<SysStatus>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
