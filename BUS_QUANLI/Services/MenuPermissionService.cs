using BUS_QUANLI.Helpers;
using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
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
    public class MenuPermissionService : rootCommonService
    {

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
    }
}
