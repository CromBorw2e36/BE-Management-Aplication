using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;
using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.DataDB;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using System.Reflection;
using System;
using DAL_QUANLI.Models.CustomModel;

namespace quan_li_app.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonContronller : ControllerBase
    {
        private DataContext _contextData;
        private SystemContext _contextSystem;
        private readonly TokenHelper _tokenHelper;
        private readonly BaseMapper baseMapper;
        private CommonService commonService;
        private UploadFileService uploadFileService;

        public CommonContronller(DataContext contextData, SystemContext contextSystem)
        {
            _contextData = contextData;
            _contextSystem = contextSystem;
            _tokenHelper = new TokenHelper();
            baseMapper = new BaseMapper();
            commonService = new CommonService();
            uploadFileService = new UploadFileService();
        }

        [HttpGet, ActionName("ListCompany")]
        public async Task<ActionResult<List<Company>>> ListCompany()
        {
            List<Company> lst = await _contextData.Companies.ToListAsync();
            return lst;
        }

        [HttpPost, Route("ListStatusByModule")]
        public async Task<ActionResult<List<SysStatus>>> GetStatusByModule(SysStatus pSysStatus)
        {
            List<SysStatus> res = await _contextData.SysStatus
                .Where(x => x.module!.Equals(pSysStatus.module) && x.enable == true)
                .OrderBy(x => x.order_numer)
                .ToListAsync();
            return res;
        }


        [HttpPost, Route("ListPermission")]
        public async Task<ActionResult<List<SysPermission>>> GetPermissionByCompany()
        {
            if (_tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string UsernameCredential = _tokenHelper.GetUsername(HttpContext.Request);
                Account account = _contextData.Accounts.Where(x => x.account!.Equals(UsernameCredential)).FirstOrDefault()!;
                if (account != null)
                {
                    List<SysPermission> res = await _contextData.SysPermissions
                                                .Where(x => x.codeCompany!.Equals(account.companyCode) || account.companyCode!.Equals(baseMapper.GetSysCompany()))
                                                .OrderBy(x => x.level)
                                                .ThenBy(x => x.order_number)
                                                .ToListAsync();
                    return res;
                }

                return NoContent();
            }
            return Unauthorized();
        }

        [HttpPost, Route("ExcuteQueryString")]
        public async Task<ActionResult<List<dynamic>>> ExcuteQueryString(QueryCommonModel model)
        {
            if (_tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var result = this.commonService.ExcuteStringQuery(model);
                return result;
            }
            return Unauthorized();
        }

        [HttpPost, Route("ExcuteQueryStringV2")]
        public async Task<ActionResult<StatusMessage<string>>> ExcuteQueryStringV2(QueryCommonModel model)
        {
            if (_tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var result = this.commonService.FilterListDataAnyTable(this.Request, model);
                return result;
            }
            return Unauthorized();
        }


        [HttpPost("UploadFileVersion11")]
        public async Task<ActionResult<StatusMessage<List<UploadFileModel>>>> UploadFileVersion11(UploadFileModel model)
        {
            var res = await this.uploadFileService.Insert(HttpContext.Request, model);
            return res;
        }


        [HttpPost("UploadFileVersion12")]
        public async Task<ActionResult<StatusMessage<List<UploadFileModel>>>> UploadFileVersion12()
        {
            //var files = HttpContext.Request.Form.Files;
            var formData = HttpContext.Request.Form;
            string table_name = formData["table_name"].ToString();
            string col_name = formData["col_name"].ToString();
            var files = formData.Files;

            var res = await this.uploadFileService.Insert12(HttpContext.Request, files.ToList(), table_name, col_name);
            return res;
        }


        [HttpGet("ViewFile")]
        public IActionResult ViewFile([FromQuery] string  fileID)
        {
            if (this._tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                try
                {

                    var fileResult = this.uploadFileService.GetFile(fileID);
                    var mimeType = "application/octet-stream"; // Adjust the MIME type if necessary
                    return File(fileResult.FileStream, mimeType, fileResult.FileDownloadName);
                }
                catch (FileNotFoundException)
                {
                    return NotFound("File not found.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("File/Search")]
        public async Task<ActionResult<StatusMessage<List<UploadFileModel>>>> FileSearch(UploadFileModel model)
        {
            if (this._tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                var res = this.uploadFileService.Search(HttpContext.Request, model);
                return new StatusMessage<List<UploadFileModel>> (0, "SUCCED", res);
            }
            else
            {
                return Unauthorized();
            }
        }

        // Truyền danh sách ID của File sau đó tiến hành tìm kiếm và trả về danh sách file
        [HttpPost("File/SearchV2")]
        public async Task<ActionResult<StatusMessage<List<UploadFileModel>>>> FileSearch(List<string> list_id)
        {
            if (this._tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                List<UploadFileModel> data = new List<UploadFileModel>();
                foreach (var item in list_id)
                {
                    var res = this.uploadFileService.Search(this.Request, new UploadFileModel() { id = item });
                    if(res.Count == 1)
                    {
                        data.Add(res[0]);
                    }
                }
                return new StatusMessage<List<UploadFileModel>> (0, "SUCCED", data);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
