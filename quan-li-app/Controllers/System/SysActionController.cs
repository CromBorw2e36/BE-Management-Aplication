using BUS_QUANLI.Services;
using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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
        private readonly SysDropDownActionService sysDropDownActionService;
        private readonly SysGroupActionService sysGroupActionService;

        public sysActionController()
        {
            this.systemContext = new SystemContext();
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();
            this.sysActionService = new SysActionService();
            this.sysDropDownActionService = new SysDropDownActionService();
            this.sysGroupActionService = new SysGroupActionService();
        }

        [HttpPost, Route("SysActionIns")]
        public async Task<ActionResult<StatusMessage<SysAction>>> SysActionIns(SysAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysAction> res = await this.sysActionService.SysActionInsert(action, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysActionUpd")]
        public async Task<ActionResult<StatusMessage<dynamic>>> SysActionUpd(SysAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = await this.sysActionService.SysActionUpadte(action, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysActionDel")]
        public async Task<ActionResult<StatusMessage<dynamic>>> SysActionDel(SysAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = await this.sysActionService.SysActionDelete(action, HttpContext.Request);
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
                SysAction res = await this.sysActionService.SysActionGetByCode(code);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysActionGetByCode2")]
        public async Task<ActionResult<List<SysAction>>> SysActionGetByCodeByPermision(string actionCode = "")
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                List<SysAction> res = await this.sysActionService.SysActiongetByCode(actionCode, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysDropDownActionIns")]
        public async Task<ActionResult<StatusMessage<SysDropDownAction>>> SysDropDownActionIns(SysDropDownAction dropdownAction)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = await this.sysDropDownActionService.SysDropDownActionIns(dropdownAction, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysDropdownActionUpd")]
        public async Task<ActionResult<StatusMessage<SysDropDownAction>>> SysDropdownActionUpd(SysDropDownAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysDropDownAction> res = await this.sysDropDownActionService.SysDropDownActionUpd(action, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysDropdownActionDel")]
        public async Task<ActionResult<StatusMessage<dynamic>>> SysDropdownActionDel(SysDropDownAction action)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = await this.sysDropDownActionService.SysDropDownActionDel(action, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysDropActionGetListSysActionByCode")]
        public async Task<ActionResult<List<SysAction>>> SysDropActionGetListSysActionByCode(SysDropDownAction dropdownAction)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                List<SysAction> res = await this.sysDropDownActionService.SysDropActionGetListSysActionByCode(dropdownAction, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysDropActionGet")]
        public async Task<ActionResult<SysDropDownAction>> SysDropdownActionGet(SysDropDownAction actionCode)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                List<SysDropDownAction> res = await this.sysDropDownActionService.SysDropActionGet(actionCode, HttpContext.Request);
                return res[0];
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("GetListActionByGroupCode")]
        public async Task<ActionResult<StatusMessage<List<SysAction>>>> GetListActionByGroupCode(SysGroupAction groupAction)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<SysAction>> res = this.sysGroupActionService.GetListActionByGroupCode(groupAction, HttpContext.Request);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
