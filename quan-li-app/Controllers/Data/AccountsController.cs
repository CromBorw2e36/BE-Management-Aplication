using BUS_QUANLI.Services;
using BUS_QUANLI.Services.AccountAndPermission;
using DAL_QUANLI.Models.CustomModel;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;
using quan_li_app.Services;
using quan_li_app.ViewModels.Data;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TokenHelper tokenHelper;
        private readonly ViewModelAccount _viewModelAccount;
        private readonly StatusMessageMapper statusMessageMapper;
        private readonly ViewModeUserInfo viewModeUserInfo;
        private readonly CommonHelpers commonHelpers;
        private readonly AccountService _accoutnClient;
        private readonly CommonService commonService;



        public AccountsController(DataContext context, SystemContext systemContext)
        {
            _context = context;
            this._viewModelAccount = new ViewModelAccount();
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();
            this.viewModeUserInfo = new ViewModeUserInfo(context, systemContext);
            this.commonHelpers = new CommonHelpers();
            this._accoutnClient = new AccountService();
            this.commonService = new CommonService();
        }

        [HttpPost, Route("CheckTheExpirationDateOfToken")]
        public ActionResult<bool> CheckTheExpirationDateOfToken()
        {
            try
            {
                if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
                {
                    return true;
                }
                return Unauthorized();
            }
            catch
            {
                return false;
            }
        }

        
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<StatusMessage<dynamic>>> Login(AccountClientLoginParamsModel account)
        {
            if (account.account == null)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHaveUserName));
                return message;
            }
            else if (account.password == null)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHavePassword, account.account));
                return message;
            }
            else
            {
                string EndcodePass = new PasswordEndCodeDecodeMD5().EndCodeMd5(account.password);
                Account acc = _context.Accounts.FirstOrDefault(e => e.account == account.account)!;

                if (acc == null)
                {
                    StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist, account.account));
                    return message;
                }
                else
                {
                    DateTime dateTimeNow = DateTime.Now;
                    DateTime lockDate = acc.lock_date ?? dateTimeNow;
                    if (acc.password == EndcodePass && lockDate <= dateTimeNow)
                    {
                        account.ip_address = HttpContext.Connection.RemoteIpAddress!.ToString(); ;
                        string newToken = await new TokenHelper().GenTokenLogin(account); // token
                        UserInfo user = _context.UserInfomation.FirstOrDefault(x => x.id == acc.account)!;

                        acc.last_enter = DateTime.Now;
                        acc.token = newToken;
                        _context.Accounts.Update(acc);
                        _context.SaveChanges();

                        StatusMessage<dynamic> message = new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.LoginSuccess, account.account), new
                        {
                            account = new Account
                            {
                                account = acc.account,
                                create_date = acc.create_date,
                                lock_date = acc.lock_date,
                                phone = acc.phone,
                                status = acc.status,
                                type_account = acc.type_account,
                                email = acc.email,
                                token = newToken,
                                language = acc.language
                            },
                            user = user,
                            //menuPermissions
                        });

                        return message;
                    }
                    else if (lockDate > dateTimeNow)
                    {
                        string additionalMsg = this.commonHelpers.DateCalculatingYearMonthDate(lockDate, dateTimeNow, _viewModelAccount.getLanguageByUserName(account.account));
                        StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountIsBlocked, account.account) + " " + additionalMsg);
                        return message;
                    }
                    else
                    {
                        StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InvalidPassword, account.account));
                        return message;
                    }

                }

            }
        }

        [HttpPost("AccountIns")]
        public async Task<ActionResult<StatusMessage<dynamic>>> AccountIns(AccountClientProfileModel profile)
        {
            string userName = this.tokenHelper.GetUsername(HttpContext.Request);
            StatusMessage<dynamic> msg = new StatusMessage<dynamic>();
            msg = await _accoutnClient.AccountClientIns(profile, userName);
            return msg;
        }

        [HttpPost("UpdateAccount")]
        public async Task<ActionResult<StatusMessage<dynamic>>> UpdateAccount(Account account)
        {
            string UsernameCredential = tokenHelper.GetUsername(HttpContext.Request);
            if (!AccountExists(account.account!))
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist, UsernameCredential));
                return message;
            }
            else
            {

                if (UsernameCredential.Equals(account.account)) //  Tự cập nhật thông tin các nhân
                {
                    bool resUpdate = await _viewModelAccount.UpdateAccountAsync(account);
                    string mess = statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, UsernameCredential);

                    if (resUpdate)
                    {
                        mess = statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, UsernameCredential);

                    }

                    StatusMessage<dynamic> message = new StatusMessage<dynamic>(resUpdate ? 1 : 0, mess);
                    return message;
                }
                else
                {
                    if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
                    {
                        Account accountRequest = _viewModelAccount.GetAccountByUsername(UsernameCredential);
                        Account accountUpdate = _viewModelAccount.GetAccountByUsername(account.account!);
                        if (accountRequest != null && accountUpdate != null)
                        {
                            // kiểm tra công ty, kiểm tra quyền
                            // Thông tin cũ của người dùng cần cập nhật

                            if (!accountRequest.companyCode!.Equals(accountUpdate.companyCode))
                            {
                                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountNotSameCompany, UsernameCredential));
                                return message;
                            }
                            else if (!(accountRequest.levelPermision > accountUpdate.levelPermision))
                            {
                                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, UsernameCredential));
                                return message;
                            }
                            else if (accountRequest.levelPermision > accountUpdate.levelPermision)
                            {
                                bool result = await _viewModelAccount.UpdateAccountAsync(account);

                                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0,
                                    result
                                    ? statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, UsernameCredential)
                                    : statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, UsernameCredential)
                                    );
                                return message;
                            }
                            else
                            {
                                return Unauthorized(statusMessageMapper.GetMessageDescription(EnumQuanLi.Unauthorized, UsernameCredential));
                            }
                        }
                    }
                    else
                    {
                        return Unauthorized(statusMessageMapper.GetMessageDescription(EnumQuanLi.Unauthorized, UsernameCredential));
                    }
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<StatusMessage<dynamic>> DeleteAccount(string id)
        {
            string UsernameCredential = tokenHelper.GetUsername(HttpContext.Request);
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                StatusMessage<dynamic> message2 = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist, UsernameCredential));
                return message2;
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            StatusMessage<dynamic> message = new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess, UsernameCredential));
            return message;
        }


        [HttpPost("AccountUpdate")]
        public async Task<ActionResult<StatusMessage<AccountClientProfileModel>>> AccountUpdate(AccountClientProfileModel model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<AccountClientProfileModel> res = this._accoutnClient.Update(HttpContext.Request, model);
                this.commonService.LogTime<AccountClientProfileModel>(HttpContext.Request, _accoutnClient._tablename, string.Format("UPDATE FOR ACCOUNT: {0}", model.account), res);
                this.commonService.LogTime<AccountClientProfileModel>(HttpContext.Request, _accoutnClient._tableName2, string.Format("UPDATE FOR ACCOUNT: {0}", model.account), res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPost("AccountSearch")]
        public async Task<ActionResult<StatusMessage<AccountClientProfileModel>>> AccountSearch(Account model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<AccountClientProfileModel> res = this._accoutnClient.Search(HttpContext.Request, model);
                this.commonService.LogTime<AccountClientProfileModel>(HttpContext.Request, _accoutnClient._tablename, string.Format("SEARCH WITH ACCOUNT: {0}", model.account ), res);
                this.commonService.LogTime<AccountClientProfileModel>(HttpContext.Request, _accoutnClient._tableName2, string.Format("SEARCH WITH ACCOUNT: {0}", model.account), res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("AccountGetALL")]
        public async Task<ActionResult<StatusMessage<List<UserInfo>>>> AccountGetALL(Account model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<List<UserInfo>> res = this._accoutnClient.GetListUser(HttpContext.Request, model);
                this.commonService.LogTime<List<UserInfo>>(HttpContext.Request, _accoutnClient._tablename, "GET LIST USER", res);
                this.commonService.LogTime<List<UserInfo>>(HttpContext.Request, _accoutnClient._tableName2, "GET LIST USER", res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("AccountDelete")]
        public async Task<ActionResult<StatusMessage<Account>>> AccountDelete(Account model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage <Account> res = this._accoutnClient.Delete(HttpContext.Request, model);
                this.commonService.LogTime<Account>(HttpContext.Request, _accoutnClient._tablename, string.Format("DELETE  ACCOUNT: {0}", model.account), res);
                this.commonService.LogTime<Account>(HttpContext.Request, _accoutnClient._tableName2, string.Format("DELETE  ACCOUNT: {0}", model.account), res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("AccountChangeStatusLock")]
        public async Task<ActionResult<StatusMessage<dynamic>>> AccountChangeStatusLock(Account model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = this._accoutnClient.Lock(HttpContext.Request, model);
                this.commonService.LogTime<dynamic>(HttpContext.Request, _accoutnClient._tablename, string.Format("LOCK  ACCOUNT: {0}", model.account), res);
                this.commonService.LogTime<dynamic>(HttpContext.Request, _accoutnClient._tableName2, string.Format("LOCK  ACCOUNT: {0}", model.account), res);
                return res;

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("AccountChangeStatusApproval")]
        public async Task<ActionResult<StatusMessage<dynamic>>> AccountChangeStatusApproval(Account model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = this._accoutnClient.Approval(HttpContext.Request, model);
                this.commonService.LogTime<dynamic>(HttpContext.Request, _accoutnClient._tablename, string.Format("APPROVAL  ACCOUNT: {0}", model.account), res);
                this.commonService.LogTime<dynamic>(HttpContext.Request, _accoutnClient._tableName2, string.Format("APPROVAL  ACCOUNT: {0}", model.account), res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("AccountChangePassword")]
        public async Task<ActionResult<StatusMessage<dynamic>>> AccountChangePassword(Account model)
        {
            if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                StatusMessage<dynamic> res = this._accoutnClient.ChangePassword(HttpContext.Request, model);
                this.commonService.LogTime<dynamic>(HttpContext.Request, _accoutnClient._tablename, string.Format("CHANGE PASSWORD  ACCOUNT: {0}", model.account), res);
                this.commonService.LogTime<dynamic>(HttpContext.Request, _accoutnClient._tableName2, string.Format("CHANGE PASSWORD  ACCOUNT: {0}", model.account), res);
                return res;
            }
            else
            {
                return Unauthorized();
            }
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.account == id);
        }
    }
}
