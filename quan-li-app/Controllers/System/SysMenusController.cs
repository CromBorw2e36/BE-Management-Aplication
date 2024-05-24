using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS_QUANLI.Services.MasterData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.SystemDB;

namespace quan_li_app.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysMenusController : ControllerBase
    {
        private readonly SystemContext _context;
        public readonly SysMenuService sysMenuService;
        private readonly TokenHelper tokenHelper;

        public SysMenusController(SystemContext context)
        {
            _context = context;
            tokenHelper = new TokenHelper();
            sysMenuService = new SysMenuService();
        }

        [HttpPost, Route("SysMenuSearch")]
        public async Task<ActionResult<StatusMessage<List<SysMenu>>>> SysMenuSearch(SysMenu model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<SysMenu>> res = this.sysMenuService.Search(HttpContext.Request, model);
                this.sysMenuService.LogTime<List<SysMenu>>(HttpContext.Request, "SEARCH", res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysMenuInsert")]
        public async Task<ActionResult<StatusMessage<SysMenu>>> SysMenuInsert(SysMenu model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysMenu> res = this.sysMenuService.Insert(HttpContext.Request, model);
                this.sysMenuService.LogTime<SysMenu>(HttpContext.Request, "INSERT", res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysMenuUpdate")]
        public async Task<ActionResult<StatusMessage<SysMenu>>> SysMenuUpdate(SysMenu model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysMenu> res = this.sysMenuService.Update(HttpContext.Request, model);
                this.sysMenuService.LogTime<SysMenu>(HttpContext.Request, "UPDATE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysMenuDelete")]
        public async Task<ActionResult<StatusMessage<dynamic>>> SysMenuDelete(SysMenu model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = this.sysMenuService.Delete(HttpContext.Request, model);
                this.sysMenuService.LogTime<dynamic>(HttpContext.Request, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
