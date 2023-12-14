using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.SystemDB;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuPermissionsController : ControllerBase
    {
        private readonly DataContext _contextData;
        private readonly SystemContext _contextSys;

        public MenuPermissionsController(DataContext context, SystemContext context1)
        {
            _contextData = context;
            _contextSys = context1;
        }

        [HttpPost, ActionName("GetListMenu")]
        //public async Task<ActionResult<List<SysMenu>>> GetByAccount(string TOKEN)
        public async Task<ActionResult<List<SysMenu>>> GetListMenu()
        {
            TokenHelper tokenHelper = new TokenHelper(_contextData);
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
            return BadRequest();
        }

        private bool MenuPermissionsExists(string id)
        {
            return _contextData.MenuPermissions.Any(e => e.id == id);
        }
    }
}
