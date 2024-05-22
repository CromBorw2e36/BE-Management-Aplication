using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.SystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services
{
    public class SysMenuService : rootCommonService, ISysMenuService
    {

        private string _table_name = "SysMenu";

        public StatusMessage<dynamic> Delete(HttpRequest httpRequest, SysMenu model)
        {
            try
            {
                if (model.menuid == null)
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));

                var result = systemContext.SysMenus.Where(x => x.menuid == model.menuid).FirstOrDefault();
                if (result != null)
                {
                    this.systemContext.SysMenus.Remove(result);
                    this.systemContext.SaveChanges();
                    return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest));
                }
                else
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest));
            }
        }

        public StatusMessage<SysMenu> Insert(HttpRequest httpRequest, SysMenu model)
        {
            try
            {
                if (model.menuid == null)
                    return new StatusMessage<SysMenu>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.VoucherFormNotCode, httpRequest));

                var result = systemContext.SysMenus.Where(x => x.menuid == model.menuid).FirstOrDefault();
                if (result == null)
                {
                    this.systemContext.SysMenus.Add(model);
                    this.systemContext.SaveChanges();
                    return new StatusMessage<SysMenu>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                }
                else
                {
                    return new StatusMessage<SysMenu>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DataExists, httpRequest));
                }
                
            }
            catch
            {
                return new StatusMessage<SysMenu>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
        }

        public void LogTime<T>(HttpRequest httpRequest, string action, StatusMessage<T> message)
        {
            logTimeDataUpdateService.Insert(httpRequest, new LogTimeDataUpdateModel
            {
                table_name = _table_name,
                action_name = action,
                status = message.status == 0 ? "SUCCESED" : "ERRORED",
                notes = message.msg,
            });
        }

        public StatusMessage<List<SysMenu>> Search(HttpRequest httpRequest, SysMenu model)
        {
            try
            {
                List<SysMenu> result = new List<SysMenu>();

               if(model.menuid != null && model.menuid.Length > 0)
                {
                    result = systemContext.SysMenus.Where(x => x.menuid == model.menuid ).OrderBy(x => x.menuid).ToList();
                }
                else {
                    result = systemContext.SysMenus.OrderBy(x => x.menuid).ToList();
                }
                return new StatusMessage<List<SysMenu>>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<SysMenu>>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<object>());
            }
        }

        public StatusMessage<SysMenu> Update(HttpRequest httpRequest, SysMenu model)
        {
            try
            {
                if (model.menuid == null)
                    return new StatusMessage<SysMenu>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));

                var result = systemContext.SysMenus.Where(x => x.menuid == model.menuid).FirstOrDefault();
                if (result != null)
                {
                    this.systemContext.SysMenus.Remove(result);
                    this.systemContext.SysMenus.Add(model);
                    this.systemContext.SaveChanges();
                    return new StatusMessage<SysMenu>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest));
                }
                else
                {
                    return new StatusMessage<SysMenu>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<SysMenu>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
            }
        }
    }
}
