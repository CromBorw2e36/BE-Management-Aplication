using BUS_QUANLI.Helpers;
using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.SystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services
{
    public class MenuPermissionService : rootCommonService, IMenuPermissionService
    {
        public StatusMessage<List<string>> GetMyMenuUrl(HttpRequest httpRequest)
        {
            try
            {
                string account = this.tokenHelper.GetUsername(httpRequest);
                string company_code = this.tokenHelper.GetCompanyCode(httpRequest);
                var result = this.dataContext.MenuPermissions.Where(x => x.companyCode == company_code && x.account == account)
                  .LeftJoin(systemContext.SysMenus, x => x.menuid , y => y.menuid, (x,y) => new { menuPermission= x, menu = y})
                  .Select(x => x.menu.url)
                  .ToList();
                return new StatusMessage<List<string>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result); 
            }
            catch
            {
                return new StatusMessage<List<string>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<string>());
            }
        }

        public StatusMessage<List<SysMenu>> GetPermission(HttpRequest httpRequest)
        {
            try
            {
                string account = this.tokenHelper.GetUsername(httpRequest);
                string company_code = this.tokenHelper.GetCompanyCode(httpRequest);
                var result = this.systemContext.SysMenus
                    .LeftJoin(
                                this.dataContext.MenuPermissions
                                    .Where(x => x.account == account 
                                        && x.companyCode == x.companyCode),
                                x => x.menuid,
                                y => y.menuid,
                                (x, y) => new { menu = x, menu_permission = y }
                              )
                    .Where(x => x.menu_permission == null)
                    .Select(x => x.menu)
                    .ToList();

                return new StatusMessage<List<SysMenu>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<SysMenu>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<MenuPermissions>());
            }
        }

        public StatusMessage<MenuPermissionInsModel> Insert(HttpRequest httpRequest, MenuPermissionInsModel model)
        {
            try
            {
                if(model.account.account == null || model.account.companyCode == null)
                {
                    return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(quan_li_app.Models.EnumQuanLi.NotFoundItem, httpRequest), new MenuPermissionInsModel());
                }
                else
                {
                    var list_permission_of_user = this.dataContext.MenuPermissions
                        .Where(x => x.account == model.account.account  
                        && x.companyCode == model.account.companyCode)
                        .ToList();
                    if(list_permission_of_user.Count > 0)
                    {
                        this.dataContext.MenuPermissions.RemoveRange(list_permission_of_user);
                        this.dataContext.SaveChanges();
                    }
                    for(int i = 0; i < model.list_permission.Count; i++)
                    {
                        model.list_permission[i].account = model.account.account;
                        model.list_permission[i].companyCode = model.account.companyCode;
                        model.list_permission[i].date = DateTime.Now;
                    }

                    return new StatusMessage<MenuPermissionInsModel>(0, GetMessageDescription(quan_li_app.Models.EnumQuanLi.Suceeded, httpRequest), model); 
                }
            }
            catch
            {
                return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(quan_li_app.Models.EnumQuanLi.InsertError, httpRequest), new MenuPermissionInsModel());
            }
        }

        public List<Sys_Menu_Tree_View_MODEL> List_Menu_Bind_Tree_View(Account account)
        {
            string username = account.account!;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@account", username != null ? username : DBNull.Value));
            parameters.Add(new SqlParameter("@menuID", DBNull.Value));

            List<Sys_Menu_Tree_View_MODEL> result = this.dataContext.Database.SqlQueryRaw<Sys_Menu_Tree_View_MODEL>(
            "EXEC SYS_MENU_GET @account, @menuID", parameters.ToArray()
            ).ToList();

            if (result.Count > 0)
            {
                List<Sys_Menu_Tree_View_MODEL> list_menu_tree_view = result.ToList();
                List<Sys_Menu_Tree_View_MODEL> list_menu_tree_view_root = result.Where(x => x.menuIDParent == null).ToList();

                for (int i = 0; i < list_menu_tree_view_root.Count; i++)
                {
                    Sys_Menu_Tree_View_MODEL item = list_menu_tree_view_root[i];
                    List<Sys_Menu_Tree_View_MODEL> list_menu_find = list_menu_tree_view.Where(x => x.menuIDParent == item?.menuid && x.menuIDParent != null).ToList();
                    if (list_menu_find.Count > 0)
                    {
                        list_menu_tree_view_root[i].items = list_menu_find;
                    }
                }

                return list_menu_tree_view_root;
            }
            return new List<Sys_Menu_Tree_View_MODEL>();
        }

        public List<Sys_Menu_Tree_View_MODEL> List_menu_By_Id(Sys_Menu_Tree_View_MODEL menu)
        {

            if (menu.account is null)
            {
                return new List<Sys_Menu_Tree_View_MODEL>();
            } else if(menu.menuid is null)
            {
                return new List<Sys_Menu_Tree_View_MODEL>();
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@account", menu.account != null ? menu.account : DBNull.Value));
                parameters.Add(new SqlParameter("@menuID", menu.menuid != null ? menu.menuid : DBNull.Value));

                List<Sys_Menu_Tree_View_MODEL> result = this.dataContext.Database.SqlQueryRaw<Sys_Menu_Tree_View_MODEL>(
                "EXEC SYS_MENU_GET @account, @menuID", parameters.ToArray()
                ).ToList();

                return result;
            }
            catch
            {
                return new List<Sys_Menu_Tree_View_MODEL>();
            }
        }

        public StatusMessage<MenuPermissionInsModel> Search(HttpRequest httpRequest, MenuPermissionInsModel model)
        {
            try
            {
                if (model.account.account == null || model.account.companyCode == null)
                {
                    return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(quan_li_app.Models.EnumQuanLi.NotFoundItem, httpRequest), new MenuPermissionInsModel());
                }
                else
                {
                    var list_permission_of_user = this.dataContext.MenuPermissions
                        .Where(x => x.account == model.account.account
                        && x.companyCode == this.tokenHelper.GetCompanyCode(httpRequest))
                        .ToList();

                    var account = this.dataContext.Accounts.FirstOrDefault(x => x.account == model.account.account && x.companyCode == model.account.companyCode);
                   
                    if(account == null || list_permission_of_user.Count == 0)
                    {
                        return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(quan_li_app.Models.EnumQuanLi.NotFoundItem, httpRequest), model);
                    }

                    model.account = account;
                    model.list_permission = list_permission_of_user;

                    return new StatusMessage<MenuPermissionInsModel>(0, GetMessageDescription(quan_li_app.Models.EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(quan_li_app.Models.EnumQuanLi.NotFoundItem, httpRequest), new MenuPermissionInsModel());
            }
        }

        public StatusMessage<MenuPermissionInsModel> Update(HttpRequest httpRequest, MenuPermissionInsModel model)
        {
            return this.Insert(httpRequest, model);
        }
    }
}
