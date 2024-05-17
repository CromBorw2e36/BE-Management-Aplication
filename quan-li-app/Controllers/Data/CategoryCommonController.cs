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

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCommonController : ControllerBase
    {
        private readonly DataContext _context;
        public readonly CategoryCommonService categoryCommonService;
        private readonly TokenHelper tokenHelper;

        public CategoryCommonController(DataContext context)
        {
            _context = context;
            categoryCommonService = new CategoryCommonService();
            tokenHelper = new TokenHelper();

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
    }
}
