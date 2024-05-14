using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_QUANLI.Models.SystemDB;
using quan_li_app.Models;
using quan_li_app.Helpers;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using BUS_QUANLI.Services;
using quan_li_app.Models.Common;
using DAL_QUANLI.Models.DataDB;

namespace quan_li_app.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysGenRowTablesController : ControllerBase
    {
        private readonly SystemContext _context;
        private readonly TokenHelper tokenHelper;
        private readonly SysGenRowTableService sysGenRowTableService;

        public SysGenRowTablesController(SystemContext context)
        {
            _context = context;
            tokenHelper = new TokenHelper();
            sysGenRowTableService = new SysGenRowTableService();
        }


        [HttpPost, Route("Gen_Row_Table_Insert")]
        public async Task<ActionResult<StatusMessage<SysGenRowTable>>> GenRowTableInsert(SysGenRowTable sysGenRowTable)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysGenRowTable> res = this.sysGenRowTableService.Insert(HttpContext.Request, sysGenRowTable);
                this.sysGenRowTableService.LogTime<SysGenRowTable>(HttpContext.Request, "INSERT", res );
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Gen_Row_Table_Update")]
        public async Task<ActionResult<StatusMessage<SysGenRowTable>>> GenRowTableUpdate(SysGenRowTable sysGenRowTable)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysGenRowTable> res = this.sysGenRowTableService.Update(HttpContext.Request, sysGenRowTable);
                this.sysGenRowTableService.LogTime<SysGenRowTable>(HttpContext.Request, "UPDATE", res );
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Gen_Row_Table_Delete")]
        public async Task<ActionResult<StatusMessage<SysGenRowTable>>> GenRowTableDelete(SysGenRowTable sysGenRowTable)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysGenRowTable> res = this.sysGenRowTableService.Delete(HttpContext.Request, sysGenRowTable);
                this.sysGenRowTableService.LogTime<SysGenRowTable>(HttpContext.Request, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Gen_Row_Table_Search")]
        public async Task<ActionResult<StatusMessage<List<SysGenRowTable>>>> GenRowTableSearch(SysGenRowTable sysGenRowTable)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<SysGenRowTable>> res = this.sysGenRowTableService.Search(HttpContext.Request, sysGenRowTable);
                this.sysGenRowTableService.LogTime<List<SysGenRowTable>>(HttpContext.Request, "SEARCH", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
