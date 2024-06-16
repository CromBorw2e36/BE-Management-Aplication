using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS_QUANLI.Services.MasterData;
using BUS_QUANLI.Services.MasterData.AccountAndPermission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.ViewModels.Data;
using quan_li_app.Models.Common;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly TokenHelper tokenHelper;
        private readonly StatusMessageMapper statusMessageMapper;
        private readonly CompanyService companySerivce;
        private readonly List<string> actions = ["INSERT", "UPDATE", "DELETE", "GET", "SEARCH"];


        public CompanyController()
        {
            commonService = new CommonService();
            tokenHelper = new TokenHelper();
            statusMessageMapper = new StatusMessageMapper();
            companySerivce = new CompanyService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<Company>>> Insert(Company model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(this.Request))
            {
                var result = this.companySerivce.Insert(this.Request, model);
                this.commonService.LogTime<Company>(this.Request, this.companySerivce._tableName, this.actions[0], result);
                return result;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult<StatusMessage<Company>>> Update(Company model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(this.Request))
            {
                var result = this.companySerivce.Update(this.Request, model);
                this.commonService.LogTime<Company>(this.Request, this.companySerivce._tableName, this.actions[1], result);
                return result;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<Company>>> Delete(Company model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(this.Request))
            {
                var result = this.companySerivce.Delete(this.Request, model);
                this.commonService.LogTime<Company>(this.Request, this.companySerivce._tableName, this.actions[2], result);
                return result;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<Company>>>> Search(Company model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(this.Request))
            {
                var result = this.companySerivce.Search(this.Request, model);
                this.commonService.LogTime<List<Company>>(this.Request, this.companySerivce._tableName, this.actions[4], result);
                return result;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
