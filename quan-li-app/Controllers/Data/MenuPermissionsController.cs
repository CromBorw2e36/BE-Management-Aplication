using BUS_QUANLI.Services;
using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.SystemDB;
using quan_li_app.ViewModels.Data;
using System.Net;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuPermissionsController : ControllerBase
    {
        private readonly DataContext _contextData;
        private readonly SystemContext _contextSys;
        private readonly ViewModelAccount viewModelAccount;
        private readonly BaseMapper baseMapper;
        private readonly MenuPermissionService menuPermissionService;
        private readonly CommonService commonService;

        public MenuPermissionsController(DataContext context, SystemContext context1)
        {
            _contextData = context;
            _contextSys = context1;
            viewModelAccount = new ViewModelAccount();
            this.baseMapper = new BaseMapper();
            menuPermissionService = new MenuPermissionService();
            commonService = new CommonService();
        }

        [HttpPost("list_menu_get")]
        public async Task<ActionResult<List<SysMenu>>> GetListMenu()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string account = tokenHelper.GetUsername(HttpContext.Request);

                List<MenuPermissions> menuPermissions = await _contextData.MenuPermissions.Where(x => x.account!.Equals(account)).ToListAsync<MenuPermissions>();
                List<SysMenu> sysMenus = new List<SysMenu>();

                if (menuPermissions.Count > 0)
                {
                    foreach (var item in menuPermissions)
                    {
                        SysMenu getMenu = _contextSys.SysMenus.FirstOrDefault(x => x.menuid!.Equals(item.menuid) && x.active == true)!;
                        if (getMenu != null)
                        {
                            sysMenus.Add(getMenu);
                        }
                    }
                }

                return sysMenus;
            }
            return Unauthorized();
        }


        [HttpPost("sys_menu_get")]
        public async Task<ActionResult<List<SysMenu>>> GetListMenuV2()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string account = tokenHelper.GetUsername(HttpContext.Request);
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@account", account != null ? account : DBNull.Value));

                List<SysMenu> result = this._contextData.Database.SqlQueryRaw<SysMenu>(
                "EXEC SYS_MENU_GET @account", parameters.ToArray()
                ).ToList();

                return result;
            }
            return Unauthorized();

        }

        [HttpPost("list_menu_tree_view")]
        public async Task<ActionResult<List<Sys_Menu_Tree_View_MODEL>>> ListMenuTreeView()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string username = tokenHelper.GetUsername(HttpContext.Request);

                Account account = new Account()
                {
                    account = username,
                };

                List<Sys_Menu_Tree_View_MODEL> list_menu_tree_view = this.menuPermissionService.List_Menu_Bind_Tree_View(account);

                return list_menu_tree_view;
            }
            return Unauthorized();

        }

        [HttpPost("list_menu_by_id")]
        public async Task<ActionResult<List<Sys_Menu_Tree_View_MODEL>>> ListMenuById(Sys_Menu_Tree_View_MODEL p)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string account = tokenHelper.GetUsername(HttpContext.Request);
                p.account = account;
                List<Sys_Menu_Tree_View_MODEL> list_menu_tree_view = this.menuPermissionService.List_menu_By_Id(p);

                return list_menu_tree_view;
            }
            return Unauthorized();

        }

        [HttpPost("list_menu_get_all")]
        public ActionResult<SysMenu> GetAllListMenu()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string account = tokenHelper.GetUsername(HttpContext.Request);
                // Thông tin của tài khoản
                Account acc = viewModelAccount.GetAccountByUsername(account);
                if (acc != null)
                {
                    switch (acc.companyCode)
                    {
                        case "ADMIN":
                            List<SysMenu> lst = _contextSys.SysMenus.ToList();
                            return lst.Count > 0 ? Ok(lst) : BadRequest();
                        default:
                            List<SysMenu> lst1 = _contextSys.SysMenus.ToList();
                            return lst1.Count > 0 ? Ok(lst1) : BadRequest();
                    }
                }
            }
            return BadRequest();
        }



        [HttpPost("GetMenuPermissions")]
        public async Task<ActionResult<StatusMessage<List<SysMenu>>>> GetMenuPermissions(string account)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.menuPermissionService.GetPermission(HttpContext.Request);
                return res;
            }
            return Unauthorized();
        }



        [HttpPost("RoleMenuSearch")]
        public async Task<ActionResult<StatusMessage<MenuPermissionInsModel>>> RoleMenuSearch(MenuPermissionInsModel model)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.menuPermissionService.Search(HttpContext.Request, model);
                this.commonService.LogTime<MenuPermissionInsModel>(HttpContext.Request, "SysPermission", "SEARCH", res);
                return res;
            }
            return Unauthorized();
        }

        [HttpPost("RoleMenuInsert")]
        public async Task<ActionResult<StatusMessage<MenuPermissionInsModel>>> RoleMenuInsert(MenuPermissionInsModel model)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.menuPermissionService.Insert(HttpContext.Request, model);
                this.commonService.LogTime<MenuPermissionInsModel>(HttpContext.Request, "SysPermission", "INSERT", res);
                return res;
            }
            return Unauthorized();
        }


        [HttpPost("RoleMenuUpdate")]
        public async Task<ActionResult<StatusMessage<MenuPermissionInsModel>>> RoleMenuUpdate(MenuPermissionInsModel model)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.menuPermissionService.Insert(HttpContext.Request, model);
                this.commonService.LogTime<MenuPermissionInsModel>(HttpContext.Request, "SysPermission", "UPDATE", res);
                return res;
            }
            return Unauthorized();
        }

        [HttpPost("RoleMenuOfUserLogin")]
        public async Task<ActionResult<StatusMessage<List<string>>>> RoleMenuOfUserLogin()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.menuPermissionService.GetMyMenuUrl(HttpContext.Request);
                return res;
            }
            return Unauthorized();
        }


        [HttpPost("RoleMenuPermissionByUserNotYet")]
        public async Task<ActionResult<StatusMessage<List<SysMenu>>>> RoleMenuPermissionByUserNotYet(Account model)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.menuPermissionService.GetPermission2(HttpContext.Request, model);
                return res;
            }
            return Unauthorized();
        }

        private bool MenuPermissionsExists(string id)
        {
            return _contextData.MenuPermissions.Any(e => e.id == id);
        }
    }
}
