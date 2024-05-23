using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.SystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public  interface IMenuPermissionService
    {
        public StatusMessage<MenuPermissionInsModel> Insert(HttpRequest httpRequest, MenuPermissionInsModel model);
        public StatusMessage<MenuPermissionInsModel> Update(HttpRequest httpRequest, MenuPermissionInsModel model);
        public StatusMessage<MenuPermissionInsModel> Search(HttpRequest httpRequest, MenuPermissionInsModel model);
        public StatusMessage<List<SysMenu>> GetPermission(HttpRequest httpRequest);   // List menu permission user haven't yet permission
        public StatusMessage<List<SysMenu>> GetPermission2(HttpRequest httpRequest, Account model);   // List menu permission user haven't yet permission
        public StatusMessage<List<string>> GetMyMenuUrl(HttpRequest httpRequest);   
    }
}
