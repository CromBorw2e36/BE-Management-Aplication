using BUS_QUANLI.Services;
using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quan_li_app.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class sysActionController : ControllerBase
    {
        private readonly SystemContext systemContext;
        private readonly CommonHelpers commonHelpers;
        //private readonly ViewModelAccount viewModelAccount;
        private readonly TokenHelper tokenHelper;
        private readonly StatusMessageMapper statusMessageMapper;
        private readonly SysActionService sysActionService;

        public sysActionController()
        {
            this.systemContext = new SystemContext();
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();
            this.sysActionService = new SysActionService();
        }

        [HttpPost, Route("SysActionIns")]
        public async Task<ActionResult<StatusMessage>> SysActionIns(SysAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage res = await this.sysActionService.insert(action);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysActionUpd")]
        public async Task<ActionResult<StatusMessage>> SysActionUpd(SysAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage res = await this.sysActionService.update(action);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysActionDel")]
        public async Task<ActionResult<StatusMessage>> SysActionDel(SysAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage res = await this.sysActionService.delete(action);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysActionGetByCode")]
        public async Task<ActionResult<SysAction>> SysActionGetByCode(string code)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                SysAction res = await this.sysActionService.getByCode(code);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}
