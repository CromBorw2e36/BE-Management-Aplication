using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;

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


        [HttpPost("UploadFileVersion11")]
        public async Task<ActionResult<StatusMessage<List<UploadFileModel>>>> UploadFileVersion11(UploadFileModel model)
        {
            var res = await this.uploadFileService.Insert(HttpContext.Request, model);
            return res;
        }

    }
}
