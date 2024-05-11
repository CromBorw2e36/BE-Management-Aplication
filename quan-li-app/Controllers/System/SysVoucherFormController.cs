using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_QUANLI.Models.SystemDB.SysVoucherForm;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using BUS_QUANLI.Services;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Helpers;
using BUS_QUANLI.Services.VoucherForm;
using System.ComponentModel;

namespace quan_li_app.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysVoucherFormController : ControllerBase
    {
        private readonly SystemContext systemContext;
        //private readonly ViewModelAccount viewModelAccount;
        private readonly TokenHelper tokenHelper;
        private readonly VoucherFormColumnService voucherFormColumnService;
        private readonly VoucherFormGroupSerivce voucherFormGroupSerivce;

        public SysVoucherFormController(SystemContext context)
        {
            systemContext = context;
            tokenHelper = new TokenHelper();
            voucherFormColumnService = new VoucherFormColumnService();
            voucherFormGroupSerivce = new VoucherFormGroupSerivce();
        }

        [HttpPost, Route("Voucher_Form_Column_Insert")]
        public async Task<ActionResult<StatusMessage<SysVoucherFormColumn>>> VoucherFormColumnInsert(SysVoucherFormColumn sysVoucherFormColumn)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = await this.voucherFormColumnService.Insert(httpRequest, sysVoucherFormColumn);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Column_Update")]
        public async Task<ActionResult<StatusMessage<SysVoucherFormColumn>>> VoucherFormColumnUpdate(SysVoucherFormColumn sysVoucherFormColumn)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = await this.voucherFormColumnService.Update(httpRequest, sysVoucherFormColumn);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Column_Delete")]
        public async Task<ActionResult<StatusMessage<SysVoucherFormColumn>>> VoucherFormColumnDelete(SysVoucherFormColumn sysVoucherFormColumn)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = await this.voucherFormColumnService.Delete(httpRequest, sysVoucherFormColumn);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Column_Search")]
        public async Task<ActionResult<StatusMessage<List<SysVoucherFormColumn>>>> VoucherFormColumnSearch(SysVoucherFormColumn sysVoucherFormColumn)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = await this.voucherFormColumnService.Search(httpRequest, sysVoucherFormColumn);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Group_Insert")]
        public async Task<ActionResult<StatusMessage<SysVoucherFormGroup>>> VoucherFormGroupInsert(SysVoucherFormGroup sysVoucherFormGroup)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = this.voucherFormGroupSerivce.Insert(httpRequest, sysVoucherFormGroup);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Group_Update")]
        public async Task<ActionResult<StatusMessage<SysVoucherFormGroup>>> VoucherFormGroupUpdate(SysVoucherFormGroup sysVoucherFormGroup)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = this.voucherFormGroupSerivce.Update(httpRequest, sysVoucherFormGroup);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Group_Delete")]
        public async Task<ActionResult<StatusMessage<SysVoucherFormGroup>>> VoucherFormGroupDelete(SysVoucherFormGroup sysVoucherFormGroup)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = this.voucherFormGroupSerivce.Delete(httpRequest, sysVoucherFormGroup);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Voucher_Form_Group_Search")]
        public async Task<ActionResult<StatusMessage<List<SysVoucherFormGroup>>>> VoucherFormGroupSearch(SysVoucherFormGroup sysVoucherFormGroup)
        {
            HttpRequest httpRequest = HttpContext.Request;

            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(httpRequest))
            {
                var res = this.voucherFormGroupSerivce.Search(httpRequest, sysVoucherFormGroup);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
