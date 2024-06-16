using BUS_QUANLI.Helpers;
using DAL_QUANLI.Interface.MasterData;
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

namespace BUS_QUANLI.Services.MasterData
{
    public class MenuPermissionService : rootCommonService, IMenuPermissionService
    {

        public readonly string _table_name = "MenuPermissions";
        public StatusMessage<List<string>> GetMyMenuUrl(HttpRequest httpRequest)
        {
            try
            {
                string account = tokenHelper.GetUsername(httpRequest);
                string company_code = tokenHelper.GetCompanyCode(httpRequest);
                var result = dataContext.MenuPermissions.Where(x => x.companyCode == company_code && x.account == account)
                  .LeftJoin(systemContext.SysMenus, x => x.menuid, y => y.menuid, (x, y) => new { menuPermission = x, menu = y })
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
                string account = tokenHelper.GetUsername(httpRequest);
                string company_code = tokenHelper.GetCompanyCode(httpRequest);
                var result = systemContext.SysMenus
                    .LeftJoin(
                                dataContext.MenuPermissions
                                    .Where(x => x.account == account
                                        && x.companyCode == company_code),
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

        public StatusMessage<List<SysMenu>> GetPermission2(HttpRequest httpRequest, Account model)
        {
            try
            {


                var sysMenus = systemContext.SysMenus.Where(x => x.active == true).ToList();

                var menuPermissions = dataContext.MenuPermissions
                       .Where(mp => mp.account == model.account
                                 && mp.companyCode == model.companyCode)
                       .ToList();

                var result = sysMenus
                    .GroupJoin(menuPermissions,
                               sm => sm.menuid,
                               mp => mp.menuid,
                               (sm, mp) => new { sysMenu = sm, menuPermissions = mp.DefaultIfEmpty() })
                    .SelectMany(sm => sm.menuPermissions.DefaultIfEmpty(),
                                (sm, mp) => new { sm.sysMenu, menuPermission = mp })
                    .Where(x => x.menuPermission == null)
                    .Select(x => x.sysMenu)
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
                if (model.account.account == null)
                {
                    return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new MenuPermissionInsModel());
                }
                else
                {
                    var list_permission_of_user = dataContext.MenuPermissions
                        .Where(x => x.account == model.account.account
                        && x.companyCode == model.account.companyCode)
                        .ToList();
                    if (list_permission_of_user.Count > 0)
                    {
                        dataContext.MenuPermissions.RemoveRange(list_permission_of_user);
                    }

                    for (int i = 0; i < model.list_permission.Count; i++)
                    {
                        model.list_permission[i].account = model.account.account;
                        model.list_permission[i].companyCode = model.account.companyCode;
                        model.list_permission[i].date = DateTime.Now;
                        model.list_permission[i].id = commonHelpers.GenerateRowID(_table_name);
                        dataContext.MenuPermissions.Add(model.list_permission[i]);
                        dataContext.SaveChanges();
                    }

                    if (model.list_permission.Count == 0)
                    {
                        dataContext.SaveChanges();
                    }

                    //this.dataContext.MenuPermissions.AddRange(model.list_permission);
                    //this.dataContext.SaveChanges();

                    return new StatusMessage<MenuPermissionInsModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), new MenuPermissionInsModel());
            }
        }

        public List<Sys_Menu_Tree_View_MODEL> List_Menu_Bind_Tree_View(Account account)
        {
            string username = account.account!;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@account", username != null ? username : DBNull.Value));
            parameters.Add(new SqlParameter("@menuID", DBNull.Value));

            List<Sys_Menu_Tree_View_MODEL> result = dataContext.Database.SqlQueryRaw<Sys_Menu_Tree_View_MODEL>(
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
            }
            else if (menu.menuid is null)
            {
                return new List<Sys_Menu_Tree_View_MODEL>();
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@account", menu.account != null ? menu.account : DBNull.Value));
                parameters.Add(new SqlParameter("@menuID", menu.menuid != null ? menu.menuid : DBNull.Value));

                List<Sys_Menu_Tree_View_MODEL> result = dataContext.Database.SqlQueryRaw<Sys_Menu_Tree_View_MODEL>(
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
                //if (model.account.account == null || model.account.companyCode == null)
                if (model.account.account == null)
                    {
                    return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new MenuPermissionInsModel());
                }
                else
                {
                    //var list_permission_of_user = dataContext.MenuPermissions
                    //    .Join(systemContext.SysMenus, a => a.menuid, b => b.menuid, (a, b) => new { menuPermission = a, menu = b })
                    //    .Where(x => x.menuPermission.account == model.account.account
                    //    && x.menuPermission.companyCode == model.account.companyCode)
                    //    .Select(x => x.menu)
                    //    .ToList();

                    // Tải dữ liệu từ dataContext vào bộ nhớ
                    var menuPermissions = dataContext.MenuPermissions
                        .Where(mp => mp.account == model.account.account
                                  && mp.companyCode == model.account.companyCode)
                        .ToList();

                    // Tải dữ liệu từ systemContext vào bộ nhớ
                    var sysMenus = systemContext.SysMenus
                        .ToList();

                    // Thực hiện join trong bộ nhớ
                    var list_permission_of_user = menuPermissions
                        .Join(sysMenus, mp => mp.menuid, sm => sm.menuid, (mp, sm) => sm)
                        .ToList();

                    var account = dataContext.Accounts.FirstOrDefault(x => x.account == model.account.account && x.companyCode == model.account.companyCode);

                    if (account == null)
                    {
                        return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                    }

                    model.account = account;
                    model.list_menu = list_permission_of_user;

                    return new StatusMessage<MenuPermissionInsModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<MenuPermissionInsModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new MenuPermissionInsModel());
            }
        }

        public StatusMessage<MenuPermissionInsModel> Update(HttpRequest httpRequest, MenuPermissionInsModel model)
        {
            return Insert(httpRequest, model);
        }
    }
}
