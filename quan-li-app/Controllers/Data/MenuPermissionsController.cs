using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.SystemDB;
using quan_li_app.ViewModels.Data;

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

        public MenuPermissionsController(DataContext context, SystemContext context1)
        {
            _contextData = context;
            _contextSys = context1;
            viewModelAccount = new ViewModelAccount(context);
            this.baseMapper = new BaseMapper();
        }

        [HttpPost, ActionName("GetListMenu")]
        public async Task<ActionResult<List<SysMenu>>> GetListMenu()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string account = tokenHelper.GetUsername(HttpContext.Request);

                List<MenuPermissions> menuPermissions = await _contextData.MenuPermissions.Where(x => x.account.Equals(account)).ToListAsync<MenuPermissions>();
                List<SysMenu> sysMenus = new List<SysMenu>();

                if (menuPermissions.Count > 0)
                {
                    foreach (var item in menuPermissions)
                    {
                        SysMenu getMenu = await _contextSys.SysMenus.FirstOrDefaultAsync(x => x.menuid.Equals(item.menuid) && x.active == true);
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

        [HttpGet, ActionName("GetAllListMenus")]
        public async Task<ActionResult<SysMenu>> GetLstMenu()
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
        private bool MenuPermissionsExists(string id)
        {
            return _contextData.MenuPermissions.Any(e => e.id == id);
        }
    }
}
