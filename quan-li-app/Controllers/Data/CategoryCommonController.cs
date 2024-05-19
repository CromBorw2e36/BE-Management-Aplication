using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_QUANLI.Models.DataDB;
using quan_li_app.Models;
using BUS_QUANLI.Services;
using quan_li_app.Helpers;
using quan_li_app.Models.Common;
using quan_li_app.Models.SystemDB;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
using BUS_QUANLI.Services.SystemCategory;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCommonController : ControllerBase
    {
        private readonly DataContext _context;
        public readonly CategoryCommonService categoryCommonService;
        public readonly CommonService commonService;
        public readonly SysPermissionService permissionService;
        public readonly SysStatusService statusService;
        public readonly SysTypeAccountService typeAccountService;
        public readonly NationalLanguageService nationalLanguageService;
        private readonly TokenHelper tokenHelper;

        public CategoryCommonController(DataContext context)
        {
            _context = context;
            categoryCommonService = new CategoryCommonService();
            tokenHelper = new TokenHelper();
            commonService = new CommonService();
            permissionService = new SysPermissionService();
            statusService = new SysStatusService();
            typeAccountService = new SysTypeAccountService();
            nationalLanguageService = new NationalLanguageService();
        }

        [HttpPost, Route("CategoryCommonSearch")]
        public async Task<ActionResult<StatusMessage<List<CategoryCommonModel>>>> CategoryCommonSearch(CategoryCommonModel model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<CategoryCommonModel>> res = this.categoryCommonService.Search(HttpContext.Request, model);
                this.categoryCommonService.LogTime<List<CategoryCommonModel>>(HttpContext.Request, "SEARCH", res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("CategoryCommonInsert")]
        public async Task<ActionResult<StatusMessage<CategoryCommonModel>>> CategoryCommonInsert(CategoryCommonModel model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<CategoryCommonModel> res = this.categoryCommonService.Insert(HttpContext.Request, model);
                this.categoryCommonService.LogTime<CategoryCommonModel>(HttpContext.Request, "INSERT", res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("CategoryCommonUpdate")]
        public async Task<ActionResult<StatusMessage<CategoryCommonModel>>> CategoryCommonUpdate(CategoryCommonModel model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<CategoryCommonModel> res = this.categoryCommonService.Update(HttpContext.Request, model);
                this.categoryCommonService.LogTime<CategoryCommonModel>(HttpContext.Request, "UPDATE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("CategoryCommonDelete")]
        public async Task<ActionResult<StatusMessage<CategoryCommonModel>>> CategoryCommonDelete(CategoryCommonModel model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<CategoryCommonModel> res = this.categoryCommonService.Delete(HttpContext.Request, model);
                this.categoryCommonService.LogTime<CategoryCommonModel>(HttpContext.Request, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPost, Route("NationalLanguageInsert")]
        public async Task<ActionResult<StatusMessage<National>>> NationalLanguageInsert(National model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<National> res = this.nationalLanguageService.Insert(HttpContext.Request, model);
                //this.commonService.LogTime<National>(HttpContext.Request, "INSERT", res);
                this.commonService.LogTime<National>(HttpContext.Request, this.nationalLanguageService._tableName, "INSERT", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("NationalLanguageUpdate")]
        public async Task<ActionResult<StatusMessage<National>>> NationalLanguageUpdate(National model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<National> res = this.nationalLanguageService.Update(HttpContext.Request, model);
                //this.commonService.LogTime<National>(HttpContext.Request, "INSERT", res);
                this.commonService.LogTime<National>(HttpContext.Request, this.nationalLanguageService._tableName, "UPDATE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("NationalLanguageDelete")]
        public async Task<ActionResult<StatusMessage<National>>> NationalLanguageDelete(National model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<National> res = this.nationalLanguageService.Delete(HttpContext.Request, model);
                //this.commonService.LogTime<National>(HttpContext.Request, "INSERT", res);
                this.commonService.LogTime<National>(HttpContext.Request, this.nationalLanguageService._tableName, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("NationalLanguageSearch")]
        public async Task<ActionResult<StatusMessage<List<National>>>> NationalLanguageSearch(National model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<National>> res = this.nationalLanguageService.Search(HttpContext.Request, model);
                this.commonService.LogTime<List<National>>(HttpContext.Request, this.nationalLanguageService._tableName, "SEARCH", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPost, Route("SysPermissionInsert")]
        public async Task<ActionResult<StatusMessage<SysPermission>>> SysPermissionInsert(SysPermission model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysPermission> res = this.permissionService.Insert(HttpContext.Request, model);
                //this.commonService.LogTime<National>(HttpContext.Request, "INSERT", res);
                this.commonService.LogTime<SysPermission>(HttpContext.Request, this.permissionService._tableName, "INSERT", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysPermissionUpdate")]
        public async Task<ActionResult<StatusMessage<SysPermission>>> SysPermissionUpdate(SysPermission model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysPermission> res = this.permissionService.Update(HttpContext.Request, model);
                 this.commonService.LogTime<SysPermission>(HttpContext.Request, this.permissionService._tableName, "UPDATE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysPermissionDelete")]
        public async Task<ActionResult<StatusMessage<SysPermission>>> SysPermissionDelete(SysPermission model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysPermission> res = this.permissionService.Delete(HttpContext.Request, model);
                 this.commonService.LogTime<SysPermission>(HttpContext.Request, this.permissionService._tableName, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysPermissionSearch")]
        public async Task<ActionResult<StatusMessage<List<SysPermission>>>> SysPermissionSearch(SysPermission model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<SysPermission>> res = this.permissionService.Search(HttpContext.Request, model);
                this.commonService.LogTime<List<SysPermission>>(HttpContext.Request, this.permissionService._tableName, "SEARCH", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysStatusInsert")]
        public async Task<ActionResult<StatusMessage<SysStatus>>> SysStatusInsert(SysStatus model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysStatus> res = this.statusService.Insert(HttpContext.Request, model);
                this.commonService.LogTime<SysStatus>(HttpContext.Request, this.statusService._tableName, "INSERT", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysStatusUpdate")]
        public async Task<ActionResult<StatusMessage<SysStatus>>> SysStatusUpdate(SysStatus model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysStatus> res = this.statusService.Update(HttpContext.Request, model);
                this.commonService.LogTime<SysStatus>(HttpContext.Request, this.statusService._tableName, "UPDATE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysStatusDelete")]
        public async Task<ActionResult<StatusMessage<SysStatus>>> SysStatusDelete(SysStatus model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysStatus> res = this.statusService.Delete(HttpContext.Request, model);
                this.commonService.LogTime<SysStatus>(HttpContext.Request, this.statusService._tableName, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysStatusSearch")]
        public async Task<ActionResult<StatusMessage<List<SysStatus>>>> SysStatusSearch(SysStatus model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<SysStatus>> res = this.statusService.Search(HttpContext.Request, model);
                this.commonService.LogTime<List<SysStatus>>(HttpContext.Request, this.statusService._tableName, "SEARCH", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysTypeAccountInsert")]
        public async Task<ActionResult<StatusMessage<SysTypeAccount>>> SysTypeAccountInsert(SysTypeAccount model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysTypeAccount> res = this.typeAccountService.Insert(HttpContext.Request, model);
                this.commonService.LogTime<SysTypeAccount>(HttpContext.Request, this.typeAccountService._tableName, "INSERT", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysTypeAccountUpdate")]
        public async Task<ActionResult<StatusMessage<SysTypeAccount>>> SysTypeAccountUpdate(SysTypeAccount model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysTypeAccount> res = this.typeAccountService.Update(HttpContext.Request, model);
                this.commonService.LogTime<SysTypeAccount>(HttpContext.Request, this.typeAccountService._tableName, "UPDATE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysTypeAccountDelete")]
        public async Task<ActionResult<StatusMessage<SysTypeAccount>>> SysTypeAccountDelete(SysTypeAccount model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<SysTypeAccount> res = this.typeAccountService.Delete(HttpContext.Request, model);
                this.commonService.LogTime<SysTypeAccount>(HttpContext.Request, this.typeAccountService._tableName, "DELETE", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("SysTypeAccountSearch")]
        public async Task<ActionResult<StatusMessage<List<SysTypeAccount>>>> SysTypeAccountSearch(SysTypeAccount model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<SysTypeAccount>> res = this.typeAccountService.Search(HttpContext.Request, model);
                this.commonService.LogTime<List<SysTypeAccount>>(HttpContext.Request, this.typeAccountService._tableName, "SEARCH", res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }



        [HttpPost, Route("TestDynamicData")]
        public async Task<ActionResult<object>> TestDynamicData(object model)
        {
            JObject obj = JObject.Parse(model.ToString());

            var id = obj["id"]; // check null

            object a = new
            {
                id = id != null ? id.ToString() : null,
            };

            return a;
        }
    }
}
